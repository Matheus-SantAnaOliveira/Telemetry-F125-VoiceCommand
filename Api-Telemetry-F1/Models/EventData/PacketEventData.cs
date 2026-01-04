namespace Api_Telemetry_F1.Models.EventData
{
    public class PacketEventData
    {
        public byte[] telemetryBytesInfo; 
        public string EventStringCode; 
        public EventDataDetails EventDetails;
        public string TelemetryType { get; set; }
        public DateTime EventDate  { get; set; }

    }
}
