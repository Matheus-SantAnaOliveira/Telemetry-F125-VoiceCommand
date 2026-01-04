using Api_Telemetry_F1.Models.Header;

namespace Api_Telemetry_F1.Models.Motion
{
    public class PacketMotion
    {
        public PacketHeader Header { get; set; }
        public List<CarMotionData> CarMotionData { get; set; } = new();
        public DateTime EventDate { get; set; }
        public string TelemetryType { get; set; } = "Lobby Info Data";
    }
}
