using Api_Telemetry_F1.Models;
using Api_Telemetry_F1.Workers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<F1PackageConfig>(
    builder.Configuration.GetSection("F1PackageConfig"));

builder.Services.AddSingleton<TelemetryState>();
builder.Services.AddHostedService<TelemetryWorker>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
