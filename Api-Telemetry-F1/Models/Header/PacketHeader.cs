using Api_Telemetry_F1.TelemetryUtils;

namespace Api_Telemetry_F1.Models.Header
{
    public class PacketHeader
    {
        public ushort PacketFormat { get; set; }
        public byte GameYear { get; set; }
        public byte GameMajorVersion { get; set; }
        public byte GameMinorVersion { get; set; }
        public byte PacketVersion { get; set; }
        public byte PacketId { get; set; }
        public string packetIdDesc { get; set; }
        public ulong SessionUID { get; set; }
        public float SessionTime { get; set; }
        public uint FrameIdentifier { get; set; }
        public uint OverallFrameIdentifier { get; set; }
        public byte PlayerCarIndex { get; set; }
        public byte SecondaryPlayerCarIndex { get; set; }

    }
}