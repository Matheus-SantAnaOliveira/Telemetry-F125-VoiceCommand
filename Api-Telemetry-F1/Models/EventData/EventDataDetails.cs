namespace Api_Telemetry_F1.Models.EventData
{
    public class EventDataDetails
    {
        public FastestLapData? FastestLap = null;
        public RetirementData? Retirement = null;
        public DRSDisabledData? DRSDisabled = null;
        public TeamMateInPitsData? TeamMateInPits = null;
        public RaceWinnerData? RaceWinner = null;
        public PenaltyData? Penalty = null;
        public SpeedTrapData? SpeedTrap = null;
        public StartLightsData? StartLights = null;
        public DriveThroughData? DriveThroughPenaltyServed = null;
        public StopGoData? StopGoPenaltyServed = null;
        public FlashbackData? Flashback = null;
        public ButtonsData? Buttons = null;
        public OvertakeData? Overtake = null;
        public SafetyCarData? SafetyCar = null;
        public CollisionData? Collision = null;

        public struct FastestLapData
        {
            public byte VehicleIdx;
            public string driverName;
            public string driverTeam;
            public float LapTime;
        }

        public struct RetirementData
        {
            public byte VehicleIdx;
            public string driverName;
            public string driverTeam;
            public byte Reason;
            public string ReasonDesc;
        }

        public struct DRSDisabledData
        {
            public byte Reason;
            public string ReasonDesc;
        }

        public struct TeamMateInPitsData
        {
            public byte VehicleIdx;
            public string driverName;
            public string driverTeam;
        }

        public struct RaceWinnerData
        {
            public byte VehicleIdx;
            public string driverName;
            public string driverTeam;
        }

        public struct PenaltyData
        {
            public byte PenaltyType;
            public string PenaltyTypeDesc;
            public byte InfringementType;
            public string InfringementTypeDesc;
            public byte VehicleIdx;
            public string driverName1;
            public string driverTeam1;
            public byte OtherVehicleIdx;
            public string OtherDriverName2;
            public string OtherdriverTeam2;
            public byte Time;
            public byte LapNum;
            public byte PlacesGained;
        }

        public struct SpeedTrapData
        {
            public byte VehicleIdx;
            public string driverName;
            public string driverTeam;
            public float Speed;
            public byte IsOverallFastestInSession;
            public byte IsDriverFastestInSession;
            public byte FastestVehicleIdxInSession;
            public float FastestSpeedInSession;
        }

        public struct StartLightsData
        {
            public byte NumLights;
        }

        public struct DriveThroughData
        {
            public byte VehicleIdx;
            public string driverName;
            public string driverTeam;
        }

        public struct StopGoData
        {
            public byte VehicleIdx;
            public string driverName;
            public string driverTeam;
            public float StopTime;
        }

        public struct FlashbackData
        {
            public uint FlashbackFrameIdentifier;
            public float FlashbackSessionTime;
        }

        public struct ButtonsData
        {
            public uint ButtonStatus;
            public List<string> ButtonStatusDesc;
        }

        public struct OvertakeData
        {
            public byte OvertakingVehicleIdx;
            public string OvertakeDriverName;
            public string OvertakeDriverTeam;
            public byte BeingOvertakenVehicleIdx;
            public string BeingOvertakenDriverName;
            public string BeingOvertakenDriverTeam;
        }

        public struct SafetyCarData
        {
            public byte SafetyCarType;
            public string SafetyCarTypeDesc;
            public byte EventType;
            public string EventTypeDesc;
        }

        public struct CollisionData
        {
            public byte Vehicle1Idx;
            public string driverName1;
            public string driverTeam1;
            public byte Vehicle2Idx;
            public string driverName2;
            public string driverTeam2;
        }
    }
}
