
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication4.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public class FrontEndController : Controller
        {
            private readonly HttpClient _httpClient;

            public FrontEndController(IHttpClientFactory httpClientFactory)
            {
                _httpClient = httpClientFactory.CreateClient();
            }

            [HttpGet]
            public async Task<IActionResult> Get()
            {
                var api2Task = _httpClient.GetStringAsync("http://localhost:5299/api/Backend1");
                var api3Task = _httpClient.GetStringAsync("http://localhost:5299/api/Backend2");

                await Task.WhenAll(api2Task, api3Task);

                return Ok(new
                {
                    API2Response = await api2Task,
                    API3Response = await api3Task
                });
            }

            [HttpPost]
            public async Task<IActionResult> Post([FromBody] object data)
            {
                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json");

                var api2Task = _httpClient.PostAsync("https://localhost:5001/api/API2", content);
                var api3Task = _httpClient.PostAsync("https://localhost:5002/api/API3", content);

                await Task.WhenAll(api2Task, api3Task);

                return Ok(new
                {
                    API2Response = await api2Task.Result.Content.ReadAsStringAsync(),
                    API3Response = await api3Task.Result.Content.ReadAsStringAsync()
                });
            }
        }
}


