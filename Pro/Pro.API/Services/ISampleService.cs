using Pro.API.Entities;

namespace Pro.API.Services
{
    public interface ISampleService
    {
        Task<User> CreateUserAsync(User entity);

        Task<UserDetail> CreateUserDetailAsync(UserDetail entity);

        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<int> GenerateReportAsync();
    }
}
