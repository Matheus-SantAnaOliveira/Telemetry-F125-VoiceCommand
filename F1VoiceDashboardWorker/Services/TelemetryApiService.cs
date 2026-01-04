using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1VoiceDashboardWorker.Services
{
    public class TelemetryApiService
    {
        private string UrlBase;
        HttpClient _httpClient;
        public TelemetryApiService(string urlBase) {
        UrlBase = urlBase;
        _httpClient = new HttpClient
            {
                BaseAddress = new Uri(urlBase)
            };
        }

        public void StartTelemetry()
        {
            _httpClient.PostAsync("/api/telemetry/start", null);
        }

        public void StopTelemetry()
        {
            _httpClient.PostAsync("/api/telemetry/stop", null);
        }
    }
}