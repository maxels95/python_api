using python_api.Data;
using python_api.Model;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(PythonCcContext context) : base(context)
    {
    }

    // Implement specific methods for User if needed
}