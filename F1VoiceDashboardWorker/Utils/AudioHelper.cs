using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace F1VoiceDashboardWorker.Utils
{
    public static class AudioHelper
    {
        public static string ExtractText(string json)
        {
            try
            {
                using var doc = JsonDocument.Parse(json);
                if (doc.RootElement.TryGetProperty("text", out var prop))
                    return prop.GetString() ?? "";
                if (doc.RootElement.TryGetProperty("partial", out var pprop))
                    return pprop.GetString() ?? "";
            }
            catch { }
            return "";
        }
    }
}
