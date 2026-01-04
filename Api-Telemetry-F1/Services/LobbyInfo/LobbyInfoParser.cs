using Api_Telemetry_F1.Common;
using Api_Telemetry_F1.Elastic;
using Api_Telemetry_F1.TelemetryUtils;
using System.Text;

namespace Api_Telemetry_F1.Models.LobbyInfo
{
    public class LobbyInfoParser
    {
        private static LobbyInfoData LobbyInfoIndidualParse(byte[] data, ref int index)
        {
            LobbyInfoData lobbyData = new LobbyInfoData();
            lobbyData.EventDate = DateTime.UtcNow;
            lobbyData.AiControlled = data[index++];
            lobbyData.AiControlledDescription = TranslateByteType.AiControlled(lobbyData.AiControlled);
            lobbyData.TeamId = data[index++];
            lobbyData.TeamName = TeamNameMapping.GetTeamName(lobbyData.TeamId);
            lobbyData.Nationality = data[index++];
            lobbyData.CountryNameEn = CoutryIdMapping.GetCountryNameEn(lobbyData.Nationality);
            lobbyData.CountryNamePtBr = CoutryIdMapping.GetCountryNamePtBr(lobbyData.Nationality);
            lobbyData.NationalityNameEn = CoutryIdMapping.GetNationalityEn(lobbyData.Nationality);
            lobbyData.NationalityNamePtBr = CoutryIdMapping.GetNationalityPtBr(lobbyData.Nationality);
            lobbyData.Platform = data[index++];
            lobbyData.PlatformDescription = TranslateByteType.Plataform(lobbyData.Platform);
            byte[] nameBytes = new byte[32];
            Array.Copy(data, index, nameBytes, 0, 32);
            index += 32;
            lobbyData.Name = Encoding.UTF8.GetString(nameBytes).TrimEnd('\0');
            lobbyData.CarNumber = data[index++];
            lobbyData.YourTelemetry = data[index++];
            lobbyData.YourTelemetryDescription = TranslateByteType.TelemetryHab(lobbyData.YourTelemetry);
            lobbyData.ShowOnlineNames = data[index++];
            lobbyData.ShowOnlineNamesDescription = TranslateByteType.ShowOnlineName(lobbyData.ShowOnlineNames);
            lobbyData.TechLevel = BitConverter.ToUInt16(data, index); index += 2;
            lobbyData.ReadyStatus = data[index++];
            lobbyData.ReadyStatusDescription = TranslateByteType.ReadyStatus(lobbyData.ReadyStatus);

            return lobbyData;
        }
        public static PacketLobbyInfoData PacketLobbyInfoParse(byte[] data, List<CachedDriversInfo> driversInfos, ElasticClientWrapper elkClient)
        {
            PacketLobbyInfoData packet = new PacketLobbyInfoData();
            int index = 0;

            packet.NumPlayers = data[index++];
            packet.LobbyPlayers = new List<LobbyInfoData>();

            for (int i = 0; i < 22; i++)
            {
                var lobbyPlayer = LobbyInfoParser.LobbyInfoIndidualParse(data,ref index);
                elkClient.Client.Index(lobbyPlayer, req => req.Index("telemetryf1-data-lobby-info-individual"));
                packet.LobbyPlayers.Add(lobbyPlayer);
            }
            return packet;
        }
    }
}
