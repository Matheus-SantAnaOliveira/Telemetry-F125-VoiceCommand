namespace Api_Telemetry_F1.Models.FinalClassification
{
    public class FinalClassificationData
    {
        public byte Position { get; set; }
        public byte NumLaps { get; set; }
        public byte GridPosition { get; set; }
        public byte Points { get; set; }
        public byte NumPitStops { get; set; }
        public byte ResultStatus { get; set; }
        public string ResultStatusDescription { get; set; }
        public byte ResultReason { get; set; }
        public string ResultReasonDescription { get; set; }
        public uint BestLapTimeInMS { get; set; }
        public double TotalRaceTime { get; set; }
        public byte PenaltiesTime { get; set; }
        public byte NumPenalties { get; set; }
        public byte NumTyreStints { get; set; }
        public byte[] TyreStintsActual { get; set; } = new byte[8];
        public byte[] TyreStintsVisual { get; set; } = new byte[8];
        public byte[] TyreStintsEndLaps { get; set; } = new byte[8];
        public string DriverName { get; set; }
        public string DriverTeam { get; set; }
        public DateTime ReceivedAt { get; set; }
    }
}
