using Nest;

namespace Api_Telemetry_F1.TelemetryUtils
{
    public class TranslateByteType
    {
        private static readonly Dictionary<uint, string> _buttonFlags = new()
        {
        { 0x00000001, "Cross / A" },
        { 0x00000002, "Triangle / Y" },
        { 0x00000004, "Circle / B" },
        { 0x00000008, "Square / X" },
        { 0x00000010, "D-Pad Left" },
        { 0x00000020, "D-Pad Right" },
        { 0x00000040, "D-Pad Up" },
        { 0x00000080, "D-Pad Down" },
        { 0x00000100, "Options / Menu" },
        { 0x00000200, "L1 / LB" },
        { 0x00000400, "R1 / RB" },
        { 0x00000800, "L2 / LT" },
        { 0x00001000, "R2 / RT" },
        { 0x00002000, "Left Stick Click" },
        { 0x00004000, "Right Stick Click" },
        { 0x00008000, "Right Stick Left" },
        { 0x00010000, "Right Stick Right" },
        { 0x00020000, "Right Stick Up" },
        { 0x00040000, "Right Stick Down" },
        { 0x00080000, "Special" },
        { 0x00100000, "UDP Action 1" },
        { 0x00200000, "UDP Action 2" },
        { 0x00400000, "UDP Action 3" },
        { 0x00800000, "UDP Action 4" },
        { 0x01000000, "UDP Action 5" },
        { 0x02000000, "UDP Action 6" },
        { 0x04000000, "UDP Action 7" },
        { 0x08000000, "UDP Action 8" },
        { 0x10000000, "UDP Action 9" },
        { 0x20000000, "UDP Action 10" },
        { 0x40000000, "UDP Action 11" },
        { 0x80000000, "UDP Action 12" }
        };
        public static string PacketIdType(byte type)
        {
            return type switch
            {
                0 => "Motion",
                1 => "Session",
                2 => "Lap Data",
                3 => "Event",
                4 => "Participants",
                5 => "Car Setups",
                6 => "Car Telemetry",
                7 => "Car Status",
                8 => "Final Classification",
                9 => "Lobby Info",
                10 => "Car Damage",
                11 => "Session Histry",
                12 => "Tyre Sets",
                13 => "Motion EX",
                14 => "Time Trial",
                15 => "Lap Position",

                _ => "Unknown"
            };
        }
        public static string RetirementReason(byte value)
        {
            switch (value)
            {
                case 0:
                    return "invalid";
                case 1:
                    return "retired";
                case 2:
                    return "finished";
                case 3:
                    return "terminal damage";
                case 4:
                    return "inactive";
                case 5:
                    return "not enough laps completed";
                case 6:
                    return "black flagged";
                case 7:
                    return "red flagged";
                case 8:
                    return "mechanical failure";
                case 9:
                    return "session skipped";
                case 10:
                    return "session simulated";
                default:
                    return $"unknown: {value}";
            }
        }
        public static string DrsReason(byte value)
        {
            switch (value)
            {
                case 0:
                    return "Wet Track";
                case 1:
                    return "Safety car deployed";
                case 2:
                    return "Red flag";
                case 3:
                    return "Min lap not reached";
                default:
                    return $"unknown: {value}";
            }
        }
        public static string PenaltyType(byte value)
        {
            switch (value)
            {
                case 0: return "Drive through";
                case 1: return "Stop Go";
                case 2: return "Grid penalty";
                case 3: return "Penalty reminder";
                case 4: return "Time penalty";
                case 5: return "Warning";
                case 6: return "Disqualified";
                case 7: return "Removed from formation lap";
                case 8: return "Parked too long timer";
                case 9: return "Tyre regulations";
                case 10: return "This lap invalidated";
                case 11: return "This and next lap invalidated";
                case 12: return "This lap invalidated without reason";
                case 13: return "This and next lap invalidated without reason";
                case 14: return "This and previous lap invalidated";
                case 15: return "This and previous lap invalidated without reason";
                case 16: return "Retired";
                case 17: return "Black flag timer";
                default: return "Unknown penalty type";
            }
        }
        public static string InfringementType(byte value)
        {
            switch (value)
            {
                case 0: return "Blocking by slow driving";
                case 1: return "Blocking by wrong way driving";
                case 2: return "Reversing off the start line";
                case 3: return "Big Collision";
                case 4: return "Small Collision";
                case 5: return "Collision failed to hand back position single";
                case 6: return "Collision failed to hand back position multiple";
                case 7: return "Corner cutting gained time";
                case 8: return "Corner cutting overtake single";
                case 9: return "Corner cutting overtake multiple";
                case 10: return "Crossed pit exit lane";
                case 11: return "Ignoring blue flags";
                case 12: return "Ignoring yellow flags";
                case 13: return "Ignoring drive through";
                case 14: return "Too many drive throughs";
                case 15: return "Drive through reminder serve within n laps";
                case 16: return "Drive through reminder serve this lap";
                case 17: return "Pit lane speeding";
                case 18: return "Parked for too long";
                case 19: return "Ignoring tyre regulations";
                case 20: return "Too many penalties";
                case 21: return "Multiple warnings";
                case 22: return "Approaching disqualification";
                case 23: return "Tyre regulations select single";
                case 24: return "Tyre regulations select multiple";
                case 25: return "Lap invalidated corner cutting";
                case 26: return "Lap invalidated running wide";
                case 27: return "Corner cutting ran wide gained time minor";
                case 28: return "Corner cutting ran wide gained time significant";
                case 29: return "Corner cutting ran wide gained time extreme";
                case 30: return "Lap invalidated wall riding";
                case 31: return "Lap invalidated flashback used";
                case 32: return "Lap invalidated reset to track";
                case 33: return "Blocking the pitlane";
                case 34: return "Jump start";
                case 35: return "Safety car to car collision";
                case 36: return "Safety car illegal overtake";
                case 37: return "Safety car exceeding allowed pace";
                case 38: return "Virtual safety car exceeding allowed pace";
                case 39: return "Formation lap below allowed speed";
                case 40: return "Formation lap parking";
                case 41: return "Retired mechanical failure";
                case 42: return "Retired terminally damaged";
                case 43: return "Safety car falling too far back";
                case 44: return "Black flag timer";
                case 45: return "Unserved stop go penalty";
                case 46: return "Unserved drive through penalty";
                case 47: return "Engine component change";
                case 48: return "Gearbox change";
                case 49: return "Parc Fermé change";
                case 50: return "League grid penalty";
                case 51: return "Retry penalty";
                case 52: return "Illegal time gain";
                case 53: return "Mandatory pitstop";
                case 54: return "Attribute assigned";
                default: return "Unknown infringement type";
            }
        }
        public static string SafetyCarType(byte value)
        {
            switch (value)
            {
                case 0: return "No Safety Car";
                case 1: return "Full Safety Car";
                case 2: return "Virtual Safety Car";
                case 3: return "Formation Lap Safety Car";
                default: return "Unknown Safety Car type";
            }
        }
        public static string SafetyCarStatus(byte value)
        {
            switch (value)
            {
                case 0: return "Deployed";
                case 1: return "Returning";
                case 2: return "Returned";
                case 3: return "Resume Race";
                default: return "Unknown Safety Car status";
            }
        }

