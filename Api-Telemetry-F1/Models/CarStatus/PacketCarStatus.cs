namespace Api_Telemetry_F1.Models.CarStatus
{
    public class PacketCarStatus
    {
        public DateTime EventDate { get; set; }
        public List<CarStatusData> CarStatusList { get; set; } = new();
        public string TelemetryType { get; set; } = "Car Status";
    }
}
