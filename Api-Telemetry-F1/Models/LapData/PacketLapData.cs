namespace Api_Telemetry_F1.Models.LapData
{
    public class PacketLapData
    {
        public string TelemetryType { get; set; } = "PacketLapData";
        public DateTime EventDate { get; set; }
        public List<LapDataSingle> LapDataList { get; set; } = new List<LapDataSingle>(22);
        public byte TimeTrialPBCarIdx { get; set; }
        public string TimeTrialPBCarDriverName { get; set; }
        public string TimeTrialPBCarDriverTeam { get; set; }
        public byte TimeTrialRivalCarIdx { get; set; }
        public string TimeTrialRivalCarDriverName { get; set; }
        public string TimeTrialRivalCarDriverTeam { get; set; }

    }
}
