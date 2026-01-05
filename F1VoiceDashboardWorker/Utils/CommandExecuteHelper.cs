using F1VoiceDashboardWorker.Services;
using F1VoiceDashboardWorker.Settings;
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
        public static void ExecuteCommand(string text, Dictionary<string, string> comands, string url, ref int desiredMonitor, ref bool waitingMOnitor)
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
                    else if(cmd.Value == "INICIAR_TELEMETRIA")
                    {
                        TelemetryApiService telemetryApiService = new TelemetryApiService(url);
                        Console.WriteLine("COMANDO - Iniciando telemetria!");
                        telemetryApiService.StartTelemetry();
                    }
                    else if (cmd.Value == "PARAR_TELEMETRIA")
                    {
                        TelemetryApiService telemetryApiService = new TelemetryApiService(url);
                        Console.WriteLine("COMANDO - Parando telemetria!");
                        telemetryApiService.StopTelemetry();
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
