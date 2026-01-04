namespace Api_Telemetry_F1.Models.CarSetup
{
    public class PacketCarSetup
    {
        public DateTime EventDate { get; set; }
        public List<CarSetupData> Setups { get; set; } = new();
        public string TelemetryType { get; set; } = "Car Setup Data";
        public float NextFrontWing { get; set; }
    }
}
