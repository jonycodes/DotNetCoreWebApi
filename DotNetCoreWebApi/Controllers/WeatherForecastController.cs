using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetCoreWebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNetCoreWebApi.Controllers
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

        private readonly IRepo repo;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IRepo repo)
        {
            this.repo = repo;
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            this._logger.LogInformation("Get Request coming from client handled by WeatherForecastController") ;

            return "Welcome to DotNetTutorial";
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            string body = null;

            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                body = await reader.ReadToEndAsync();
            }
            
            this._logger.LogInformation(string.Format("Post Request coming from client handled by WeatherForecastController with body: {0}", body));
            
            bool result = await this.repo.SetItem("test", body);

            if (!result)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            string saved = await this.repo.GetItem("test");

            this._logger.LogInformation(string.Format("Found object in redis {0}", saved));

            var rng = new Random();
            var response = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            return Ok(response);
        }
    }
}
