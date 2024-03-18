using ExamAware1.Class;
using ExamAware1.Model;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Ocsp;
using Newtonsoft.Json;
using Google.Protobuf.WellKnownTypes;
using System.Reflection;

namespace ExamAware1.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpGet]
        [Route("getData")]
        public IActionResult Getdata()
        {
            try
            {
                List<ResEmployeeModel> _resdata = MyClass.getData();
                if (!_resdata.Any())
                {
                    return NotFound(_resdata);
                }
                return Ok(_resdata);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;

            }
        }

        [HttpPost]
        [Route("checkContext")]
        public IActionResult CheckContext(string value)
        {
            try
            {
                var _resdata = MyClass.checkContext(value);
                if (!_resdata.Any())
                {
                    return NotFound(_resdata);
                }
                return Ok(_resdata);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;

            }
        }

        [HttpGet]
        [Route("getAPI")]
        public async Task<IActionResult> GetAPIAsync()
        {
            try
            {
                using var client = new HttpClient();
                var apiUrl = "https://catfact.ninja/fact";

                var response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);

                var data = new {url = response.RequestMessage.RequestUri , method = response.RequestMessage.Method , responce = content };
                return Ok(data);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
