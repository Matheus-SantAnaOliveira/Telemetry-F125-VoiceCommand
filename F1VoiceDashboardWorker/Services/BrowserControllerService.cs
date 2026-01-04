using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WindowsDisplayAPI;

namespace F1VoiceDashboardWorker.Services
{
    public static class BrowserControllerService
    {
        private const string PipeName = "F1DashboardPipe";
        private const string DashboardExeName = "F1DashboardUI";

        public static async Task OpenDashboardAsync(string url, int monitorIndex)
        {
            var payload = new { Url = url, Monitor = monitorIndex };
            string json = JsonSerializer.Serialize(payload);
            try
            {
                using var client = new NamedPipeClientStream(".", PipeName, PipeDirection.Out);
                await client.ConnectAsync(2000); 

                byte[] bytes = Encoding.UTF8.GetBytes(json);
                await client.WriteAsync(bytes, 0, bytes.Length);
                await client.FlushAsync();
                Console.WriteLine($"Dashboard atualizado: {url} no monitor {monitorIndex + 1}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao comunicar com Dashboard: {ex.Message}");
            }
        }

        public static void CloseDashboard()
        {
            var processes = Process.GetProcessesByName(DashboardExeName);
            foreach (var p in processes)
            {
                p.CloseMainWindow();
            }
        }
    }
}