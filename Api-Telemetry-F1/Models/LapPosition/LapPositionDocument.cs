namespace Api_Telemetry_F1.Models.LapPosition
{
    public class LapPositionDocument
    {
        public DateTime EventDate { get; set; }
        public int LapNumber { get; set; }                  
        public int VehicleIdx { get; set; }
        public byte Position { get; set; }                  
        public string DriverName { get; set; } = string.Empty;
        public string DriverTeam { get; set; } = string.Empty;
    }
}
