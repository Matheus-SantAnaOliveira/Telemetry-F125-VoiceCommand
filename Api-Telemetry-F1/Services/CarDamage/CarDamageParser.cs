using Api_Telemetry_F1.Common;
using Api_Telemetry_F1.Elastic;
using Api_Telemetry_F1.Models.CarDamage;
using Api_Telemetry_F1.TelemetryUtils;

namespace Api_Telemetry_F1.Services.CarDamage
{
    public class CarDamageParser
    {
        private static CarDamageData ParseSingleCarDamage(byte[] data, int position, List<CachedDriversInfo> driversInfos, ref int index)
        {
            var cd = new CarDamageData();
            var driver = CachedDriversInfoExtensions.GetDriverByPosition(driversInfos, position);

            if (driver != null)
            {
                cd.DriverName = driver.DriverName;
                cd.DriverTeam = driver.DriverTeam;
            }
            cd.ReceivedAt = DateTime.UtcNow;
            for (int i = 0; i < 4; i++) 
                cd.TyresWear[i] = BitConverter.ToSingle(data, index + i * 4);
            index += 16;
            for (int i = 0; i < 4; i++) 
                cd.TyresDamage[i] = data[index++];
            for (int i = 0; i < 4; i++) 
                cd.BrakesDamage[i] = data[index++];
            for (int i = 0; i < 4; i++) 
                cd.TyreBlisters[i] = data[index++];

            cd.FrontLeftWingDamage = data[index++];
            cd.FrontRightWingDamage = data[index++];
            cd.RearWingDamage = data[index++];
            cd.FloorDamage = data[index++];
            cd.DiffuserDamage = data[index++];
            cd.SidepodDamage = data[index++];
            cd.DRSFault = data[index++];
            cd.DRSFaultDescription = TranslateByteType.FaultIndicator(cd.DRSFault);
            cd.ERSFault = data[index++];
            cd.ERSFaultDescription = TranslateByteType.FaultIndicator(cd.ERSFault);
            cd.GearboxDamage = data[index++];
            cd.EngineDamage = data[index++];
            cd.EngineMGUHWear = data[index++];
            cd.EngineESWear = data[index++];
            cd.EngineCEWear = data[index++];
            cd.EngineICEWear = data[index++];
            cd.EngineMGUKWear = data[index++];
            cd.EngineTCWear = data[index++];
            cd.EngineBlown = data[index++];
            cd.EngineBlownDescription = TranslateByteType.FaultIndicator(cd.EngineBlown);
            cd.EngineSeized = data[index++];
            cd.EngineSeizedDescription = TranslateByteType.FaultIndicator(cd.EngineSeized);
            return cd;
        }

        public static PacketCarDamage ParsePacketCarDamageData(byte[] data, List<CachedDriversInfo> driversInfos, ElasticClientWrapper elkClient)
        {
            int index = 0;
            var packet = new PacketCarDamage();
            packet.EventDate = DateTime.UtcNow;
            for (int i = 0; i < 22; i++)
            {
                var cd = ParseSingleCarDamage(data, i, driversInfos, ref index);
                elkClient.Client.Index(cd, req => req.Index("telemetryf1-data-single-cardamage"));
                packet.DamageList.Add(cd);
            }
            return packet;
        }
    }
}
