using Microsoft.EntityFrameworkCore;
using Pro.API.Data;
using Pro.API.Entities;
using Pro.API.Services;

namespace TestProject1
{
    public class UserUnitTest
    {
        private readonly AppDbContext _appDbContext;
        public UserUnitTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                            .UseInMemoryDatabase(databaseName: "TestDb")
                            .Options;

            _appDbContext = new AppDbContext(options);

            _appDbContext.Database.EnsureDeleted();
            _appDbContext.Database.EnsureCreated();

            //_testDbContext.Database.Migrate();
        }

        [Fact]
        public void AddNewUser()
        {
            var sampleService = new SampleService(_appDbContext);

            var result = sampleService.CreateUserAsync(new User
            {
                Id = 3,
                UserName = "testuser3",
                Email = "testuser3@gmail.com"
            });

            // Assert
            Assert.NotNull(result.Result);
            Assert.Equal(3, result.Result.Id);
            Assert.Equal("testuser3", result.Result.UserName);
            Assert.Equal("testuser3@gmail.com", result.Result.Email);
        }

        [Fact]
        public void AddNewUserDetail()
        {
            var sampleService = new SampleService(_appDbContext);

            var result = sampleService.CreateUserDetailAsync(new UserDetail
            {
                Id = 1,
                FirstName = "test1",
                LastName = "test1",
                Description = @"{""menu"": {
                                  ""id"": ""file"",
                                  ""value"": ""File"",
                                  ""popup"": {
                                    ""menuitem"": [
                                      {""value"": ""New"", ""onclick"": ""CreateNewDoc()""},
                                      {""value"": ""Open"", ""onclick"": ""OpenDoc()""},
                                      {""value"": ""Close"", ""onclick"": ""CloseDoc()""}
                                    ]
                                  }
                                }}",
                UserId = 1
            });

            // Assert
            Assert.NotNull(result.Result);
            Assert.Equal(1, result.Result.Id);
            Assert.Equal("test1", result.Result.FirstName);
            Assert.Equal("test1", result.Result.LastName);
        }

        [Fact]
        public void GetAllTestTables()
        {
            var sampleService = new SampleService(_appDbContext);

            var result = sampleService.GetAllUsersAsync();

            // Assert
            Assert.NotEmpty(result.Result);
        }

        [Fact]
        public void GenerateNewReport()
        {
            var sampleService = new SampleService(_appDbContext);

            var result = sampleService.GenerateReportAsync();

            // Assert
            Assert.NotEqual(0, result.Result);
        }
    }
}