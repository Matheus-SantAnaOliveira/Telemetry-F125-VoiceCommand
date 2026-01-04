using Api_Telemetry_F1.Common;
using Api_Telemetry_F1.Models;
using Api_Telemetry_F1.Models.EventData;
using Api_Telemetry_F1.Models.ParticipantsPackage;
using System;
using System.Text;

namespace Api_Telemetry_F1.TelemetryUtils
{
    public class TranslatePacketEvent
    {
        public static object ParseEvent(byte[] data, string eventCode,List<CachedDriversInfo> participantsPackageInfo)
        {

            return eventCode switch
            {
                "FTLP" => ParseFastestLap(data, participantsPackageInfo),
                "RTMT" => ParseRetirement(data, participantsPackageInfo),
                "DRSD" => ParseDRSDisabled(data),
                "TMPT" => ParseTeamMateInPits(data, participantsPackageInfo),
                "RCWN" => ParseRaceWinner(data, participantsPackageInfo),
                "PENA" => ParsePenalty(data, participantsPackageInfo),
                "SPTP" => ParseSpeedTrap(data, participantsPackageInfo),
                "STLG" => ParseStartLights(data),
                "DRSP" => ParseDriveThroughServed(data, participantsPackageInfo),
                "SGSV" => ParseStopGoServed(data, participantsPackageInfo),
                "FLBK" => ParseFlashback(data),
                "BUTN" => ParseButtonStatus(data),
                "OVTK" => ParseOvertake(data, participantsPackageInfo),
                "SCAR" => ParseSafetyCar(data),
                "COLL" => ParseCollision(data, participantsPackageInfo),
                _ => null
            };
        }

        private static EventDataDetails.FastestLapData ParseFastestLap(byte[] data, List<CachedDriversInfo> participantsPackageInfo)
        {
            byte vehicleIdx = data[4];
            CachedDriversInfo driver = CachedDriversInfoExtensions.GetDriverByVehicleIdx(participantsPackageInfo, vehicleIdx);
            return new EventDataDetails.FastestLapData
            {
                VehicleIdx = vehicleIdx,
                driverName = driver?.DriverName ?? "Unknown",
                driverTeam = driver?.DriverTeam ?? "Unknown",
                LapTime = BitConverter.ToSingle(data, 5)
            };
        }

        private static EventDataDetails.RetirementData ParseRetirement(byte[] data, List<CachedDriversInfo> participantsPackageInfo)
        {
            byte vehicleIdx = data[4];
            CachedDriversInfo driver = CachedDriversInfoExtensions.GetDriverByVehicleIdx(participantsPackageInfo, vehicleIdx);
            return new EventDataDetails.RetirementData
            {
                VehicleIdx = vehicleIdx,
                Reason = data[5],
                ReasonDesc = TranslateByteType.RetirementReason(data[5])
               
            };
        }

        private static EventDataDetails.DRSDisabledData ParseDRSDisabled(byte[] data)
        {
            return new EventDataDetails.DRSDisabledData
            {
                Reason = data[4],
                ReasonDesc = TranslateByteType.DrsReason(data[4])
            };
        }

        private static EventDataDetails.TeamMateInPitsData ParseTeamMateInPits(byte[] data, List<CachedDriversInfo> participantsPackageInfo)
        {
            byte vehicleIdx = data[4];
            CachedDriversInfo driver = CachedDriversInfoExtensions.GetDriverByVehicleIdx(participantsPackageInfo, vehicleIdx);
            return new EventDataDetails.TeamMateInPitsData
            {
                VehicleIdx = vehicleIdx,
                driverName = driver?.DriverName ?? "Unknown",
                driverTeam = driver?.DriverTeam ?? "Unknown"
            };
        }

        private static EventDataDetails.RaceWinnerData ParseRaceWinner(byte[] data, List<CachedDriversInfo> participantsPackageInfo)
        {
            byte vehicleIdx = data[4];
            CachedDriversInfo driver = CachedDriversInfoExtensions.GetDriverByVehicleIdx(participantsPackageInfo, vehicleIdx);
            return new EventDataDetails.RaceWinnerData
            {
                VehicleIdx = vehicleIdx,
                driverName = driver?.DriverName ?? "Unknown",
                driverTeam = driver?.DriverTeam ?? "Unknown"
            };
        }

        private static EventDataDetails.PenaltyData ParsePenalty(byte[] data, List<CachedDriversInfo> participantsPackageInfo)
        {
            byte vehicleIdx = data[6];
            CachedDriversInfo driver = CachedDriversInfoExtensions.GetDriverByVehicleIdx(participantsPackageInfo, vehicleIdx);
            byte otherVehicleIdx = data[7];
            CachedDriversInfo otherDriver = CachedDriversInfoExtensions.GetDriverByVehicleIdx(participantsPackageInfo, otherVehicleIdx);
            return new EventDataDetails.PenaltyData
            {
                PenaltyType = vehicleIdx,
                PenaltyTypeDesc = TranslateByteType.PenaltyType(data[4]),
                InfringementType = data[5],
                InfringementTypeDesc = TranslateByteType.InfringementType(data[5]),
                VehicleIdx = vehicleIdx,
                driverName1 = driver?.DriverName ?? "Unknown",
                driverTeam1 = driver?.DriverTeam ?? "Unknown",
                OtherVehicleIdx = otherVehicleIdx,
                OtherDriverName2 = otherDriver?.DriverName ?? "Unknown",
                OtherdriverTeam2 = otherDriver?.DriverTeam ?? "Unknown",
                Time = data[8],
                LapNum = data[9],
                PlacesGained = data[10]
            };
        }

