namespace Api_Telemetry_F1.Models.ParticipantsPackage
{
    public class ParticipantModel
    {
        public byte IsAIControlled { get; set; }
        public string AIControlledDescription { get; set; } = string.Empty;
        public byte DriverId { get; set; }
        public string DriverName { get; set; } = string.Empty;
        public byte NetworkId { get; set; }
        public byte TeamId { get; set; }
        public string TeamName { get; set; }
        public byte MyTeam { get; set; }
        public string MyTeamFlagDescription { get; set; } = string.Empty;
        public byte RaceNumber { get; set; }
        public byte Nationality { get; set; }
        public string NationalityNamePtBr { get; set; } = string.Empty;
        public string NationalityNameEn { get; set; } = string.Empty;
        public string CountryNamePtBr { get; set; } = string.Empty;
        public string CountryNameEn { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public byte YourTelemetry { get; set; }
        public string YourTelemetryDescription { get; set; } = string.Empty;
        public byte ShowOnlineNames { get; set; }
        public string ShowOnlineNamesDescription { get; set; } = string.Empty;
        public ushort TechLevel { get; set; }
        public byte Platform { get; set; }
        public string PlatformDescription { get; set; } = string.Empty;
        public byte NumColours { get; set; }
        public List<LiveryColour> LiveryColours { get; set; } = new();
    }
}