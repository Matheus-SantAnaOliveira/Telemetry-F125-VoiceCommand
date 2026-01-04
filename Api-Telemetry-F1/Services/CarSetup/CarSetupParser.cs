using Api_Telemetry_F1.Common;
using Api_Telemetry_F1.Elastic;

namespace Api_Telemetry_F1.Models.CarSetup
{
    public class CarSetupParser
    {
        public static CarSetupData ParseSingleCarSetup(byte[] data, int position, List<CachedDriversInfo> driversInfos, ref int index)
        {
            CarSetupData cs = new();

            var driver = CachedDriversInfoExtensions.GetDriverByPosition(driversInfos, position);
            if (driver != null)
            {
                cs.DriverName = driver.DriverName;
                cs.DriverTeam = driver.DriverTeam;
            }
            cs.ReceivedAt = DateTime.UtcNow;
            cs.FrontWing = data[index++];
            cs.RearWing = data[index++];
            cs.OnThrottle = data[index++];
            cs.OffThrottle = data[index++];
            cs.FrontCamber = BitConverter.ToSingle(data, index); index += 4;
            cs.RearCamber = BitConverter.ToSingle(data, index); index += 4;
            cs.FrontToe = BitConverter.ToSingle(data, index); index += 4;
            cs.RearToe = BitConverter.ToSingle(data, index); index += 4;
            cs.FrontSuspension = data[index++];
            cs.RearSuspension = data[index++];
            cs.FrontAntiRollBar = data[index++];
            cs.RearAntiRollBar = data[index++];
            cs.FrontSuspensionHeight = data[index++];
            cs.RearSuspensionHeight = data[index++];
            cs.BrakePressure = data[index++];
            cs.BrakeBias = data[index++];
            cs.EngineBraking = data[index++];
            cs.RearLeftTyrePressure = BitConverter.ToSingle(data, index); index += 4;
            cs.RearRightTyrePressure = BitConverter.ToSingle(data, index); index += 4;
            cs.FrontLeftTyrePressure = BitConverter.ToSingle(data, index); index += 4;
            cs.FrontRightTyrePressure = BitConverter.ToSingle(data, index); index += 4;
            cs.Ballast = data[index++];
            cs.FuelLoad = BitConverter.ToSingle(data, index); index += 4;

            return cs;
        }
        public static PacketCarSetup ParsePacketCarSetupData(byte[] data, List<CachedDriversInfo> driversInfos, ElasticClientWrapper elkClient)
        {
            PacketCarSetup packet = new();
            packet.EventDate = DateTime.UtcNow;
            int index = 0;

            for (int i = 0; i < 22; i++)
            {
                var setup = ParseSingleCarSetup(data, i, driversInfos, ref index);
                elkClient.Client.Index(setup, req => req.Index("telemetryf1-data-car-setup"));
                packet.Setups.Add(setup);
            }
            packet.NextFrontWing = BitConverter.ToSingle(data, index);
            index += 4;
            return packet;
        }
    }
}
