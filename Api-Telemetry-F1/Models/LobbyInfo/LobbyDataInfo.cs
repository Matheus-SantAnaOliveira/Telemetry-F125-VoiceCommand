using Api_Telemetry_F1.TelemetryUtils;
using System.Runtime.InteropServices;
using System.Text;

namespace Api_Telemetry_F1.Models.LobbyInfo
{
    public class LobbyInfoData
    {
        public byte AiControlled { get; set; }
        public string AiControlledDescription { get; set; }
        public byte TeamId { get; set; }
        public string TeamName { get; set; } = string.Empty;
        public byte Nationality { get; set; }
        public string NationalityNamePtBr { get; set; } = string.Empty;
        public string NationalityNameEn { get; set; } = string.Empty;
        public string CountryNamePtBr { get; set; } = string.Empty;
        public string CountryNameEn { get; set; } = string.Empty;
        public byte Platform { get; set; }
        public string PlatformDescription { get; set; }
        public string Name { get; set; }
        public byte CarNumber { get; set; }
        public byte YourTelemetry { get; set; }
        public string YourTelemetryDescription { get; set; }
        public byte ShowOnlineNames { get; set; }
        public string ShowOnlineNamesDescription { get; set; }
        public ushort TechLevel { get; set; }
        public byte ReadyStatus { get; set; }
        public string ReadyStatusDescription { get; set; }
        public string TelemetryType { get; set; } = "Lobby Info Data";
        public DateTime EventDate { get; set; }
    }
}