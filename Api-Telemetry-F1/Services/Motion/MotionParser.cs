using Api_Telemetry_F1.Common;
using Api_Telemetry_F1.Elastic;
using Api_Telemetry_F1.Models.FinalClassification;
using Api_Telemetry_F1.Models.Header;

namespace Api_Telemetry_F1.Models.Motion
{
    public class MotionParser
    {
        private static CarMotionData SingleMotionParse(byte[] data, List<CachedDriversInfo> driversInfos, int position,ref int index)
        {
            var carMotion = new CarMotionData();
            var driver = CachedDriversInfoExtensions.GetDriverByPosition(driversInfos, position);

            if (driver == null)
            {
                carMotion.DriverName = null;
                carMotion.DriverTeam = null;
            }
            else
            {
                carMotion.DriverName = driver.DriverName;
                carMotion.DriverTeam = driver.DriverTeam;
            }

            carMotion.ReceivedAt = DateTime.Now;
                
            carMotion.WorldPositionX = BitConverter.ToSingle(data, index); index += 4;
            carMotion.WorldPositionY = BitConverter.ToSingle(data, index); index += 4;
            carMotion.WorldPositionZ = BitConverter.ToSingle(data, index); index += 4;

            carMotion.WorldVelocityX = BitConverter.ToSingle(data, index); index += 4;
            carMotion.WorldVelocityY = BitConverter.ToSingle(data, index); index += 4;
            carMotion.WorldVelocityZ = BitConverter.ToSingle(data, index); index += 4;

            carMotion.WorldForwardDirX = BitConverter.ToInt16(data, index); index += 2;
            carMotion.WorldForwardDirY = BitConverter.ToInt16(data, index); index += 2;
            carMotion.WorldForwardDirZ = BitConverter.ToInt16(data, index); index += 2;

            carMotion.WorldRightDirX = BitConverter.ToInt16(data, index); index += 2;
            carMotion.WorldRightDirY = BitConverter.ToInt16(data, index); index += 2;
            carMotion.WorldRightDirZ = BitConverter.ToInt16(data, index); index += 2;

            carMotion.GForceLateral = BitConverter.ToSingle(data, index); index += 4;
            carMotion.GForceLongitudinal = BitConverter.ToSingle(data, index); index += 4;
            carMotion.GForceVertical = BitConverter.ToSingle(data, index); index += 4;

            carMotion.Yaw = BitConverter.ToSingle(data, index); index += 4;
            carMotion.Pitch = BitConverter.ToSingle(data, index); index += 4;
            carMotion.Roll = BitConverter.ToSingle(data, index); index += 4;
            return carMotion;
        }

        public static PacketMotion ParsePacketMotion(byte[] data, List<CachedDriversInfo> driversInfos, ElasticClientWrapper elkClient)
        {
            int index = 0;
            var packet = new PacketMotion();
            packet.EventDate = DateTime.UtcNow;

            for (int i = 0; i < 22; i++)
            {
                var cm = SingleMotionParse(data, driversInfos, i, ref index);
                elkClient.Client.Index(cm, req => req.Index("telemetryf1-data-motion-individual"));
                packet.CarMotionData.Add(cm);
            }
            return packet;
        }
    }
}

