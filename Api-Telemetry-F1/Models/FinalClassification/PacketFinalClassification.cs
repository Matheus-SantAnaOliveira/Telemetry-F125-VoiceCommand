namespace Api_Telemetry_F1.Models.FinalClassification
{
    public class PacketFinalClassification
    {
        public DateTime EventDate { get; set; }
        public byte NumCars { get; set; }
        public string TelemetryType { get; set; } = "Final Classification";
        public List<FinalClassificationData> ClassificationList { get; set; } = new();
    }
}
