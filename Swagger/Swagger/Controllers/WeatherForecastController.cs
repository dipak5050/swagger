using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swagger.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// dsgvnsdgvsdngsldkngsdlkgnsdlkgnsdlgsnldkglnkdsglknsdglknsdgnksddondfngoedng[koed[nogad[onigear
        /// </summary>
        /// <returns>A list of weather forecasts.</returns>
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
        /// dsgvnsdgvsdngsldkngsdlkgnsdlkgnsdlgsnldkglnkdsglknsdglknsdgnksddondfngoedng[koed[nogad[onigear
        /// </summary>
        /// <param name="forecast">The weather forecast to create.</param>
        /// <returns>The created weather forecast.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(WeatherForecast))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
        [ProducesResponseType(StatusCodes.Status404NotFound,Type = typeof(WeatherForecast))]
        public IActionResult Create([FromBody] WeatherForecast forecast)
        {
            // Your implementation here
            if (forecast == null)
            {
                return BadRequest("Invalid data provided.");
            }

            // Your logic to create the resource and return it

            return CreatedAtAction(nameof(Get), new { id = forecast.Date }, forecast);
        }

    }
}
