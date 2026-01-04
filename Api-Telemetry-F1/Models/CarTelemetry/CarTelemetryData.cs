namespace Api_Telemetry_F1.Models.CarTelemetry
{
    public class CarTelemetryData
    {
        public ushort Speed { get; set; }                 
        public float Throttle { get; set; }            
        public float Steer { get; set; }                  
        public float Brake { get; set; }               
        public byte Clutch { get; set; }                  
        public sbyte Gear { get; set; }                 
        public ushort EngineRPM { get; set; }              
        public byte Drs { get; set; }                 
        public string DrsDesc { get; set; }
        public byte RevLightsPercent { get; set; }         
        public ushort RevLightsBitValue { get; set; }     
        public ushort[] BrakesTemperature { get; set; } = new ushort[4];
        public byte[] TyresSurfaceTemperature { get; set; } = new byte[4];
        public byte[] TyresInnerTemperature { get; set; } = new byte[4];
        public ushort EngineTemperature { get; set; }     
        public float[] TyresPressure { get; set; } = new float[4];
        public byte[] SurfaceType { get; set; } = new byte[4];
        public string DriverName { get; set; }
        public string DriverTeam { get; set; }
        public DateTime ReceivedAt { get; set; }
    }
}
