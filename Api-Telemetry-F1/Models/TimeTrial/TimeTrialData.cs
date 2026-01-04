namespace Api_Telemetry_F1.Models.TimeTrial
{
    public class TimeTrialData
    {
        public byte CarIdx { get; set; }
        public byte TeamId { get; set; }
        public string TeamName { get; set; }
        public uint LapTimeInMS { get; set; }
        public uint Sector1TimeInMS { get; set; }
        public uint Sector2TimeInMS { get; set; }
        public uint Sector3TimeInMS { get; set; }
        public byte TractionControl { get; set; }
        public string TractionControlDescription { get; set; }
        public byte GearboxAssist { get; set; }
        public string GearboxAssistDescription { get; set; }
        public byte AntiLockBrakes { get; set; }
        public string AntiLockBrakesDescription { get; set; }
        public byte EqualCarPerformance { get; set; }
        public string EqualCarPerformanceString { get; set; }
        public byte CustomSetup { get; set; }
        public string CustomSetupDescription { get; set; }
        public byte Valid { get; set; }
        public string ValidDescription {  get; set; }

        public string DriverName { get; set; }
        public string DriverTeam { get; set; }
        public DateTime ReceivedAt { get; set; }

        public int TotalLapTimeMS =>
            (int)(Sector1TimeInMS + Sector2TimeInMS + Sector3TimeInMS);
    }
}
