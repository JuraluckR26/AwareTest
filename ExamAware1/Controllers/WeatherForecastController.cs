//using ExamAware1.Class;
//using ExamAware1.Model;
//using Microsoft.AspNetCore.Mvc;

//namespace ExamAware1.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class WeatherForecastController : ControllerBase
//    {
//        private static readonly string[] Summaries = new[]
//        {
//            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//        };

//        private readonly ILogger<WeatherForecastController> _logger;

//        public WeatherForecastController(ILogger<WeatherForecastController> logger)
//        {
//            _logger = logger;
//        }

//        [HttpGet(Name = "GetWeatherForecast")]
//        public IEnumerable<WeatherForecast> Get()
//        {
//            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//            {
//                Date = DateTime.Now.AddDays(index),
//                TemperatureC = Random.Shared.Next(-20, 55),
//                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
//            })
//            .ToArray();
//        }

//        [HttpGet]
//        [Route("getData")]
//        public IActionResult Getdata()
//        {
//            try
//            {
//                List<ResEmployeeModel> _resdata = MyClass.getData();
//                return Ok();
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"An error occurred: {ex.Message}");
//                return null;

//            }
//        }
//    }
//}