        private static EventDataDetails.SpeedTrapData ParseSpeedTrap(byte[] data, List<CachedDriversInfo> participantsPackageInfo)
        {
            byte vehicleIdx = data[4];
            CachedDriversInfo driver = CachedDriversInfoExtensions.GetDriverByVehicleIdx(participantsPackageInfo, vehicleIdx);
            return new EventDataDetails.SpeedTrapData
            {
                VehicleIdx = vehicleIdx,
                driverName = driver?.DriverName ?? "Unknown",
                driverTeam = driver?.DriverTeam ?? "Unknown",
                Speed = BitConverter.ToSingle(data, 5),
                IsOverallFastestInSession = data[9],
                IsDriverFastestInSession = data[10],
                FastestVehicleIdxInSession = data[11],
                FastestSpeedInSession = BitConverter.ToSingle(data, 12)
            };
        }

        private static EventDataDetails.StartLightsData ParseStartLights(byte[] data)
        {
            return new EventDataDetails.StartLightsData
            {
                NumLights = data[4]
            };
        }

        private static EventDataDetails.DriveThroughData ParseDriveThroughServed(byte[] data, List<CachedDriversInfo> participantsPackageInfo)
        {
            byte vehicleIdx = data[4];
            CachedDriversInfo driver = CachedDriversInfoExtensions.GetDriverByVehicleIdx(participantsPackageInfo, vehicleIdx);
            return new EventDataDetails.DriveThroughData
            {
                VehicleIdx = vehicleIdx,
                driverName = driver?.DriverName ?? "Unknown",
                driverTeam = driver?.DriverTeam ?? "Unknown"
            };
        }

        private static EventDataDetails.StopGoData ParseStopGoServed(byte[] data, List<CachedDriversInfo> participantsPackageInfo)
        {
            byte vehicleIdx = data[4];
            CachedDriversInfo driver = CachedDriversInfoExtensions.GetDriverByVehicleIdx(participantsPackageInfo, vehicleIdx);
            return new EventDataDetails.StopGoData
            {
                VehicleIdx = vehicleIdx,
                driverName = driver?.DriverName ?? "Unknown",
                driverTeam = driver?.DriverTeam ?? "Unknown",
                StopTime = BitConverter.ToSingle(data, 5)
            };
        }

        private static EventDataDetails.FlashbackData ParseFlashback(byte[] data)
        {
            return new EventDataDetails.FlashbackData
            {
                FlashbackFrameIdentifier = BitConverter.ToUInt32(data, 4),
                FlashbackSessionTime = BitConverter.ToSingle(data, 8)
            };
        }

        private static EventDataDetails.ButtonsData ParseButtonStatus(byte[] data)
        {
            return new EventDataDetails.ButtonsData
            {
                ButtonStatus = BitConverter.ToUInt32(data, 4),
                ButtonStatusDesc = TranslateByteType.GetPressedButtons(BitConverter.ToUInt32(data, 4))
            };
        }

        private static EventDataDetails.OvertakeData ParseOvertake(byte[] data, List<CachedDriversInfo> participantsPackageInfo)
        {
            byte OverthakevehicleIdx = data[4];
            CachedDriversInfo driver = CachedDriversInfoExtensions.GetDriverByVehicleIdx(participantsPackageInfo, OverthakevehicleIdx);
            byte otherVehicleIdx = data[5];
            CachedDriversInfo otherDriver = CachedDriversInfoExtensions.GetDriverByVehicleIdx(participantsPackageInfo, otherVehicleIdx);
            return new EventDataDetails.OvertakeData
            {
                OvertakingVehicleIdx = data[4],
                OvertakeDriverName = driver?.DriverName ?? "Unknown",
                OvertakeDriverTeam = driver?.DriverTeam ?? "Unknown",
                BeingOvertakenVehicleIdx = data[5],
                BeingOvertakenDriverName = otherDriver?.DriverName ?? "Unknown",
                BeingOvertakenDriverTeam = otherDriver?.DriverTeam ?? "Unknown"
            };
        }

        private static EventDataDetails.SafetyCarData ParseSafetyCar(byte[] data)
        {
            return new EventDataDetails.SafetyCarData
            {
                SafetyCarType = data[4],
                SafetyCarTypeDesc = TranslateByteType.SafetyCarType(data[4]),
                EventType = data[5],
                EventTypeDesc = TranslateByteType.SafetyCarStatus(data[5])
            };
        }

        private static EventDataDetails.CollisionData ParseCollision(byte[] data, List<CachedDriversInfo> participantsPackageInfo)
        {
            byte vehicleIdx = data[4];
            CachedDriversInfo driver = CachedDriversInfoExtensions.GetDriverByVehicleIdx(participantsPackageInfo, vehicleIdx);
            byte vehicle2Idx = data[5];
            CachedDriversInfo driver2 = CachedDriversInfoExtensions.GetDriverByVehicleIdx(participantsPackageInfo, vehicleIdx);
            return new EventDataDetails.CollisionData
            {
                Vehicle1Idx = data[4],
                driverName1 = driver?.DriverName ?? "Unknown",
                driverTeam1 = driver?.DriverTeam ?? "Unknown",
                Vehicle2Idx = data[5],
                driverName2 = driver2?.DriverName ?? "Unknown",
                driverTeam2 = driver2?.DriverTeam ?? "Unknown",
            };
        }
    }
}
