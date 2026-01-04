namespace Api_Telemetry_F1.Models.ParticipantsPackage
{
    public class PacketParticipantsInfo
    {
        public byte? NumActiveCars { get; set; } = null;
        public List<ParticipantModel> Participants { get; set; } = null;
        public string TelemetryType { get; set; } = "Participants Packet";
        public DateTime ReceivedAt { get; set; } = DateTime.UtcNow;
    }
}

