using Microsoft.AspNetCore.Mvc;
using MyRecipe.Infrastructure;

namespace MyRecipe.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ILoggerFactory _loggerFactory;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            _logger = logger;
            _configuration = configuration;
            _loggerFactory = loggerFactory;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            using (var db = new MyRecipeDbContext(_configuration, _loggerFactory))
            {
                db.Ingredients.Add(new Domain.Ingredient { Name = "‗יצמ2" });
                db.SaveChanges();
            }

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}