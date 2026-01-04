using Api_Telemetry_F1.Workers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TelemetryController : ControllerBase
{
    private readonly TelemetryState _state;

    public TelemetryController(TelemetryState state)
    {
        _state = state;
    }

    [HttpPost("start")]
    public IActionResult Start()
    {
        _state.Running = true;
        return Ok("Coleta iniciada");
    }

    [HttpPost("stop")]
    public IActionResult Stop()
    {
        _state.Running = false;
        return Ok("Coleta parada");
    }

    [HttpGet("status")]
    public IActionResult Status()
    {
        return Ok(new { running = _state.Running });
    }
}
