using Api_Telemetry_F1.Common;
using Api_Telemetry_F1.Elastic;
using Api_Telemetry_F1.TelemetryUtils;

namespace Api_Telemetry_F1.Models.CarStatus
{
    public class CarStatusParser
    {
        private static CarStatusData ParseSingleCarStatusData(byte[] data, int position, List<CachedDriversInfo> driversInfos,ref int index)
        {
            CarStatusData cs = new CarStatusData();
            cs.ReceivedAt = DateTime.UtcNow;
            var driver = CachedDriversInfoExtensions.GetDriverByPosition(driversInfos, position);
            if (driver != null)
            {
                cs.DriverName = driver.DriverName;
                cs.DriverTeam = driver.DriverTeam;
            }
            cs.TractionControl = data[index++];
            cs.TractionControlDescription = TranslateByteType.TractionControl(cs.TractionControl);
            cs.AntiLockBrakes = data[index++];
            cs.AntiLockBrakesDescription = TranslateByteType.OnOffValue(cs.AntiLockBrakes);
            cs.FuelMix = data[index++];
            cs.FuelMixDescription = TranslateByteType.FuelMix(cs.FuelMix);
            cs.FrontBrakeBias = data[index++];
            cs.PitLimiterStatus = data[index++];
            cs.PitLimiterStatusDescription = TranslateByteType.OnOffValue(cs.PitLimiterStatus);
            cs.FuelInTank = BitConverter.ToSingle(data, index); index += 4;
            cs.FuelCapacity = BitConverter.ToSingle(data, index); index += 4;
            cs.FuelRemainingLaps = BitConverter.ToSingle(data, index); index += 4;
            cs.MaxRPM = BitConverter.ToUInt16(data, index); index += 2;
            cs.IdleRPM = BitConverter.ToUInt16(data, index); index += 2;
            cs.MaxGears = data[index++];
            cs.DrsAllowed = data[index++];
            cs.DrsAllowedDescription = TranslateByteType.DrsAllowed(cs.DrsAllowed);
            cs.DrsActivationDistance = BitConverter.ToUInt16(data, index); index += 2;
            cs.ActualTyreCompound = data[index++];
            cs.ActualTyreCompoundDesc = TranslateByteType.TyreCompound(cs.ActualTyreCompound);
            cs.VisualTyreCompound = data[index++];
            cs.VisualTyreCompoundDesc = TranslateByteType.VisualTyreCompound(cs.VisualTyreCompound);
            cs.TyresAgeLaps = data[index++];
            cs.VehicleFiaFlags = (sbyte)data[index++];
            cs.VehicleFiaFlagsDesc = TranslateByteType.FiaFlags(cs.VehicleFiaFlags);
            cs.EnginePowerICE = BitConverter.ToSingle(data, index); index += 4;
            cs.EnginePowerMGUK = BitConverter.ToSingle(data, index); index += 4;
            cs.ErsStoreEnergy = BitConverter.ToSingle(data, index); index += 4;
            cs.ErsDeployMode = data[index++];
            cs.ErsDeployModeDescription = TranslateByteType.DeployMode(cs.ErsDeployMode);
            cs.ErsHarvestedThisLapMGUK = BitConverter.ToSingle(data, index); index += 4;
            cs.ErsHarvestedThisLapMGUH = BitConverter.ToSingle(data, index); index += 4;
            cs.ErsDeployedThisLap = BitConverter.ToSingle(data, index); index += 4;
            cs.NetworkPaused = data[index++];

            return cs;
        }
        public static PacketCarStatus ParsePacketCarStatusData(byte[] data,List<CachedDriversInfo> driversInfos,ElasticClientWrapper elkClient)
        {
            int index = 0;
            PacketCarStatus packet = new PacketCarStatus();
            packet.EventDate = DateTime.UtcNow;
            for (int i = 0; i < 22; i++)
            {
                var cs = ParseSingleCarStatusData(data, i, driversInfos, ref index);

                var indexResponseButtons = elkClient.Client.Index<CarStatusData>(cs, idx => idx
                    .Index("telemetryf1-data-carstatus-individual"));

                packet.CarStatusList.Add(cs);
            }
            return packet;
        }
    }
}