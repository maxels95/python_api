using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using python_api.Data;
using python_api.DTO;
using python_api.Model;
using System.Collections.Generic;
using System.Linq;


namespace python_api.Controllers;

[ApiController]
[Route("[controller]")]
public class PythonEnclosureController : ControllerBase
{
    private readonly PythonService _service;
    private readonly IMapper _mapper;
    private readonly ILogger<PythonEnclosureController> _logger;

    public PythonEnclosureController(PythonService service, IMapper mapper, ILogger<PythonEnclosureController> logger)
    {
        _service = service;
        _mapper = mapper;
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

        var destinationObjects = _mapper.Map<IEnumerable<ReadingDTO>>(readings);
        return Ok(destinationObjects);
    }

    [HttpPost("AddReading")]
    public async Task<IActionResult> InsertReadingAsync([FromBody] ReadingDTO readingDTO)
    {
       try
       {
            var destinationReading = _mapper.Map<Reading>(readingDTO);
            await _service.AddReadingAsync(destinationReading);
            return Ok();
       }
       catch
       {
            return BadRequest();
       }
    }

    [HttpPost("AddSensor")]
    public async Task<IActionResult> InsertSensorAsync([FromBody] SensorDTO sensorDTO)
    {
        try
       {
            var destinationSensor = _mapper.Map<Sensor>(sensorDTO);
            await _service.AddSensorAsync(destinationSensor);
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
