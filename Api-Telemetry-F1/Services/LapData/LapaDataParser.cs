using Api_Telemetry_F1.Common;
using Api_Telemetry_F1.Elastic;
using Api_Telemetry_F1.Models.LapData;
using Api_Telemetry_F1.TelemetryUtils;
using Nest;

namespace Api_Telemetry_F1.Services.LapData
{
    public class LapaDataParser
    {
        public static LapDataSingle ParseSingleLapData(byte[] data, int position, List<CachedDriversInfo> driversInfos, ref int index)
        {
            LapDataSingle lapData = new LapDataSingle();

            if (data.Length < 1131)
            {
                Console.WriteLine($"Pacote LapData inválido. Tamanho: {data.Length}");
                return null;
            }

            var driver = CachedDriversInfoExtensions.GetDriverByPosition(driversInfos, position);
            if (driver != null)
            {
                lapData.DriverName = driver.DriverName;
                lapData.DriverTeam = driver.DriverTeam;
            }
            lapData.receviedAt = DateTime.UtcNow;
            lapData.LastLapTimeInMS = BitConverter.ToUInt32(data, index); index += 4;
            lapData.CurrentLapTimeInMS = BitConverter.ToUInt32(data, index); index += 4;
            lapData.Sector1TimeMSPart = BitConverter.ToUInt16(data, index); index += 2;
            lapData.Sector1TimeMinutesPart = data[index++];
            lapData.Sector2TimeMSPart = BitConverter.ToUInt16(data, index); index += 2;
            lapData.Sector2TimeMinutesPart = data[index++];
            lapData.DeltaToCarInFrontMSPart = BitConverter.ToUInt16(data, index); index += 2;
            lapData.DeltaToCarInFrontMinutesPart = data[index++];
            lapData.DeltaToRaceLeaderMSPart = BitConverter.ToUInt16(data, index); index += 2;
            lapData.DeltaToRaceLeaderMinutesPart = data[index++];
            lapData.LapDistance = BitConverter.ToSingle(data, index); index += 4;
            lapData.TotalDistance = BitConverter.ToSingle(data, index); index += 4;
            lapData.SafetyCarDelta = BitConverter.ToSingle(data, index); index += 4;
            lapData.CarPosition = data[index++];
            lapData.CurrentLapNum = data[index++];
            lapData.PitStatus = data[index++];
            lapData.PitStatusDescription = TranslateByteType.PitStatus(lapData.PitStatus);
            lapData.NumPitStops = data[index++];
            lapData.Sector = data[index++];
            lapData.SectorDescription = TranslateByteType.Sector(lapData.Sector);
            lapData.CurrentLapInvalid = data[index++];
            lapData.Penalties = data[index++];
            lapData.TotalWarnings = data[index++];
            lapData.CornerCuttingWarnings = data[index++];
            lapData.NumUnservedDriveThroughPens = data[index++];
            lapData.NumUnservedStopGoPens = data[index++];
            lapData.GridPosition = data[index++];
            lapData.DriverStatus = data[index++];
            lapData.DriverStatusDescription = TranslateByteType.DriverStatus(lapData.DriverStatus);
            lapData.ResultStatus = data[index++];
            lapData.ResultStatusDescription = TranslateByteType.ResultStatus(lapData.ResultStatus);
            lapData.PitLaneTimerActive = data[index++];
            lapData.PitLaneTimeInLaneInMS = BitConverter.ToUInt16(data, index); index += 2;
            lapData.PitStopTimerInMS = BitConverter.ToUInt16(data, index); index += 2;
            lapData.PitStopShouldServePen = data[index++];
            lapData.SpeedTrapFastestSpeed = BitConverter.ToSingle(data, index); index += 4;
            lapData.SpeedTrapFastestLap = data[index++];
            lapData.Sector1TimeTotalMS = lapData.Sector1TimeMinutesPart * 60000 + lapData.Sector1TimeMSPart;
            lapData.Sector2TimeTotalMS = lapData.Sector2TimeMinutesPart * 60000 + lapData.Sector2TimeMSPart;
            lapData.DeltaToCarInFrontTotalMS = lapData.DeltaToCarInFrontMinutesPart * 60000 + lapData.DeltaToCarInFrontMSPart;
            lapData.DeltaToRaceLeaderTotalMS = lapData.DeltaToRaceLeaderMinutesPart * 60000 + lapData.DeltaToRaceLeaderMSPart;
            return lapData;
        }

        public static PacketLapData ParsePacketLapData(byte[] data, List<CachedDriversInfo> driversInfos, ElasticClientWrapper elkClient)
        {
            int index = 0;
            PacketLapData packet = new PacketLapData();
            packet.EventDate = DateTime.UtcNow;

            for (int i = 0; i < 22; i++)
            {
                var ld = ParseSingleLapData(data, i, driversInfos, ref index);
                var indexResponseButtons = elkClient.Client.Index<LapDataSingle>(ld, i => i
                 .Index("telemetryf1-data-lap-data-individual"));
                packet.LapDataList.Add(ld);
            }

            packet.TimeTrialPBCarIdx = data[index++];
            CachedDriversInfo pbDriver = CachedDriversInfoExtensions.GetDriverByVehicleIdx(driversInfos, packet.TimeTrialPBCarIdx);
            packet.TimeTrialPBCarDriverName = pbDriver?.DriverName ?? "Unknown";
            packet.TimeTrialPBCarDriverTeam = pbDriver?.DriverTeam ?? "Unknown";
            packet.TimeTrialRivalCarIdx = data[index++];
            CachedDriversInfo rivalDriver = CachedDriversInfoExtensions.GetDriverByVehicleIdx(driversInfos, packet.TimeTrialRivalCarIdx);
            packet.TimeTrialRivalCarDriverName = pbDriver?.DriverName ?? "Unknown";
            packet.TimeTrialRivalCarDriverTeam = pbDriver?.DriverTeam ?? "Unknown";

            return packet;
        }
    }
}
