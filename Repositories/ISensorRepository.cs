using python_api.Model;

public interface ISensorRepository : IRepository<Sensor>
{
    Task AddSensorAsync(Sensor sensor);
    Task UpdateRelayManualStateAsync(int sensorId, int newRelayManualState);
}