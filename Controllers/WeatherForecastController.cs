using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using python_api.Model;
using System.Collections.Generic;
using System.Linq;


namespace python_api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly PythonCcContext _dbContext;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(PythonCcContext dbContext, ILogger<WeatherForecastController> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


    // public WeatherForecastController(ILogger<WeatherForecastController> logger)
    // {
    //     _logger = logger;
    // }

    [HttpGet(Name = "GetReadings")]
    public IEnumerable<Reading> Get()
    {
        return _dbContext.Readings.ToList();
    }

    [HttpPost("InsertReading")]
    public IActionResult InsertReading([FromBody] Reading model)
    {
         if (ModelState.IsValid)
        {
            // Map ViewModel to Entity
            var entity = new Reading
            {
                Value = model.Value,
                SensorId = model.SensorId,
                DateTime = DateTime.Now.ToString(),
                Sensor = model.Sensor
            };

            // Add to database and save changes
            _dbContext.Readings.Add(entity);
            _dbContext.SaveChanges();

            return Ok();
        }
        else
        {
            return BadRequest("Not a valid model");
        }
    }

    [HttpPost("InsertSensor")]
    public IActionResult InsertSensor([FromBody] Sensor model)
    {
         if (ModelState.IsValid)
        {
            // Map ViewModel to Entity
            var entity = new Sensor
            {
                SensorType = model.SensorType,
                SensorPin = model.SensorPin,
                SensorRelay = model.SensorRelay,
                ControlMode = 0,
                RelayManualState = 0
            };

            // Add to database and save changes
            _dbContext.Sensors.Add(entity);
            _dbContext.SaveChanges();

            return Ok();
        }
        else
        {
            return BadRequest("Not a valid model");
        }
    }
}
