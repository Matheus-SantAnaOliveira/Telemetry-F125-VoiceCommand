using Api_Telemetry_F1.Common;
using Api_Telemetry_F1.Elastic;
using Api_Telemetry_F1.TelemetryUtils;

namespace Api_Telemetry_F1.Models.FinalClassification
{
    public class FinalClassificationParser
    {
        public static FinalClassificationData ParseSingleFinalClassification(byte[] data, int position, List<CachedDriversInfo> driversInfos, ref int index)
        {
            var fc = new FinalClassificationData();

            var driver = CachedDriversInfoExtensions.GetDriverByPosition(driversInfos, position);
            if (driver != null)
            {
                fc.DriverName = driver.DriverName;
                fc.DriverTeam = driver.DriverTeam;
            }
            fc.ReceivedAt = DateTime.UtcNow;
            fc.Position = data[index++];
            fc.NumLaps = data[index++];
            fc.GridPosition = data[index++];
            fc.Points = data[index++];
            fc.NumPitStops = data[index++];
            fc.ResultStatus = data[index++];
            fc.ResultStatusDescription = TranslateByteType.ResultStatus(fc.ResultStatus);
            fc.ResultReason = data[index++];
            fc.ResultReasonDescription = TranslateByteType.ResultReason(fc.ResultReason);
            fc.BestLapTimeInMS = BitConverter.ToUInt32(data, index); index += 4;
            fc.TotalRaceTime = BitConverter.ToDouble(data, index); index += 8;
            fc.PenaltiesTime = data[index++];
            fc.NumPenalties = data[index++];
            fc.NumTyreStints = data[index++];

            for (int i = 0; i < 8; i++) fc.TyreStintsActual[i] = data[index++];
            for (int i = 0; i < 8; i++) fc.TyreStintsVisual[i] = data[index++];
            for (int i = 0; i < 8; i++) fc.TyreStintsEndLaps[i] = data[index++];

            return fc;
        }

        public static PacketFinalClassification ParsePacketFinalClassificationData(byte[] data, List<CachedDriversInfo> driversInfos, ElasticClientWrapper elkClient)
        {
            int index = 0;
            var packet = new PacketFinalClassification();
            packet.EventDate = DateTime.UtcNow;
            packet.NumCars = data[index++];
            
            for (int i = 0; i < 22; i++)
            {
                var fc = ParseSingleFinalClassification(data, i, driversInfos, ref index);

                elkClient.Client.Index(fc, req => req.Index("telemetryf1-data-finalclassification-individual"));
                packet.ClassificationList.Add(fc);
            }

            return packet;
        }
    }
}
