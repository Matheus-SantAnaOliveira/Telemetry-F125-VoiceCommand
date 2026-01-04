using Api_Telemetry_F1.Models.Header;

namespace Api_Telemetry_F1.Models.LapPosition
{
    public class PacketLapPosition
    {
        public byte NumLaps { get; set; }
        public byte LapStart { get; set; }
        public DateTime EventDate { get; set; }
        public string TelemetryType { get; set; } = "Lap Position";
    }
}
