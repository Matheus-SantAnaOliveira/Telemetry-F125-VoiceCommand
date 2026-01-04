namespace Api_Telemetry_F1.Models.TyreSet
{
    public class PacketTyreSetsData
    {
        public DateTime EventDate { get; set; }
        public byte CarIdx { get; set; }
        public string DriverName { get; set; }
        public string DriverTeam { get; set; }
        public List<TyreSetData> TyreSets { get; set; } = new();
        public string TelemetryType { get; set; } = "Tyre Set";
        public byte FittedIdx { get; set; }
    }
}
