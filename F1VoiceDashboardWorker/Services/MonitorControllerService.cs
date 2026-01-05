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
                Console.WriteLine($"Monitor {i + 1}: {d.DeviceName} - {d.CurrentSetting.Resolution.Width}x{d.CurrentSetting.Resolution.Height}");
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
                    case "one":
                    case "first":
                    case "1":
                    case "1st":
                        monitorNumber = 1;
                        break;

                    case "dois":
                    case "two":
                    case "second":
                    case "2":
                    case "2nd":
                        monitorNumber = 2;
                        break;

                    case "tres":
                    case "três":
                    case "three":
                    case "third":
                    case "3":
                    case "3rd":
                        monitorNumber = 3;
                        break;

                    case "quatro":
                    case "four":
                    case "fourth":
                    case "4":
                    case "4th":
                        monitorNumber = 4;
                        break;

                    case "cinco":
                    case "five":
                    case "fifth":
                    case "5":
                    case "5th":
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
