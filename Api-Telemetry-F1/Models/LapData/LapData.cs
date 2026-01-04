namespace Api_Telemetry_F1.Models.LapData
{
    public class LapDataSingle
    {
        public uint LastLapTimeInMS { get; set; }
        public uint CurrentLapTimeInMS { get; set; }
        public ushort Sector1TimeMSPart { get; set; }
        public byte Sector1TimeMinutesPart { get; set; }
        public ushort Sector2TimeMSPart { get; set; }
        public byte Sector2TimeMinutesPart { get; set; }
        public ushort DeltaToCarInFrontMSPart { get; set; }
        public byte DeltaToCarInFrontMinutesPart { get; set; }
        public ushort DeltaToRaceLeaderMSPart { get; set; }
        public byte DeltaToRaceLeaderMinutesPart { get; set; }
        public float LapDistance { get; set; }
        public float TotalDistance { get; set; }
        public float SafetyCarDelta { get; set; }
        public byte CarPosition { get; set; }
        public byte CurrentLapNum { get; set; }
        public byte PitStatus { get; set; }
        public string PitStatusDescription { get; set; }
        public byte NumPitStops { get; set; }
        public byte Sector { get; set; }
        public string SectorDescription { get; set; }
        public byte CurrentLapInvalid { get; set; }
        public string CurrentLapInvalidDescription => (CurrentLapInvalid == 0) ? "Valid" : "Invalid";
        public byte Penalties { get; set; }
        public byte TotalWarnings { get; set; }
        public byte CornerCuttingWarnings { get; set; }
        public byte NumUnservedDriveThroughPens { get; set; }
        public byte NumUnservedStopGoPens { get; set; }
        public byte GridPosition { get; set; }
        public byte DriverStatus { get; set; }
        public string DriverStatusDescription { get; set; }
        public byte ResultStatus { get; set; }
        public string ResultStatusDescription { get; set; }
        public byte PitLaneTimerActive { get; set; }
        public ushort PitLaneTimeInLaneInMS { get; set; }
        public ushort PitStopTimerInMS { get; set; }
        public byte PitStopShouldServePen { get; set; }
        public float SpeedTrapFastestSpeed { get; set; }
        public byte SpeedTrapFastestLap { get; set; }
        public int Sector1TimeTotalMS { get; set; }
        public int Sector2TimeTotalMS { get; set; }
        public int DeltaToCarInFrontTotalMS { get; set; }
        public int DeltaToRaceLeaderTotalMS { get; set; }
        public string DriverName { get; set; }
        public string DriverTeam { get; set; }
        public int IdDriver { get; set; }
        public DateTime receviedAt { get; set; }
    }
}
