using Api_Telemetry_F1.Models.Header;

namespace Api_Telemetry_F1.Models.SessionData
{
    public class PacketSession
    {
        public byte Weather { get; set; }
        public string WeatherDescription { get; set; }
        public sbyte TrackTemperature { get; set; }
        public sbyte AirTemperature { get; set; }
        public byte TotalLaps { get; set; }
        public ushort TrackLength { get; set; }
        public byte SessionType { get; set; }
        public string SessionTypeDescription { get; set; }
        public sbyte TrackId { get; set; }
        public byte Formula { get; set; }
        public string FormulaDescription { get; set; } 
        public ushort SessionTimeLeft { get; set; }
        public ushort SessionDuration { get; set; }
        public byte PitSpeedLimit { get; set; }
        public byte GamePaused { get; set; } 
        public byte IsSpectating { get; set; }
        public byte SpectatorCarIndex { get; set; }
        public byte SliProNativeSupport { get; set; }
        public byte NumMarshalZones { get; set; }
        public MarshalZone[] MarshalZones { get; set; } = new MarshalZone[21];
        public byte SafetyCarStatus { get; set; }
        public string SafetyCarStatusDescription { get; set; }
        public byte NetworkGame { get; set; } 
        public byte NumWeatherForecastSamples { get; set; }
        public WeatherForecastSample[] WeatherForecastSamples { get; set; } = new WeatherForecastSample[64];
        public byte ForecastAccuracy { get; set; }
        public string ForecastAccuracyDescription { get; set; }
        public byte AiDifficulty { get; set; }
        public uint SeasonLinkIdentifier { get; set; }
        public uint WeekendLinkIdentifier { get; set; }
        public uint SessionLinkIdentifier { get; set; }
        public byte PitStopWindowIdealLap { get; set; }
        public byte PitStopWindowLatestLap { get; set; }
        public byte PitStopRejoinPosition { get; set; }
        public byte SteeringAssist { get; set; }
        public byte BrakingAssist { get; set; }
        public byte GearboxAssist { get; set; }
        public byte PitAssist { get; set; }
        public byte PitReleaseAssist { get; set; }
        public byte ERSAssist { get; set; }
        public byte DRSAssist { get; set; }
        public byte DynamicRacingLine { get; set; }
        public byte DynamicRacingLineType { get; set; }
        public byte GameMode { get; set; }
        public byte RuleSet { get; set; }
        public uint TimeOfDay { get; set; } 
        public byte SessionLength { get; set; }
        public byte SpeedUnitsLeadPlayer { get; set; }
        public byte TemperatureUnitsLeadPlayer { get; set; }
        public byte SpeedUnitsSecondaryPlayer { get; set; }
        public byte TemperatureUnitsSecondaryPlayer { get; set; }
        public byte NumSafetyCarPeriods { get; set; }
        public byte NumVirtualSafetyCarPeriods { get; set; }
        public byte NumRedFlagPeriods { get; set; }
        public byte EqualCarPerformance { get; set; }
        public byte RecoveryMode { get; set; }
        public byte FlashbackLimit { get; set; }
        public byte SurfaceType { get; set; }
        public byte LowFuelMode { get; set; }
        public byte RaceStarts { get; set; }
        public byte TyreTemperature { get; set; }
        public byte PitLaneTyreSim { get; set; }
        public byte CarDamage { get; set; }
        public byte CarDamageRate { get; set; }
        public byte Collisions { get; set; }
        public byte CollisionsOffForFirstLapOnly { get; set; }
        public byte MpUnsafePitRelease { get; set; }
        public byte MpOffForGriefing { get; set; }
        public byte CornerCuttingStringency { get; set; }
        public byte ParcFermeRules { get; set; }
        public byte PitStopExperience { get; set; }
        public byte SafetyCar { get; set; }
        public byte SafetyCarExperience { get; set; }
        public byte FormationLap { get; set; }
        public byte FormationLapExperience { get; set; }
        public byte RedFlags { get; set; }
        public byte AffectsLicenceLevelSolo { get; set; }
        public byte AffectsLicenceLevelMP { get; set; }
        public byte NumSessionsInWeekend { get; set; }
        public byte[] WeekendStructure { get; set; } = new byte[12];
        public float Sector2LapDistanceStart { get; set; }
        public float Sector3LapDistanceStart { get; set; }
        public string TelemetryType { get; set; } = "Session Packet";
    }
}