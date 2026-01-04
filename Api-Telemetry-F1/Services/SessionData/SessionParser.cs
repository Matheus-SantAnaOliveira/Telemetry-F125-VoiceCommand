using Api_Telemetry_F1.Models.Header;
using Api_Telemetry_F1.TelemetryUtils;
using System.Runtime.CompilerServices;

namespace Api_Telemetry_F1.Models.SessionData
{
    public class SessionParser
    {
        public static PacketSession SessionPacketParse(byte[] data)
        {
            int index = 0;
            PacketSession packet = new PacketSession();

            packet.Weather = data[index++];
            packet.WeatherDescription = TranslateByteType.WeatherType(packet.Weather);
            packet.TrackTemperature = (sbyte)data[index++];
            packet.AirTemperature = (sbyte)data[index++];
            packet.TotalLaps = data[index++];
            packet.TrackLength = BitConverter.ToUInt16(data, index); index += 2;
            packet.SessionType = data[index++];
            packet.SessionTypeDescription = TranslateByteType.SessionType(packet.SessionType);
            packet.TrackId = (sbyte)data[index++];
            packet.Formula = data[index++];
            packet.FormulaDescription = TranslateByteType.FormulaType(packet.Formula);
            packet.SessionTimeLeft = BitConverter.ToUInt16(data, index); index += 2;
            packet.SessionDuration = BitConverter.ToUInt16(data, index); index += 2;
            packet.PitSpeedLimit = data[index++];
            packet.GamePaused = data[index++];
            packet.IsSpectating = data[index++];
            packet.SpectatorCarIndex = data[index++];
            packet.SliProNativeSupport = data[index++];
            packet.NumMarshalZones = data[index++];

            for (int i = 0; i < 21; i++)
            {
                packet.MarshalZones[i] = new MarshalZone
                {
                    ZoneStart = BitConverter.ToSingle(data, index),
                    ZoneFlag = (sbyte)data[index + 4],
                    ZoneFlagDescription = TranslateByteType.FiaFlags((sbyte)data[index + 4])
                };
                index += 5;
            }
            packet.SafetyCarStatus = data[index++];
            packet.SafetyCarStatusDescription = TranslateByteType.SafetyCarStatus(packet.SafetyCarStatus);
            packet.NetworkGame = data[index++];
            packet.NumWeatherForecastSamples = data[index++];

            for (int i = 0; i < 64; i++)
            {
                var sample = new WeatherForecastSample();

                sample.SessionType = data[index];
                sample.SessionTypeDescription = TranslateByteType.SessionType(data[index]);
                sample.TimeOffset = data[index++];
                sample.Weather = data[index];
                sample.WeatherDescription = TranslateByteType.WeatherType(data[index]);
                sample.TrackTemperature = (sbyte)data[index++];
                sample.TrackTemperatureChange = (sbyte)data[index];
                sample.TrackTemperatureChangeDescription = TranslateByteType.TemperatureChange(sample.TrackTemperatureChange);
                sample.AirTemperature = (sbyte)data[index++];
                sample.AirTemperatureChange = (sbyte)data[index];
                sample.AirTemperatureChangeDescription = TranslateByteType.TemperatureChange(sample.AirTemperatureChange);
                sample.RainPercentage = data[index++];
                packet.WeatherForecastSamples[i] = sample;
            }
            packet.ForecastAccuracy = data[index++];
            packet.ForecastAccuracyDescription = TranslateByteType.ForecastAccuracy(packet.ForecastAccuracy);
            packet.AiDifficulty = data[index++];
            packet.SeasonLinkIdentifier = BitConverter.ToUInt32(data, index); index += 4;
            packet.WeekendLinkIdentifier = BitConverter.ToUInt32(data, index); index += 4;
            packet.SessionLinkIdentifier = BitConverter.ToUInt32(data, index); index += 4;
            packet.PitStopWindowIdealLap = data[index++];
            packet.PitStopWindowLatestLap = data[index++];
            packet.PitStopRejoinPosition = data[index++];
            packet.SteeringAssist = data[index++];
            packet.BrakingAssist = data[index++];
            packet.GearboxAssist = data[index++];
            packet.PitAssist = data[index++];
            packet.PitReleaseAssist = data[index++];
            packet.ERSAssist = data[index++];
            packet.DRSAssist = data[index++];
            packet.DynamicRacingLine = data[index++];
            packet.DynamicRacingLineType = data[index++];
            packet.GameMode = data[index++];
            packet.RuleSet = data[index++];
            packet.TimeOfDay = BitConverter.ToUInt32(data, index); index += 4;
            packet.SessionLength = data[index++];
            packet.SpeedUnitsLeadPlayer = data[index++];
            packet.TemperatureUnitsLeadPlayer = data[index++];
            packet.SpeedUnitsSecondaryPlayer = data[index++];
            packet.TemperatureUnitsSecondaryPlayer = data[index++];
            packet.NumSafetyCarPeriods = data[index++];
            packet.NumVirtualSafetyCarPeriods = data[index++];
            packet.NumRedFlagPeriods = data[index++];
            packet.EqualCarPerformance = data[index++];
            packet.RecoveryMode = data[index++];
            packet.FlashbackLimit = data[index++];
            packet.SurfaceType = data[index++];
            packet.LowFuelMode = data[index++];
            packet.RaceStarts = data[index++];
            packet.TyreTemperature = data[index++];
            packet.PitLaneTyreSim = data[index++];
            packet.CarDamage = data[index++];
            packet.CarDamageRate = data[index++];
            packet.Collisions = data[index++];
            packet.CollisionsOffForFirstLapOnly = data[index++];
            packet.MpUnsafePitRelease = data[index++];
            packet.MpOffForGriefing = data[index++];
            packet.CornerCuttingStringency = data[index++];
            packet.ParcFermeRules = data[index++];
            packet.PitStopExperience = data[index++];
            packet.SafetyCar = data[index++];
            packet.SafetyCarExperience = data[index++];
            packet.FormationLap = data[index++];
            packet.FormationLapExperience = data[index++];
            packet.RedFlags = data[index++];
            packet.AffectsLicenceLevelSolo = data[index++];
            packet.AffectsLicenceLevelMP = data[index++];
            packet.NumSessionsInWeekend = data[index++];

            for (int i = 0; i < 12; i++)
            {
                packet.WeekendStructure[i] = data[index++];
            }

            packet.Sector2LapDistanceStart = BitConverter.ToSingle(data, index); index += 4;
            packet.Sector3LapDistanceStart = BitConverter.ToSingle(data, index); index += 4;
            return packet;
        }
    }
}

