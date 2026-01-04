using Api_Telemetry_F1.Common;
using Api_Telemetry_F1.Elastic;
using Api_Telemetry_F1.Models;
using Api_Telemetry_F1.Models.CarDamage;
using Api_Telemetry_F1.Models.CarSetup;
using Api_Telemetry_F1.Models.CarStatus;
using Api_Telemetry_F1.Models.CarTelemetry;
using Api_Telemetry_F1.Models.EventData;
using Api_Telemetry_F1.Models.FinalClassification;
using Api_Telemetry_F1.Models.LapData;
using Api_Telemetry_F1.Models.LapPosition;
using Api_Telemetry_F1.Models.LobbyInfo;
using Api_Telemetry_F1.Models.Motion;
using Api_Telemetry_F1.Models.MotionEx;
using Api_Telemetry_F1.Models.ParticipantsPackage;
using Api_Telemetry_F1.Models.SessionData;
using Api_Telemetry_F1.Models.SessionHistory;
using Api_Telemetry_F1.Models.TimeTrial;
using Api_Telemetry_F1.Models.TyreSet;
using Api_Telemetry_F1.Services.CarDamage;
using Api_Telemetry_F1.Services.CarSetup;
using Api_Telemetry_F1.Services.CarStatus;
using Api_Telemetry_F1.Services.CarTelemetry;
using Api_Telemetry_F1.Services.EventData;
using Api_Telemetry_F1.Services.FinalClassification;
using Api_Telemetry_F1.Services.Header;
using Api_Telemetry_F1.Services.LapData;
using Api_Telemetry_F1.Services.LapPosition;
using Api_Telemetry_F1.Services.LobbyInfo;
using Api_Telemetry_F1.Services.Motion;
using Api_Telemetry_F1.Services.MotionEx;
using Api_Telemetry_F1.Services.ParticipantsPackage;
using Api_Telemetry_F1.Services.SessionData;
using Api_Telemetry_F1.Services.SessionHistory;
using Api_Telemetry_F1.Services.TimeTrial;
using Api_Telemetry_F1.Services.TyreSet;
using Microsoft.Extensions.Options;
using System.Net.Sockets;
namespace Api_Telemetry_F1.Workers
{

