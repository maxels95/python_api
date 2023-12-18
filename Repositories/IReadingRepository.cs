using python_api.Model;

public interface IReadingRepository : IRepository<Reading>
{
    Task AddReadingAsync(Reading reading);
    Task DeleteAsync(Reading reading);
}