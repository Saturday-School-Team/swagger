using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Swagger.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        
        /// <summary>
        /// Get Weather Data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /// <summary>
        /// Get Weather Information by date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet("details")]
        public WeatherForecast Get(string date)
        {
            var rng = new Random();
            return new WeatherForecast
            {
                Date = DateTime.Parse(date),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            };
        }


        /// <summary>
        /// Insert Tempurature data
        /// </summary>
        /// <param name="weatherForecast"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///        "date": "2020-07-18T07:21:11.550Z",
        ///        "temperatureC": 0,
        ///        "summary": "string"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Successfully Insert temperature data</response>
        /// <response code="400">Unable to insert data</response>
        
        [HttpPost("insert")]
        public WeatherForecast Create(WeatherForecast weatherForecast)
        {
            var rng = new Random();
            weatherForecast.id = Int32.Parse(rng.Next(1000).ToString("000")) ;
            return weatherForecast;
        }
    }
}
