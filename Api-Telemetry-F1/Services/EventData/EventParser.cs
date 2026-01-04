using Api_Telemetry_F1.Common;
using Api_Telemetry_F1.Models.EventData;
using Api_Telemetry_F1.TelemetryUtils;
using System.Text;

namespace Api_Telemetry_F1.Services.EventData
{
    public class EventParser
    {
        public static PacketEventData CreateObjectEvent(byte[] telemetryInfos, List<CachedDriversInfo> participantsPackageInfo)
        {
            string eventCode = Encoding.ASCII.GetString(telemetryInfos, 0, 4);
            var parsed = TranslatePacketEvent.ParseEvent(telemetryInfos, eventCode, participantsPackageInfo);

            var eventData = new PacketEventData
            {
                telemetryBytesInfo = telemetryInfos,
                EventStringCode = eventCode,
                TelemetryType = $"Event: + {eventCode}",
                EventDetails = new EventDataDetails(),
                EventDate = DateTime.UtcNow
            };

            switch (eventCode)
            {
                case "FTLP":
                    eventData.EventDetails.FastestLap = (EventDataDetails.FastestLapData)parsed;
                    break;

                case "RTMT":
                    eventData.EventDetails.Retirement = (EventDataDetails.RetirementData)parsed;
                    break;

                case "DRSD":
                    eventData.EventDetails.DRSDisabled = (EventDataDetails.DRSDisabledData)parsed;
                    break;

                case "TMPT":
                    eventData.EventDetails.TeamMateInPits = (EventDataDetails.TeamMateInPitsData)parsed;
                    break;

                case "RCWN":
                    eventData.EventDetails.RaceWinner = (EventDataDetails.RaceWinnerData)parsed;
                    break;

                case "PENA":
                    eventData.EventDetails.Penalty = (EventDataDetails.PenaltyData)parsed;
                    break;

                case "SPTP":
                    eventData.EventDetails.SpeedTrap = (EventDataDetails.SpeedTrapData)parsed;
                    break;

                case "STLG":
                    eventData.EventDetails.StartLights = (EventDataDetails.StartLightsData)parsed;
                    break;

                case "DRSP":
                    eventData.EventDetails.DriveThroughPenaltyServed = (EventDataDetails.DriveThroughData)parsed;
                    break;

                case "SGSV":
                    eventData.EventDetails.StopGoPenaltyServed = (EventDataDetails.StopGoData)parsed;
                    break;

                case "FLBK":
                    eventData.EventDetails.Flashback = (EventDataDetails.FlashbackData)parsed;
                    break;

                case "BUTN":
                    eventData.EventDetails.Buttons = (EventDataDetails.ButtonsData)parsed;
                    break;

                case "OVTK":
                    eventData.EventDetails.Overtake = (EventDataDetails.OvertakeData)parsed;
                    break;

                case "SCAR":
                    eventData.EventDetails.SafetyCar = (EventDataDetails.SafetyCarData)parsed;
                    break;

                case "COLL":
                    eventData.EventDetails.Collision = (EventDataDetails.CollisionData)parsed;
                    break;
            }
            return eventData;
        }
    }
}
