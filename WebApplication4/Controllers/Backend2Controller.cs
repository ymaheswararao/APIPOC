using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Backend2Controller : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Introduce a kind of delay of 3 seconds
            await Task.Delay(3000);
            return Ok("Backend1 response after delay");
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] object data)
        {
            // Delay of 3 seconds
            await Task.Delay(3000);
            return Ok("Backend1 received POST request after delay");
        }
    }
}