        public static string AiControlled(byte value)
        {
            switch (value)
            {
                case 0: return "Human";
                case 1: return "Ia";
                default: return "Unknown: " + value;
            }
        }
        public static string Plataform(byte value)
        {
            switch (value)
            {
                case 1: return "Steam";
                case 3: return "PlayStation";
                case 4: return "Xbox";
                case 6: return "Origin";
                case 255: return "unknown";
                default: return "Unknown2: " + value;
            }
        }
        public static string TelemetryHab(byte value)
        {
            switch (value)
            {
                case 0: return "Restricted";
                case 1: return "Public";
                default: return "Unknown: " + value;
            }
        }
        public static string ShowOnlineName(byte value)
        {
            switch (value)
            {
                case 0: return "Off";
                case 1: return "On";
                default: return "Unknown: " + value;
            }
        }
        public static string ReadyStatus(byte value)
        {
            switch (value)
            {
                case 0: return "Not Ready";
                case 1: return "Ready";
                case 2: return "Speacting";
                default: return "Unknown: " + value;
            }
        }
        public static string MyTeamFlag(byte value)
        {
            switch (value)
            {
                case 0: return "Otherwise";
                case 1: return "My Team";
                default: return "Unknown: " + value;
            }
        }
        public static List<string> GetPressedButtons(uint buttonStatus)
        {
            var result = new List<string>();

            foreach (var kvp in _buttonFlags)
            {
                if ((buttonStatus & kvp.Key) != 0)
                    result.Add(kvp.Value);
            }

            return result;
        }
        public static string PitStatus(byte value)
        {
            return value switch
            {
                0 => "None",
                1 => "Pitting",
                2 => "In Pit Area",
                _ => "Unknown"
            };
        }

