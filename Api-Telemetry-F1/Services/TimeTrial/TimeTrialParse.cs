using Api_Telemetry_F1.Common;
using Api_Telemetry_F1.Elastic;
using Api_Telemetry_F1.TelemetryUtils;

namespace Api_Telemetry_F1.Models.TimeTrial
{
    public class TimeTrialParse
    {
        public static TimeTrialData ParseTimeTrialDataSet(byte[] data, List<CachedDriversInfo> driversInfos, int index)
        {
            TimeTrialData ds = new TimeTrialData();
            ds.ReceivedAt = DateTime.UtcNow;

            ds.CarIdx = data[index++];
            ds.TeamId = data[index++];
            ds.TeamName = TeamNameMapping.GetTeamName(ds.TeamId);

            ds.LapTimeInMS = BitConverter.ToUInt32(data, index);
            index += 4;

            ds.Sector1TimeInMS = BitConverter.ToUInt32(data, index);
            index += 4;

            ds.Sector2TimeInMS = BitConverter.ToUInt32(data, index);
            index += 4;

            ds.Sector3TimeInMS = BitConverter.ToUInt32(data, index);
            index += 4;

            ds.TractionControl = data[index++];
            ds.GearboxAssist = data[index++];
            ds.AntiLockBrakes = data[index++];
            ds.EqualCarPerformance = data[index++];
            ds.CustomSetup = data[index++];
            ds.Valid = data[index++];

            var driver = CachedDriversInfoExtensions.GetDriverByVehicleIdx(driversInfos, ds.CarIdx);
            if (driver != null)
            {
                ds.DriverName = driver.DriverName;
                ds.DriverTeam = driver.DriverTeam;
            }
            else
            {
                ds.DriverName = "Unknown";
                ds.DriverTeam = "Unknown";
            }

            return ds;
        }

        public static PacketTimeTrial ParsePacketTimeTrialData(byte[] data, List<CachedDriversInfo> driversInfos, ElasticClientWrapper elkClient)
        {
            int index = 0;
            PacketTimeTrial packet = new PacketTimeTrial();
            packet.EventDate = DateTime.UtcNow;
            packet.PlayerSessionBest = ParseTimeTrialDataSet(data, driversInfos, index);
            elkClient.Client.Index(packet.PlayerSessionBest, i => i.Index("telemetryf1-timetrial-comparation"));
            packet.PersonalBest = ParseTimeTrialDataSet(data, driversInfos, index);
            elkClient.Client.Index(packet.PersonalBest, i => i.Index("telemetryf1-timetrial-comparation"));
            packet.RivalData = ParseTimeTrialDataSet(data, driversInfos, index);
            elkClient.Client.Index(packet.RivalData, i => i.Index("telemetryf1-timetrial-comparation"));
            return packet;
        }
    }
}
