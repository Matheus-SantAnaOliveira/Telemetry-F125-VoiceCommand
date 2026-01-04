using Api_Telemetry_F1.Common;
using Api_Telemetry_F1.Models.Header;
using Api_Telemetry_F1.Models.ParticipantsPackage;
using Api_Telemetry_F1.TelemetryUtils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api_Telemetry_F1.Services.ParticipantsPackage
{
    public class ParticipantParser
    {
        private const int MaxCars = 22;
        private const int NameLength = 32;
        private const int MaxColours = 4;
        private const int ParticipantSize = 57;

        private static bool HasRemaining(byte[] data, int index, int needed)
        {
            return data != null && index + needed <= data.Length;
        }
        public static PacketParticipantsInfo ParseParticipants(byte[] data)
        {
            var result = new PacketParticipantsInfo();
            int index = 0;
            result.ReceivedAt = DateTime.UtcNow;
            if (data == null)
            {
                return result;
            }

            try
            {
                if (!HasRemaining(data, index, 1))
                {
                    return result;
                }

                result.NumActiveCars = data[index++];
                if (result.NumActiveCars > MaxCars) result.NumActiveCars = MaxCars;

                result.Participants = new List<ParticipantModel>();

                for (int i = 0; i < MaxCars; i++)
                {
                    if (!HasRemaining(data, index, 1)) break;

                    ParticipantModel participant = new ParticipantModel();

                    if (!HasRemaining(data, index, 1)) break;
                    participant.IsAIControlled = data[index++];
                    participant.AIControlledDescription = TranslateByteType.AiControlled(participant.IsAIControlled);

                    if (!HasRemaining(data, index, 1)) break;
                    participant.DriverId = data[index++];
                    participant.DriverName = DriverIdMapping.GetDriverName(participant.DriverId);

                    if (!HasRemaining(data, index, 1)) break;
                    participant.NetworkId = data[index++];

                    if (!HasRemaining(data, index, 1)) break;
                    participant.TeamId = data[index++];
                    participant.TeamName = TeamNameMapping.GetTeamName(participant.TeamId);

                    if (!HasRemaining(data, index, 1)) break;
                    participant.MyTeam = data[index++];
                    participant.MyTeamFlagDescription = TranslateByteType.MyTeamFlag(participant.MyTeam);

                    if (!HasRemaining(data, index, 1)) break;
                    participant.RaceNumber = data[index++];

                    if (!HasRemaining(data, index, 1)) break;
                    participant.Nationality = data[index++];
                    participant.CountryNameEn = CoutryIdMapping.GetCountryNameEn(participant.Nationality);
                    participant.CountryNamePtBr = CoutryIdMapping.GetCountryNamePtBr(participant.Nationality);
                    participant.NationalityNameEn = CoutryIdMapping.GetNationalityEn(participant.Nationality);
                    participant.NationalityNamePtBr = CoutryIdMapping.GetNationalityPtBr(participant.Nationality);

                    if (!HasRemaining(data, index, NameLength))
                    {
                        int remain = Math.Max(0, data.Length - index);
                        byte[] nameBytesShort = new byte[remain];
                        if (remain > 0) Array.Copy(data, index, nameBytesShort, 0, remain);
                        participant.Name = Encoding.UTF8.GetString(nameBytesShort).TrimEnd('\0', '…');
                        index += remain;
                    }
                    else
                    {
                        byte[] nameBytes = new byte[NameLength];
                        Array.Copy(data, index, nameBytes, 0, NameLength);
                        index += NameLength;
                        participant.Name = Encoding.UTF8.GetString(nameBytes).TrimEnd('\0', '…');
                    }

                    if (!HasRemaining(data, index, 1)) break;
                    participant.YourTelemetry = data[index++];
                    participant.YourTelemetryDescription = TranslateByteType.TelemetryHab(participant.YourTelemetry);

                    if (!HasRemaining(data, index, 1)) break;
                    participant.ShowOnlineNames = data[index++];
                    participant.ShowOnlineNamesDescription = TranslateByteType.ShowOnlineName(participant.ShowOnlineNames);

                    if (!HasRemaining(data, index, 2)) break;
                    participant.TechLevel = BitConverter.ToUInt16(data, index);
                    index += 2;

                    if (!HasRemaining(data, index, 1)) break;
                    participant.Platform = data[index++];
                    participant.PlatformDescription = TranslateByteType.Plataform(participant.Platform);

                    if (!HasRemaining(data, index, 1)) break;
                    participant.NumColours = data[index++];

                    participant.LiveryColours = new List<LiveryColour>();

                    for (int c = 0; c < MaxColours; c++)
                    {
                        if (!HasRemaining(data, index, 3))
                        {
                            break;
                        }

                        var colour = new LiveryColour
                        {
                            Red = data[index++],
                            Green = data[index++],
                            Blue = data[index++]
                        };
                        participant.LiveryColours.Add(colour);
                    }

                    if (i < result.NumActiveCars)
                    {
                        result.Participants.Add(participant);
                    }
                }

                if (index != data.Length)
                {
                    Console.WriteLine($"ParseParticipants: index final {index} / data.Length {data.Length} (ok: pode haver padding)");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no Participants: {ex.Message} | index {index}/{data.Length}\n{ex}");
            }

            return result;
        }
    }
}
