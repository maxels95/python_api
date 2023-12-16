
using python_api.Data;
using python_api.Model;

public class ReadingRepository : Repository<Reading>, IReadingRepository
{
    public ReadingRepository(PythonCcContext context) : base(context)
    {
    }

    public async Task AddReadingAsync(Reading reading)
    {
        await AddAsync(reading);
    }
}