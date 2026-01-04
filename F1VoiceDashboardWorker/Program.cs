using F1VoiceDashboardWorker.Settings;
using F1VoiceDashboardWorker.Workers;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.Configure<VoiceWorkerSettings>(
    builder.Configuration.GetSection("VoiceWorkerSettings")
);

builder.Services.AddHostedService<VoiceWorker>();

var host = builder.Build();
host.Run();
