using System;
using System.IO;
using System.Text.Json;

namespace Api_Telemetry_F1.JsonSave
{
    public class TelemetrySaver
    {
        private readonly string _folderPath;

        public TelemetrySaver(string folderPath)
        {
            _folderPath = folderPath;

            if (!Directory.Exists(_folderPath))
                Directory.CreateDirectory(_folderPath);
        }

        private string GetDailyFilePath(string type)
        {
            string fileName = $"telemetry_{DateTime.Now:yyyyMMdd}_{type}.json"; // só a data, sem hora
            return Path.Combine(_folderPath, fileName);
        }

        public void SaveTelemetry(object telemetryData, string telemetryType)
        {
            try
            {
                string fullPath = GetDailyFilePath(telemetryType);
                List<object> telemetryList;

                if (File.Exists(fullPath))
                {
                    string existingJson = File.ReadAllText(fullPath);
                    telemetryList = JsonSerializer.Deserialize<List<object>>(existingJson, new JsonSerializerOptions
                    {
                        IncludeFields = true
                    }) ?? new List<object>();
                }
                else
                {
                    telemetryList = new List<object>();
                }

                telemetryList.Add(telemetryData);

                string json = JsonSerializer.Serialize(telemetryList, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    IncludeFields = true
                });

                File.WriteAllText(fullPath, json);

                Console.WriteLine($"Adicionado ao arquivo do dia (total: {telemetryList.Count})");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}