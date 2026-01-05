using F1VoiceDashboardWorker.Models;
using F1VoiceDashboardWorker.Settings;
using F1VoiceDashboardWorker.Utils;
using Microsoft.Extensions.Options;
using NAudio.Wave;
using System.Threading;
using Vosk;

namespace F1VoiceDashboardWorker.Workers
{
    public class VoiceWorker : BackgroundService
    {
        private WaveInEvent? _waveIn;
        private VoskRecognizer? _recognizer;
        public readonly VoiceWorkerSettings VoiceWorkerSettings;
        public APIConfig APIConfig;
        public static int _Monitor;
        public Commands CommandsDict;
        public DashboardsF1 DashboardF1Data;
        public VoiceWorker(IOptions<VoiceWorkerSettings> voiceSettingsConfig, IOptions<APIConfig> apiConfig, IOptions<DashboardsF1> DashF1Config)
        {
            VoiceWorkerSettings = voiceSettingsConfig.Value;
            _Monitor = VoiceWorkerSettings.MonitorNumber;
            APIConfig = apiConfig.Value;
            DashboardF1Data = DashF1Config.Value;
            CommandsDict = new Commands(DashboardF1Data);
        }
        private static bool _aguardandoNumeroMonitor = false;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("========================================");
            Console.WriteLine(" F1 VOICE DASHBOARD WORKER INICIADO");
            Console.WriteLine("========================================");
            Console.WriteLine($"Monitor atual: {_Monitor}º monitor\n");

            if (!Directory.Exists(VoiceWorkerSettings.PathModel))
            {
                Console.WriteLine($"ERRO: Pasta do modelo não encontrada em:\n{Path.GetFullPath(VoiceWorkerSettings.PathModel)}");
                return;
            }

            Console.WriteLine();
            Vosk.Vosk.SetLogLevel(0);
            var model = new Model(VoiceWorkerSettings.PathModel);
            _recognizer = new VoskRecognizer(model, 16000.0f);

            _waveIn = new WaveInEvent
            {
                DeviceNumber = VoiceWorkerSettings.MicDeviceNumber - 1,
                WaveFormat = new WaveFormat(16000, 1)
            };

            _waveIn.DataAvailable += OnDataAvailable;

            try
            {
                _waveIn.StartRecording();
                Console.WriteLine("MICROFONE ATIVO E ESCUTANDO COMANDO DE VOZ!");
                Console.WriteLine("Comandos disponíveis: 'posição', 'dados de corrida', 'alterar monitor', 'fechar', etc.\n");

                while (!stoppingToken.IsCancellationRequested)
                {
                    await Task.Delay(500, stoppingToken);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro na captura de áudio: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                _waveIn?.StopRecording();
                Console.WriteLine("\nWorker parado.");
            }
        }

        private void OnDataAvailable(object? sender, WaveInEventArgs e)
        {
            if (_recognizer == null) return;

            if (_recognizer.AcceptWaveform(e.Buffer, e.BytesRecorded))
            {
                string jsonResult = _recognizer.Result();
                string texto = AudioHelper.ExtractText(jsonResult).Trim();
                if (!string.IsNullOrWhiteSpace(texto))
                {
                    Console.WriteLine($"\n[FRASE COMPLETA] Você disse: '{texto}'");
                    CommandExecuteHelper.ExecuteCommand(texto, CommandsDict.CommandsUrl, APIConfig.BaseURL,ref _Monitor, ref _aguardandoNumeroMonitor);
                }
            }
            else
            {
                string parcial = AudioHelper.ExtractText(_recognizer.PartialResult());
                if (!string.IsNullOrWhiteSpace(parcial))
                {
                    Console.Write($"\r[ESCUTANDO] {parcial.PadRight(60)}");
                }
            }
        }

        public override void Dispose()
        {
            _waveIn?.Dispose();
            _recognizer?.Dispose();
            base.Dispose();
        }
    }
}