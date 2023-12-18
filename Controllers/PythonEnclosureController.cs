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
       try
       {
            await _service.AddReadingAsync(reading);
            return Ok();
       }
       catch
       {
            return BadRequest();
       }
    }

    [HttpPost("AddSensor")]
    public async Task<IActionResult> InsertSensorAsync([FromBody] Sensor sensor)
    {
        try
       {
            await _service.AddSensorAsync(sensor);
            return Ok();
       }
       catch
       {
            return BadRequest();
       }
    }

    [HttpPatch("update-relay-manual-state/{sensorId}")]
    public async Task<IActionResult> UpdateRelayManualStateAsync(int sensorId, [FromBody] int newRelayManualState)
    {
        try
        {
            await _service.UpdateRelayManualStateAsync(sensorId, newRelayManualState);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpDelete("delete-reading")]
    public async Task<IActionResult> DeleteEntityAsync([FromBody] Reading reading)
    {
        try
        {
            await _service.DeleteReadingAsync(reading);
            return Ok("Reading removed.");
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpDelete("delete-sensor")]
    public async Task<IActionResult> DeleteEntityAsync([FromBody] Sensor sensor)
    {
        try
        {
            await _service.DeleteSensorAsync(sensor);
            return Ok("Sensor removed.");
        }
        catch
        {
            return BadRequest();
        }
    }
}
