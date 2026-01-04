namespace Api_Telemetry_F1.Models.SessionHistory
{
    public class PacketSessionHistory
    {
        public DateTime EventDate { get; set; }
        public string TelemetryType { get; set; } = "Session History";
        public byte CarIdx { get; set; }
        public string DriverName { get; set; }
        public string DriverTeam { get; set; }
        public byte NumLaps { get; set; }
        public byte NumTyreStints { get; set; }
        public byte BestLapNum { get; set; }
        public byte BestS1LapNum { get; set; }
        public byte BestS2LapNum { get; set; }
        public byte BestS3LapNum { get; set; }
        public List<LapHistoryData> Laps { get; set; } = new();
        public List<TyreStintHistoryData> TyreStints { get; set; } = new();
    }
}
