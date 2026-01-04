namespace Api_Telemetry_F1.Models.SessionData
{
    public class WeatherForecastSample
    {
        public byte SessionType { get; set; }
        public string SessionTypeDescription { get; set; }
        public byte TimeOffset { get; set; } 
        public byte Weather { get; set; }
        public string WeatherDescription { get; set; }
        public sbyte TrackTemperature { get; set; }
        public sbyte TrackTemperatureChange { get; set; }
        public string TrackTemperatureChangeDescription { get; set; }
        public sbyte AirTemperature { get; set; }
        public sbyte AirTemperatureChange { get; set; }
        public string AirTemperatureChangeDescription { get; set; }
        public byte RainPercentage { get; set; }
    }
}
