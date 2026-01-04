using F1VoiceDashboardWorker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace F1VoiceDashboardWorker.Utils
{
    public static class CommandExecuteHelper
    {
        public static void ExecutarComando(string text, Dictionary<string, string> comands, ref int desiredMonitor, ref bool waitingMOnitor)
        {
            text = text.Trim().ToLowerInvariant();

            if (waitingMOnitor)
            {
                desiredMonitor = MonitorControllerService.SetMonitorFromVoiceCommand(text, ref waitingMOnitor);
                return;
            }

            foreach (var cmd in comands)
            {
                if (text.Contains(cmd.Key.ToLowerInvariant()))
                {
                    if (cmd.Value == "FECHAR_NAVEGADOR")
                    {
                        Console.WriteLine("COMANDO - Fechando navegador!");
                        BrowserControllerService.CloseDashboard();
                    }
                    else if (cmd.Value == "ALTERAR_MONITOR")
                    {
                        MonitorControllerService.SetForMonitorChange(ref waitingMOnitor);
                    }
                    else if (cmd.Value == "LIMPAR")
                    {
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine($"COMANDO - Abrindo dashboard: {cmd.Key}");
                        BrowserControllerService.OpenDashboardAsync(cmd.Value, desiredMonitor);
                    }
                    return;
                }
            }

            Console.WriteLine($"[NÃO RECONHECIDO] - '{text}'");
        }

    }
}
