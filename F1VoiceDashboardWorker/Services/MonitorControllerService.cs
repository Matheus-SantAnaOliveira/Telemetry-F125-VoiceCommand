using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsDisplayAPI;

namespace F1VoiceDashboardWorker.Services
{
    public static class MonitorControllerService
    {
        public static void SetForMonitorChange(ref bool waitingMonitor)
        {
            var displays = Display.GetDisplays().ToList();
            Console.WriteLine($"Monitores detectados: {displays.Count}");
            for (int i = 0; i < displays.Count; i++)
            {
                var d = displays[i];
                Console.WriteLine($"  Monitor {i + 1}: {d.DeviceName} - {d.CurrentSetting.Resolution.Width}x{d.CurrentSetting.Resolution.Height}");
            }
            Console.WriteLine("\nDiga o número do monitor desejado (ex: 'dois' ou '2'):");
            waitingMonitor = true;
        }

        public static int SetMonitorFromVoiceCommand(string input, ref bool waitingMonitor)
        {

            var displays = Display.GetDisplays().ToList();
            int monitorNumber = -1;

            if (input.All(char.IsDigit))
            {
                monitorNumber = int.Parse(input);
            }
            else
            {
                switch (input.ToLower())
                {
                    case "um":
                    case "1":
                        monitorNumber = 1;
                        break;
                    case "dois":
                    case "2":
                        monitorNumber = 2;
                        break;
                    case "tres":
                    case "três":
                    case "3":
                        monitorNumber = 3;
                        break;
                    case "quatro":
                    case "4":
                        monitorNumber = 4;
                        break;
                    case "cinco":
                    case "5":
                        monitorNumber = 5;
                        break;
                    default:
                        monitorNumber = -1;
                        break;
                }
            }
            if (monitorNumber >= 1 && monitorNumber <= displays.Count)
            {
                Console.WriteLine($"Monitor alterado para: {displays[monitorNumber - 1].DeviceName}");
                waitingMonitor = false;
                return monitorNumber - 1;
            }
            else
            {
                Console.WriteLine("Número de monitor inválido. Tente novamente.");
                return -1;
            }
        }
    }
}   
