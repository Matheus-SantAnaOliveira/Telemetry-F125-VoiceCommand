namespace Api_Telemetry_F1.Models.SessionHistory
{
    public class LapHistoryData
    {
        public uint LapTimeInMS { get; set; }
        public ushort Sector1MS { get; set; }
        public byte Sector1Minutes { get; set; }
        public int Sector1TotalMS => Sector1Minutes * 60000 + Sector1MS;
        public ushort Sector2MS { get; set; }
        public byte Sector2Minutes { get; set; }
        public int Sector2TotalMS => Sector2Minutes * 60000 + Sector2MS;
        public ushort Sector3MS { get; set; }
        public byte Sector3Minutes { get; set; }
        public int Sector3TotalMS => Sector3Minutes * 60000 + Sector3MS;
        public byte ValidFlags { get; set; }
        public DateTime ReceivedAt { get; set; }
    }
}
