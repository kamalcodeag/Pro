using Microsoft.AspNetCore.Mvc;
using Pro.API.Services;

namespace Pro.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ISampleService _sampleService;

        public UserController(ISampleService sampleService)
        {
            _sampleService = sampleService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _sampleService.GetAllUsersAsync();
            return Ok(result);
        }
    }
}