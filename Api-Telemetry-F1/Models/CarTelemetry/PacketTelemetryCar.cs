using Api_Telemetry_F1.Models.Header;

namespace Api_Telemetry_F1.Models.CarTelemetry
{
    public class PacketTelemetryCar
    {
        public PacketHeader Header { get; set; }
        public DateTime EventDate { get; set; }
        public List<CarTelemetryData> CarTelemetryData { get; set; } = new();
        public string TelemetryType { get; set; } = "Telemetry Car";
        public byte MfdPanelIndex { get; set; }     
        public string MfdPanelIndexDescription { get; set; }
        public byte MfdPanelIndexSecondaryPlayer { get; set; }
        public string MfdPanelIndexSecondaryPlayerDescription { get; set; }
        public sbyte SuggestedGear { get; set; }                 
    }
}
