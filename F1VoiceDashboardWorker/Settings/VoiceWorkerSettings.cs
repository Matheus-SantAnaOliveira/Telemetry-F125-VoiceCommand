using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1VoiceDashboardWorker.Settings
{
    public class VoiceWorkerSettings
    {
        public string PathModel { get; set; } = string.Empty;
        public int MonitorNumber { get; set; }
        public int MicDeviceNumber { get; set; }
    }
}
