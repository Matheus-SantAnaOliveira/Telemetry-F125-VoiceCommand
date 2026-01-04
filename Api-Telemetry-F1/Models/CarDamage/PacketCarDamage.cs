namespace Api_Telemetry_F1.Models.CarDamage
{
    public class PacketCarDamage
    {
        public DateTime EventDate { get; set; }
        public string TelemetryType { get; set; } = "Car Damage";
        public List<CarDamageData> DamageList { get; set; } = new();
    }

}
