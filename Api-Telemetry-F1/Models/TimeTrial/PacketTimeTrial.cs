using Api_Telemetry_F1.Models.Header;

namespace Api_Telemetry_F1.Models.TimeTrial
{
    public class PacketTimeTrial
    {
        public PacketHeader Header { get; set; }
        public TimeTrialData PlayerSessionBest { get; set; }
        public TimeTrialData PersonalBest { get; set; }
        public TimeTrialData RivalData { get; set; }
        public string TelemetryType { get; set; } = "TimeTrial Packet";
        public DateTime EventDate { get; set; }
    }
}
