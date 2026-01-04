namespace Api_Telemetry_F1.Models.CarStatus
{
    public class CarStatusData
    {
        public byte TractionControl { get; set; }
        public string TractionControlDescription { get; set; }
        public byte AntiLockBrakes { get; set; }
        public string AntiLockBrakesDescription { get; set; }
        public byte FuelMix { get; set; }
        public string FuelMixDescription { get; set; }
        public byte FrontBrakeBias { get; set; }
        public byte PitLimiterStatus { get; set; }
        public string PitLimiterStatusDescription { get; set; }
        public float FuelInTank { get; set; }
        public float FuelCapacity { get; set; }
        public float FuelRemainingLaps { get; set; }
        public ushort MaxRPM { get; set; }
        public ushort IdleRPM { get; set; }
        public byte MaxGears { get; set; }
        public byte DrsAllowed { get; set; }
        public string DrsAllowedDescription { get; set; }
        public ushort DrsActivationDistance { get; set; }
        public byte ActualTyreCompound { get; set; }
        public string ActualTyreCompoundDesc { get; set; }
        public byte VisualTyreCompound { get; set; }
        public string VisualTyreCompoundDesc { get; set; }
        public byte TyresAgeLaps { get; set; }
        public sbyte VehicleFiaFlags { get; set; }
        public string VehicleFiaFlagsDesc { get; set; }
        public float EnginePowerICE { get; set; }
        public float EnginePowerMGUK { get; set; }
        public float ErsStoreEnergy { get; set; }
        public byte ErsDeployMode { get; set; }
        public string ErsDeployModeDescription { get; set; }
        public float ErsHarvestedThisLapMGUK { get; set; }
        public float ErsHarvestedThisLapMGUH { get; set; }
        public float ErsDeployedThisLap { get; set; }
        public byte NetworkPaused { get; set; }
        public string DriverName { get; set; }
        public string DriverTeam { get; set; }
        public DateTime ReceivedAt { get; set; }
    }
}
