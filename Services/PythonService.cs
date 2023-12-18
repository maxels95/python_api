using python_api.Model;

public class PythonService
{
    private readonly IReadingRepository _readingRepository;
    private readonly ISensorRepository _sensorRepository;
    private readonly IUserRepository _userRepository;

    public PythonService(IReadingRepository readingRepository, ISensorRepository sensorRepository, IUserRepository userRepository)
    {
        _readingRepository = readingRepository;
        _sensorRepository = sensorRepository;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<Reading>> GetAllReadingsAsync()
    {
        return await _readingRepository.GetAllAsync();
    }

    public async Task AddSensorAsync(Sensor sensor)
    {
        await _sensorRepository.AddSensorAsync(sensor);
    }

    public async Task AddReadingAsync(Reading reading)
    {
        await _readingRepository.AddReadingAsync(reading);
    }

    public async Task UpdateRelayManualStateAsync(int sensorId, int newRelayManualState)
    {
        await _sensorRepository.UpdateRelayManualStateAsync(sensorId, newRelayManualState);
    }

    public async Task DeleteReadingAsync(Reading reading)
    {
        await _readingRepository.DeleteAsync(reading);
    }

    public async Task DeleteSensorAsync(Sensor sensor)
    {
        await _sensorRepository.DeleteAsync(sensor);
    }
}