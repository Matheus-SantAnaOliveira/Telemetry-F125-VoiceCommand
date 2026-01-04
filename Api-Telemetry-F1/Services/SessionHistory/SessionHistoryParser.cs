using Api_Telemetry_F1.Common;
using Api_Telemetry_F1.TelemetryUtils;

namespace Api_Telemetry_F1.Models.SessionHistory
{
    public class SessionHistoryParser
    {
        public static PacketSessionHistory ParseSessionHistory(byte[] data, List<CachedDriversInfo> driversInfos)
        {
            int index = 0;
            PacketSessionHistory packet = new();
            packet.EventDate = DateTime.UtcNow;
            packet.CarIdx = data[index++];
            var driver = CachedDriversInfoExtensions.GetDriverByVehicleIdx(driversInfos, packet.CarIdx);
            packet.DriverName = driver?.DriverName ?? "Unknown";
            packet.DriverTeam = driver?.DriverTeam ?? "Unknown";
            packet.NumLaps = data[index++];
            packet.NumTyreStints = data[index++];
            packet.BestLapNum = data[index++];
            packet.BestS1LapNum = data[index++];
            packet.BestS2LapNum = data[index++];
            packet.BestS3LapNum = data[index++];

            for (int i = 0; i < 100; i++)
            {
                LapHistoryData lap = new();
                lap.LapTimeInMS = BitConverter.ToUInt32(data, index); index += 4;
                lap.Sector1MS = BitConverter.ToUInt16(data, index); index += 2;
                lap.Sector1Minutes = data[index++];
                lap.Sector2MS = BitConverter.ToUInt16(data, index); index += 2;
                lap.Sector2Minutes = data[index++];
                lap.Sector3MS = BitConverter.ToUInt16(data, index); index += 2;
                lap.Sector3Minutes = data[index++];
                lap.ValidFlags = data[index++];
                lap.ReceivedAt = DateTime.UtcNow;
                if (i < packet.NumLaps)
                    packet.Laps.Add(lap);
            }

            for (int i = 0; i < 8; i++)
            {
                TyreStintHistoryData stint = new();
                stint.EndLap = data[index++];
                stint.TyreActual = data[index++];
                stint.TyreActualDesc = TranslateByteType.TyreCompound(stint.TyreActual);
                stint.TyreVisual = data[index++];
                stint.TyreVisualDesc = TranslateByteType.TyreCompound(stint.TyreVisual);
                if (i < packet.NumTyreStints)
                    packet.TyreStints.Add(stint);
            }
            return packet;
        }
    }
}
