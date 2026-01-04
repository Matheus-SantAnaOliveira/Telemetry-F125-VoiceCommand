namespace Api_Telemetry_F1.Models.TyreSet
{
    public class TyreSetData
    {
        public byte ActualCompound { get; set; }
        public string ActualCompoundDesc { get; set; }
        public byte VisualCompound { get; set; }
        public string VisualCompoundDesc { get; set; }
        public byte Wear { get; set; }
        public byte Available { get; set; }
        public byte RecommendedSession { get; set; }
        public byte LifeSpan { get; set; }
        public byte UsableLife { get; set; }
        public short LapDeltaTime { get; set; }
        public byte Fitted { get; set; }
    }
}
