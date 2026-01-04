namespace Api_Telemetry_F1.Models.CarDamage
{
    public class CarDamageData
    {
        public float[] TyresWear { get; set; } = new float[4];
        public byte[] TyresDamage { get; set; } = new byte[4];
        public byte[] BrakesDamage { get; set; } = new byte[4];
        public byte[] TyreBlisters { get; set; } = new byte[4];
        public byte FrontLeftWingDamage { get; set; }
        public byte FrontRightWingDamage { get; set; }
        public byte RearWingDamage { get; set; }
        public byte FloorDamage { get; set; }
        public byte DiffuserDamage { get; set; }
        public byte SidepodDamage { get; set; }
        public byte DRSFault { get; set; }
        public string DRSFaultDescription { get; set; }
        public byte ERSFault { get; set; }
        public string ERSFaultDescription { get; set; }
        public byte GearboxDamage { get; set; }
        public byte EngineDamage { get; set; }
        public byte EngineMGUHWear { get; set; }
        public byte EngineESWear { get; set; }
        public byte EngineCEWear { get; set; }
        public byte EngineICEWear { get; set; }
        public byte EngineMGUKWear { get; set; }
        public byte EngineTCWear { get; set; }
        public byte EngineBlown { get; set; }
        public string EngineBlownDescription { get; set; }
        public byte EngineSeized { get; set; }
        public string EngineSeizedDescription { get; set; }
        public string DriverName { get; set; }
        public string DriverTeam { get; set; }
        public DateTime ReceivedAt { get; set; }
    }
}
