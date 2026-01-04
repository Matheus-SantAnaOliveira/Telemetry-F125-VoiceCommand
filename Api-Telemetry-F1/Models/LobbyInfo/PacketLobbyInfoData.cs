namespace Api_Telemetry_F1.Models.LobbyInfo
{
    public class PacketLobbyInfoData
    {
        public byte NumPlayers;
        public List<LobbyInfoData> LobbyPlayers;
        public string TelemetryType = "LobbyInfo";
    }
}
