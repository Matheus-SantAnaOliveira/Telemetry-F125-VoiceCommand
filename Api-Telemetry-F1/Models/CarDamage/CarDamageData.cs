namespace Api_Telemetry_F1.Models.CarDamage
{
    public class CarDamageData
    {
        public float[] TyresWear { get; set; } = new float[4];
        public float TyreWearFrontLeft { get; set; }
        public float TyreWearFrontRight { get; set; }
        public float TyreWearRearLeft { get; set; }
        public float TyreWearRearRight { get; set; }
        public byte[] TyresDamage { get; set; } = new byte[4];
        public byte TyreDamageFrontLeft { get; set; }
        public byte TyreDamageFrontRight { get; set; }
        public byte TyreDamageRearLeft { get; set; }
        public byte TyreDamageRearRight { get; set; }
        public byte[] BrakesDamage { get; set; } = new byte[4];
        public byte BrakeDamageFrontLeft { get; set; }
        public byte BrakeDamageFrontRight { get; set; }
        public byte BrakeDamageRearLeft { get; set; }
        public byte BrakeDamageRearRight { get; set; }
        public byte[] TyreBlisters { get; set; } = new byte[4];
        public byte TyreBlisterFrontLeft { get; set; }
        public byte TyreBlisterFrontRight { get; set; }
        public byte TyreBlisterRearLeft { get; set; }
        public byte TyreBlisterRearRight { get; set; }
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
