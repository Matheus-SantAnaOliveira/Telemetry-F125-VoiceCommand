using Api_Telemetry_F1.Common;
using Api_Telemetry_F1.Models.TyreSet;
using Api_Telemetry_F1.TelemetryUtils;

namespace Api_Telemetry_F1.Services.TyreSet
{
    public class TyreSetParser
    {
        public static PacketTyreSetsData ParseTyreSetsData(byte[] data, List<CachedDriversInfo> driversInfos)
        {
            int index = 0;
            PacketTyreSetsData packet = new();
            packet.EventDate = DateTime.UtcNow;
            packet.CarIdx = data[index++];
            var driver = CachedDriversInfoExtensions.GetDriverByVehicleIdx(driversInfos, packet.CarIdx);
            packet.DriverName = driver?.DriverName ?? "Unknown";
            packet.DriverTeam = driver?.DriverTeam ?? "Unknown";
            for (int i = 0; i < 20; i++)
            {
                TyreSetData ts = new TyreSetData();
                ts.ActualCompound = data[index++];
                ts.ActualCompoundDesc = TranslateByteType.TyreCompound(ts.ActualCompound);
                ts.VisualCompound = data[index++];
                ts.VisualCompoundDesc = TranslateByteType.VisualTyreCompound(ts.VisualCompound);
                ts.Wear = data[index++];
                ts.Available = data[index++];
                ts.RecommendedSession = data[index++];
                ts.LifeSpan = data[index++];
                ts.UsableLife = data[index++];
                ts.LapDeltaTime = BitConverter.ToInt16(data, index); index += 2;
                ts.Fitted = data[index++];
                packet.TyreSets.Add(ts);
            }
            packet.FittedIdx = data[index++];
            return packet;
        }

    }
}
