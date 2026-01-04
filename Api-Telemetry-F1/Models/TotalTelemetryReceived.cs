using Api_Telemetry_F1.Models.CarDamage;
using Api_Telemetry_F1.Models.CarSetup;
using Api_Telemetry_F1.Models.CarStatus;
using Api_Telemetry_F1.Models.CarTelemetry;
using Api_Telemetry_F1.Models.EventData;
using Api_Telemetry_F1.Models.FinalClassification;
using Api_Telemetry_F1.Models.Header;
using Api_Telemetry_F1.Models.LapData;
using Api_Telemetry_F1.Models.LapPosition;
using Api_Telemetry_F1.Models.LobbyInfo;
using Api_Telemetry_F1.Models.Motion;
using Api_Telemetry_F1.Models.MotionEx;
using Api_Telemetry_F1.Models.ParticipantsPackage;
using Api_Telemetry_F1.Models.SessionData;
using Api_Telemetry_F1.Models.SessionHistory;
using Api_Telemetry_F1.Models.TimeTrial;
using Api_Telemetry_F1.Models.TyreSet;

namespace Api_Telemetry_F1.Models
{
    public class TotalTelemetryReceived
    {
        // ordem dos bytes no header - seguindo documentação EA
        public PacketHeader PacketHeader { get; set; }
        public PacketMotion? MotionPacket { get; set; } = null;
        public PacketSession? SessionPacket { get; set; } = null;
        public PacketLapData? LapDataPacket { get; set; } = null;
        public PacketEventData? EventDataPacket { get; set; } = null;
        public PacketParticipantsInfo? ParticipantsInfoPacket { get; set; } = null;
        public PacketCarSetup? CarSetupPacket { get; set; } = null;
        public PacketTelemetryCar? CarTelemetryPacket { get; set; } = null;
        public PacketCarStatus? CarStatusPacket { get; set; } = null;
        public PacketFinalClassification? FinalClassificationPacket { get; set; } = null;
        public PacketLobbyInfoData? LobbyInfoDataPacket { get; set; } = null;
        public PacketCarDamage? CarDamagePacket { get; set; } = null;
        public PacketSessionHistory? SessionHistoryPacket { get; set; } = null;
        public PacketTyreSetsData? TyreSetDataPacket { get; set; } = null;
        public PacketMotionEx? MotionExPacket { get; set; } = null;
        public PacketTimeTrial? TimeTrialPacket { get; set; }
        public PacketLapPosition? LapPositionPacket { get; set; }
    }
}
