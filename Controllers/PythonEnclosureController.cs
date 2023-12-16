using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using python_api.Data;
using python_api.Model;
using System.Collections.Generic;
using System.Linq;


namespace python_api.Controllers;

[ApiController]
[Route("[controller]")]
public class PythonEnclosureController : ControllerBase
{
    private readonly PythonService _service;
    private readonly ILogger<PythonEnclosureController> _logger;

    public PythonEnclosureController(PythonService service, ILogger<PythonEnclosureController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet(Name = "GetReadings")]
    public async Task<IActionResult> GetReadingsAsync()
    {
        var readings = await _service.GetAllReadingsAsync();

        if (readings == null || !readings.Any())
        {
            return NotFound();
        }

        return Ok(readings);
    }

    [HttpPost("AddReading")]
    public async Task<IActionResult> InsertReadingAsync([FromBody] Reading reading)
    {
       if (reading == null)
        {
            return BadRequest("Reading data is invalid.");
        }

        await _service.AddReadingAsync(reading);

        return CreatedAtAction("GetReading", new { id = reading.ReadingId }, reading);
    }

    [HttpPost("AddSensor")]
    public async Task<IActionResult> InsertSensorAsync([FromBody] Sensor sensor)
    {
         if (sensor == null)
        {
            return BadRequest("Sensor data is invalid.");
        }

        await _service.AddSensorAsync(sensor);

        return CreatedAtAction("GetSensor", new { id = sensor.SensorId }, sensor);
    }

    [HttpPatch("update-relay-manual-state/{sensorId}")]
    public async Task<IActionResult> UpdateRelayManualStateAsync(int sensorId, [FromBody] int newRelayManualState)
    {
        await _service.UpdateRelayManualStateAsync(sensorId, newRelayManualState);

        return NoContent();
    }
}
