using python_api.Data;
using python_api.Model;

public class SensorRepository : Repository<Sensor>, ISensorRepository
{
    public SensorRepository(PythonCcContext context) : base(context)
    {
    }

    public async Task AddSensorAsync(Sensor sensor)
    {
        await AddAsync(sensor);
    }

    public async Task UpdateRelayManualStateAsync(int sensorId, int newRelayManualState)
    {
        var sensor = await GetByIdAsync(sensorId);
        
        if (sensor != null)
        {
            sensor.RelayManualState = newRelayManualState;
            await UpdateAsync(sensor);
        }
        // Handle when Sensor is null
    }
}