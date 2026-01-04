using F1VoiceDashboardWorker.Settings;
using F1VoiceDashboardWorker.Workers;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.Configure<VoiceWorkerSettings>(
    builder.Configuration.GetSection("VoiceWorkerSettings")
);

builder.Services.Configure<APIConfig>(
    builder.Configuration.GetSection("APIConfig")
);

builder.Services.AddHostedService<VoiceWorker>();

var host = builder.Build();
host.Run();