    public class TelemetryWorker : BackgroundService
    {
        private readonly TelemetryState _state;
        private UdpClient? _udp;
        private F1PackageConfig _packageConfig;
        TotalTelemetryReceived totalTelemetryReceived = new TotalTelemetryReceived();
        ElasticClientWrapper ElasticClient = new ElasticClientWrapper();
        List<CachedDriversInfo> _CacheParticipants = new List<CachedDriversInfo>();
        public TelemetryWorker(TelemetryState state, IOptions<F1PackageConfig> packageConfig)
        {
            _state = state;
            _packageConfig = packageConfig.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            const int port = 20777;
            _udp = new UdpClient(port);
            bool anota = false;
            while (!stoppingToken.IsCancellationRequested)
            {
                if (!_state.Running)
                {
                    await Task.Delay(200, stoppingToken);
                    continue;
                }
                var r = await _udp.ReceiveAsync(stoppingToken);
                var data = r.Buffer;

                totalTelemetryReceived.PacketHeader = PacketHeaderParser.ParseHeader(data);
                Console.WriteLine($"Tamanho Pacote: {data.Length}, Tipo Pacote: {totalTelemetryReceived.PacketHeader.PacketId}");
                int telemetryDataSize = data.Length - _packageConfig.HeaderSize;
                byte[] telemetryInfos = new byte[telemetryDataSize];

                Array.Copy(data, _packageConfig.HeaderSize, telemetryInfos, 0, telemetryDataSize);

                if (totalTelemetryReceived.PacketHeader.PacketId == 0)
                {
                    totalTelemetryReceived.MotionPacket = MotionParser.ParsePacketMotion(telemetryInfos, _CacheParticipants, ElasticClient);
                    var indexResponseButtons = ElasticClient.Client.Index<PacketMotion>(totalTelemetryReceived.MotionPacket, i => i
                                        .Index("telemetryf1-data-motion-packet"));

                    Console.WriteLine($"Tipo Telemetria {totalTelemetryReceived.MotionPacket.TelemetryType}");
                }

                if (totalTelemetryReceived.PacketHeader.PacketId == 1)
                {
                    totalTelemetryReceived.SessionPacket = SessionParser.SessionPacketParse(telemetryInfos);
                    var indexResponseButtons = ElasticClient.Client.Index<PacketSession>(totalTelemetryReceived.SessionPacket, i => i
                                        .Index("telemetryf1-data-session-packet"));

                    Console.WriteLine($"Tipo Telemetria {totalTelemetryReceived.SessionPacket.TelemetryType}");
                }

                if (totalTelemetryReceived.PacketHeader.PacketId == 2)
                {
                    totalTelemetryReceived.LapDataPacket = LapaDataParser.ParsePacketLapData(telemetryInfos, _CacheParticipants, ElasticClient);
                    var indexResponseButtons = ElasticClient.Client.Index<PacketLapData>(totalTelemetryReceived.LapDataPacket, i => i
                                        .Index("telemetryf1-data-lapdata-packet"));

                    Console.WriteLine($"Tipo Telemetria {totalTelemetryReceived.LapDataPacket.TelemetryType}");
                }

                if (totalTelemetryReceived.PacketHeader.PacketId == 3)
                {
                    totalTelemetryReceived.EventDataPacket = EventParser.CreateObjectEvent(telemetryInfos, _CacheParticipants);

                    var indexResponseButtons = ElasticClient.Client.Index<PacketEventData>(totalTelemetryReceived.EventDataPacket, i => i
                                        .Index("telemetryf1-data-event-packet"));

                    Console.WriteLine($"Tipo Telemetria {totalTelemetryReceived.EventDataPacket.TelemetryType}");
                    Console.WriteLine($"Tipo Evento {totalTelemetryReceived.EventDataPacket.EventStringCode}");
                }

                if (totalTelemetryReceived.PacketHeader.PacketId == 4)
                {
                    int expectedSize = 1284 - _packageConfig.HeaderSize;

                    if (telemetryDataSize != expectedSize)
                    {
                        Console.WriteLine($"Pacote de participantes tamanho inesperado: " +
                            $"esperado {expectedSize}, recebido {telemetryDataSize}");
                        return;
                    }

                    totalTelemetryReceived.ParticipantsInfoPacket = ParticipantParser.ParseParticipants(telemetryInfos);
                    if(totalTelemetryReceived != null && totalTelemetryReceived.ParticipantsInfoPacket.Participants.Count > 0)
                        _CacheParticipants = CachedDriversInfoExtensions.ToCachedDriversInfo(totalTelemetryReceived.ParticipantsInfoPacket);

                    var indexResponseButtons = ElasticClient.Client.Index<PacketParticipantsInfo>(totalTelemetryReceived.ParticipantsInfoPacket, i => i
                                        .Index("telemetryf1-data-participants-info-packet"));
                    Console.WriteLine($"Tipo Telemetria {totalTelemetryReceived.ParticipantsInfoPacket.TelemetryType}");
                }

                if (totalTelemetryReceived.PacketHeader.PacketId == 5)
                {
                    totalTelemetryReceived.CarSetupPacket = CarSetupParser.ParsePacketCarSetupData(telemetryInfos, _CacheParticipants, ElasticClient);

                    var indexResponseButtons = ElasticClient.Client.Index<PacketCarSetup>(totalTelemetryReceived.CarSetupPacket, i => i
                                        .Index("telemetryf1-data-car-setup-full-packet"));
                    Console.WriteLine($"Tipo Telemetria {totalTelemetryReceived.CarSetupPacket.TelemetryType}");
                }

                if (totalTelemetryReceived.PacketHeader.PacketId == 6)
                {
                    totalTelemetryReceived.CarTelemetryPacket = CarTelemetryParse.ParsePacketCarTelemetryData(telemetryInfos, _CacheParticipants, ElasticClient);

                    var indexResponseButtons = ElasticClient.Client.Index<PacketTelemetryCar>(totalTelemetryReceived.CarTelemetryPacket, i => i
                                        .Index("telemetryf1-data-car-telemetry-full-packet"));
                    Console.WriteLine($"Tipo Telemetria {totalTelemetryReceived.CarTelemetryPacket.TelemetryType}");
                }

                if (totalTelemetryReceived.PacketHeader.PacketId == 7)
                {
                    totalTelemetryReceived.CarStatusPacket = CarStatusParser.ParsePacketCarStatusData(telemetryInfos, _CacheParticipants, ElasticClient);

                    var indexResponseButtons = ElasticClient.Client.Index<PacketCarStatus>(totalTelemetryReceived.CarStatusPacket, i => i
                                        .Index("telemetryf1-data-car-telemetry-full-packet"));
                    Console.WriteLine($"Tipo Telemetria {totalTelemetryReceived.CarStatusPacket.TelemetryType}");
                }

                if (totalTelemetryReceived.PacketHeader.PacketId == 8)
                {
                    totalTelemetryReceived.FinalClassificationPacket = FinalClassificationParser.ParsePacketFinalClassificationData(telemetryInfos, _CacheParticipants, ElasticClient);
                    var indexResponseButtons = ElasticClient.Client.Index<PacketFinalClassification>(totalTelemetryReceived.FinalClassificationPacket, i => i
                                        .Index("telemetryf1-data-final-classification-packet"));

                    Console.WriteLine($"Tipo Telemetria {totalTelemetryReceived.FinalClassificationPacket.TelemetryType}");
                }

                if (totalTelemetryReceived.PacketHeader.PacketId == 9)
                {
                    totalTelemetryReceived.LobbyInfoDataPacket = LobbyInfoParser.PacketLobbyInfoParse(telemetryInfos, _CacheParticipants, ElasticClient);
                    var indexResponseButtons = ElasticClient.Client.Index<PacketLobbyInfoData>(totalTelemetryReceived.LobbyInfoDataPacket, i => i
                                        .Index("telemetryf1-data-lobby-info-packet"));
                    
                    Console.WriteLine($"Tipo Telemetria {totalTelemetryReceived.LobbyInfoDataPacket.TelemetryType}");
                }

                if (totalTelemetryReceived.PacketHeader.PacketId == 10)
                {
                    totalTelemetryReceived.CarDamagePacket = CarDamageParser.ParsePacketCarDamageData(telemetryInfos, _CacheParticipants, ElasticClient);
                    var indexResponseButtons = ElasticClient.Client.Index<PacketCarDamage>(totalTelemetryReceived.CarDamagePacket, i => i
                                        .Index("telemetryf1-data-car-damage-info-packet"));

                    Console.WriteLine($"PacketId: {data[0]}  Size: {data.Length}");
                    Console.WriteLine($"Tipo Telemetria {totalTelemetryReceived.CarDamagePacket.TelemetryType}");
                }

                if (totalTelemetryReceived.PacketHeader.PacketId == 11)
                {
                    totalTelemetryReceived.SessionHistoryPacket = SessionHistoryParser.ParseSessionHistory(telemetryInfos, _CacheParticipants);
                    var indexResponseButtons = ElasticClient.Client.Index<PacketSessionHistory>(totalTelemetryReceived.SessionHistoryPacket, i => i
                                        .Index("telemetryf1-data-session-history-info-packet"));

                    Console.WriteLine($"Tipo Telemetria {totalTelemetryReceived.SessionHistoryPacket.TelemetryType}");
                }

                if (totalTelemetryReceived.PacketHeader.PacketId == 12)
                {
                    totalTelemetryReceived.TyreSetDataPacket = TyreSetParser.ParseTyreSetsData(telemetryInfos, _CacheParticipants);
                    var indexResponseButtons = ElasticClient.Client.Index<PacketTyreSetsData>(totalTelemetryReceived.TyreSetDataPacket, i => i
                                        .Index("telemetryf1-tyre-set-info-3"));

                    Console.WriteLine($"Tipo Telemetria {totalTelemetryReceived.TyreSetDataPacket.TelemetryType}");
                }

                if (totalTelemetryReceived.PacketHeader.PacketId == 13)
                {
                    totalTelemetryReceived.MotionExPacket = MotionExParser.ParseMotionEx(telemetryInfos);
                    var indexResponseButtons = ElasticClient.Client.Index<PacketMotionEx>(totalTelemetryReceived.MotionExPacket, i => i
                                        .Index("telemetryf1-data-motion-ex-info-packet"));

                    Console.WriteLine($"Tipo Telemetria {totalTelemetryReceived.MotionExPacket.TelemetryType}");
                }

                if (totalTelemetryReceived.PacketHeader.PacketId == 14)
                {
                    totalTelemetryReceived.TimeTrialPacket = TimeTrialParse.ParsePacketTimeTrialData(telemetryInfos, _CacheParticipants, ElasticClient);
                    var indexResponseButtons = ElasticClient.Client.Index<PacketTimeTrial>(totalTelemetryReceived.TimeTrialPacket, i => i
                                        .Index("telemetryf1-data-time-trial-info-packet"));

                    Console.WriteLine($"Tipo Telemetria {totalTelemetryReceived.TimeTrialPacket.TelemetryType}");
                }

                if (totalTelemetryReceived.PacketHeader.PacketId == 15)
                {
                    totalTelemetryReceived.LapPositionPacket = LapPostionParse.ParsePacketLapPositionsData(telemetryInfos, _CacheParticipants, ElasticClient);
                    var indexResponseButtons = ElasticClient.Client.Index<PacketLapPosition>(totalTelemetryReceived.LapPositionPacket, i => i
                                        .Index("telemetryf1-data-lap-position-info-packet"));

                    Console.WriteLine($"Tipo Telemetria {totalTelemetryReceived.LapPositionPacket.TelemetryType}");
                }
            }
            var indexResponse = ElasticClient.Client.Index<TotalTelemetryReceived>(totalTelemetryReceived, i => i
                                .Index("telemetryf1-data"));
        }
        

        public override void Dispose()
        {
            _udp?.Dispose();
            base.Dispose();
        }
    }

}