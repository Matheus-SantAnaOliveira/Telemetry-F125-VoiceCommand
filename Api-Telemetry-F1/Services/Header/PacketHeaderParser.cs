using Api_Telemetry_F1.TelemetryUtils;

namespace Api_Telemetry_F1.Models.Header
{
    public class PacketHeaderParser
    {
        public static PacketHeader ParseHeader(byte[] data)
        {
            PacketHeader header = new PacketHeader();
            int index = 0;

            header.PacketFormat = BitConverter.ToUInt16(data, index); index += 2;
            header.GameYear = data[index++];
            header.GameMajorVersion = data[index++];
            header.GameMinorVersion = data[index++];
            header.PacketVersion = data[index++];
            header.PacketId = data[index++];
            header.packetIdDesc = TranslateByteType.PacketIdType(header.PacketId);
            header.SessionUID = BitConverter.ToUInt64(data, index); index += 8;
            header.SessionTime = BitConverter.ToSingle(data, index); index += 4;
            header.FrameIdentifier = BitConverter.ToUInt32(data, index); index += 4;
            header.OverallFrameIdentifier = BitConverter.ToUInt32(data, index); index += 4;
            header.PlayerCarIndex = data[index++];
            header.SecondaryPlayerCarIndex = data[index++];
            Console.WriteLine($"Header parsed. Bytes lidos: {index}/{data.Length}");
            return header;
        }
    }
}