        public static string Sector(byte value)
        {
            return value switch
            {
                0 => "Sector 1",
                1 => "Sector 2",
                2 => "Sector 3",
                _ => "Unknown"
            };
        }

        public static string DriverStatus(byte value)
        {
            return value switch
            {
                0 => "In garage",
                1 => "Flying lap",
                2 => "In lap",
                3 => "Out lap",
                4 => "On track",
                _ => "Unknown"
            };
        }

        public static string ResultStatus(byte value)
        {
            return value switch
            {
                0 => "Invalid",
                1 => "Inactive",
                2 => "Active",
                3 => "Finished",
                4 => "DidNotFinish",
                5 => "Disqualified",
                6 => "Not Classified",
                7 => "Retired",
                _ => "Unknown"
            };
        }
        public static string ResultReason(byte value)
        {
            return value switch
            {
                0 => "Invalid",
                1 => "Retired",
                2 => "Finished",
                3 => "Terminal Damage",
                4 => "Inactive",
                5 => "Not enough laps completed",
                6 => "Black Flagged",
                7 => "Red Flagged",
                8 => "Mechanical failure",
                9 => "Session Skiped",
                10 => "Session Simulated",
                _ => "Unknown"
            };
        }
        public static string FaultIndicator(byte value)
        {
            return value switch
            {
                1 => "OK",
                2 => "Fault",
                _ => "Unknown"
            };
        }
        public static string OnOffValue(byte value) 
        {
            return value switch
            {
                0 => "Off",
                1 => "On",
                _ => "Unknown"
            };
        }
        public static string MfdPanel(byte value)
        {
            return value switch
            {
                0 => "Car Setup",
                1 => "Pits",
                2 => "Damage",
                3 => "Engine",
                4 => "Temperatures",
                255 => "MFD closed",
                _ => "Unknown"
            };
        }
        public static string TractionControl(byte value)
        {
            return value switch
            {
                0 => "Off",
                1 => "Medium",
                2 => "Full",
                _ => "Unknown"
            };
        }
        public static string FuelMix(byte value)
        {
            return value switch
            {
                0 => "Lean",
                1 => "Standart",
                2 => "Rich",
                3 => "Max",
                _ => "Unknown"
            };
        }
        public static string DrsAllowed(byte value)
        {
            return value switch
            {
                0 => "Not Allowed",
                1 => "Allowed",
                _ => "Unknown"
            };
        }
        public static string TyreCompound(byte value)
        {
            return value switch
            {
                // F1 Modern
                16 => "C5 (Softest)",
                17 => "C4",
                18 => "C3",
                19 => "C2",
                20 => "C1 (Hardest)",
                21 => "C0",          
                22 => "C6",          
                7 => "Intermediate",
                8 => "Wet",
                9 => "Dry (Classic)",
                10 => "Wet (Classic)",
                11 => "Super Soft (F2)",
                12 => "Soft (F2)",
                13 => "Medium (F2)",
                14 => "Hard (F2)",
                15 => "Wet (F2)",
                _ => "Unknown: " + value,
            };
        }
        public static string VisualTyreCompound(byte value)
        {
            return value switch
            {
                16 => "Soft",
                17 => "Medium",
                18 => "Hard",
                7 => "Intermediate",
                8 => "Wet",
                19 => "Super Soft (F2)",
                20 => "Soft (F2)",
                21 => "Medium (F2)",
                22 => "Hard (F2)",
                15 => "Wet (F2)",
                _ => "Unknown: " + value,
            };
        }
        public static string FiaFlags(sbyte value)
        {
            return value switch
            {
                -1 => "Invalid/Unknown",
                0 => "None",
                1 => "Green",
                2 => "Blue",
                3 => "Yellow",
                _ => "Unknown"
            };
        }
        public static string DeployMode(byte value)
        {
            return value switch
            {
                0 => "None",
                1 => "Medium",
                2 => "HotLap",
                3 => "OverTake",
                _ => "Unknown"
            };
        }
        public static string SessionType(byte type)
        {
            return type switch
            {
                0 => "Unknown",
                1 => "Practice 1",
                2 => "Practice 2",
                3 => "Practice 3",
                4 => "Short Practice",
                5 => "Qualifying 1",
                6 => "Qualifying 2",
                7 => "Qualifying 3",
                8 => "Short Qualifying",
                9 => "One-Shot Qualifying",
                10 => "Sprint Shootout 1",
                11 => "Sprint Shootout 2",
                12 => "Sprint Shootout 3",
                13 => "Short Sprint Shootout",
                14 => "One-Shot Sprint Shootout",
                15 => "Race",
                16 => "Race 2",
                17 => "Race 3",
                18 => "Time Trial",
                _ => "Unknown"
            };
        }
        public static string WeatherType(byte weather)
        {
            return weather switch
            {
                0 => "Clear",
                1 => "Light Cloud",
                2 => "Overcast",
                3 => "Light Rain",
                4 => "Heavy Rain",
                5 => "Storm",
                _ => "Unknown"
            };
        }
        public static string TemperatureChange(sbyte change)
        {
            return change switch
            {
                0 => "Up",
                1 => "Down",
                2 => "No Change",
                _ => "Unknown"
            };
        }
        public static string ForecastAccuracy(byte accuracy)
        {
            return accuracy switch
            {
                0 => "Perfect",
                1 => "Approximate",
                _ => "Unknown"
            };
        }
        public static string FormulaType(byte formula)
        {
            return formula switch
            {
                0 => "F1 Modern",
                1 => "F1 Classic",
                2 => "F2",
                3 => "F1 Generic",
                4 => "Beta",
                6 => "Esports",
                8 => "F1 World",
                9 => "F1 Elimination",
                _ => "Unknown"
            };
        }
        public static string Assist(byte accuracy)
        {
            return accuracy switch
            {
                0 => "Assist Off",
                1 => "Assist On",
                _ => "Unknown"
            };
        }
        public static string CarPerformace(byte accuracy)
        {
            return accuracy switch
            {
                0 => "Realistic",
                1 => "Equal",
                _ => "Unknown"
            };
        }
        public static string YesOrNo(byte accuracy)
        {
            return accuracy switch
            {
                0 => "No",
                1 => "Yes",
                _ => "Unknown"
            };
        }
        public static string ValidOrInvalid(byte accuracy)
        {
            return accuracy switch
            {
                0 => "Valid",
                1 => "Invalid",
                _ => "Unknown"
            };
        }
    }
}
