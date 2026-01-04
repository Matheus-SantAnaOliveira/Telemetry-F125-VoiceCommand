namespace Api_Telemetry_F1.TelemetryUtils
{
    public class TranslateEventType
    {

        public static string GetEventType(string code)
        {
            return code switch
            {
                "SSTA" => "Session Started",
                "SEND" => "Session Ended",
                "FTLP" => "Fastest Lap",
                "RTMT" => "Retirement",
                "DRSE" => "DRS Enabled",
                "DRSD" => "DRS Disabled",
                "TMPT" => "Team Mate in Pits",
                "CHQF" => "Chequered Flag",
                "RCWN" => "Race Winner",
                "PENA" => "Penalty Issued",
                "SPTP" => "Speed Trap Triggered",
                "STLG" => "Start Lights",
                "LGOT" => "Lights Out",
                "DTSV" => "Drive Through Served",
                "SGSV" => "Stop Go Served",
                "FLBK" => "Flashback",
                "BUTN" => "Button Status",
                "RDFL" => "Red Flag",
                "OVTK" => "Overtake",
                "SCAR" => "Safety Car",
                "COLL" => "Collision",
                _ => "Unknown Event"
            };
        }
    }
}