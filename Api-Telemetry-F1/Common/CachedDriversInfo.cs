using Api_Telemetry_F1.Models.ParticipantsPackage;
using System.Reflection.Metadata.Ecma335;

namespace Api_Telemetry_F1.Common
{
    public class CachedDriversInfo
    {
        public string DriverName { get; set; } = string.Empty;
        public string DriverTeam { get; set; } = string.Empty;
        public int DriverId { get; set; }
        public int DriverListPosition { get; set; }
    }

    public static class CachedDriversInfoExtensions
    {
        public static List<CachedDriversInfo> ToCachedDriversInfo(PacketParticipantsInfo participant)
        {
            List<CachedDriversInfo> cachedDrivers = new List<CachedDriversInfo>();
            for (int i = 0; i < participant.Participants.Count; i++)
            {
                var p = participant.Participants[i];
                if (p.DriverId.ToString() == participant.Participants[i].DriverId.ToString())
                {
                    cachedDrivers.Add( new CachedDriversInfo
                    {
                        DriverName = p.DriverName,
                        DriverTeam = p.TeamName,
                        DriverId = p.DriverId,
                        DriverListPosition = i
                    });
                }
            }
            return cachedDrivers;
        }

        public static CachedDriversInfo GetDriverByVehicleIdx(List<CachedDriversInfo> participants, byte driverId)
        {
            if (participants == null)
                return null;

            for (int i = 0; i < participants.Count; i++)
            {
                if (participants[i].DriverListPosition == driverId)
                    return participants[i]; 
            }

            return null; 
        }
        public static CachedDriversInfo GetDriverByPosition(List<CachedDriversInfo> participants, int position)
        {
            if (position < 0 || position >= participants.Count)
                return null;
            return participants[position];
        }

    }
}
