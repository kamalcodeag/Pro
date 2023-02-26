using Microsoft.EntityFrameworkCore;
using Pro.API.Data;
using Pro.API.Entities;

namespace Pro.API.Services
{
    public class SampleService : ISampleService
    {
        private readonly AppDbContext _appDbContext;
        public SampleService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User> CreateUserAsync(User entity)
        {
            await _appDbContext.Set<User>().AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<UserDetail> CreateUserDetailAsync(UserDetail entity)
        {
            await _appDbContext.Set<UserDetail>().AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _appDbContext.Users.ToListAsync();
        }

        public async Task<int> GenerateReportAsync()
        {
            int rowsAffected = await _appDbContext.Database.ExecuteSqlRawAsync(@"CALL public.""sp_GenerateRport""()");
            return rowsAffected;
        }
    }
}
