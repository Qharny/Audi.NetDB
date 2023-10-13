using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuditNetProject.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class TestController : ControllerBase
    {
		[HttpGet("weatherforecast")]
		//public async Task<ActionResult<IEnumerable<WeatherForecast>>> GetWeatherForecastAsync()
		public async Task<IActionResult>  GetWeatherForecastAsync()
		{
			//var rng = new Random();
			//var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
			//{
			//	Date = DateTime.Now.AddDays(index),
			//	TemperatureC = rng.Next(-20, 55),
			//	Summary = Summaries[rng.Next(Summaries.Length)]
			//})
			//.ToArray();

			//return Ok(forecasts);

			// URL of the API endpoint
			string apiUrl = "https://my-json-server.typicode.com/typicode/demo/posts";

			// Create an instance of HttpClient
			using (HttpClient client = new HttpClient())
			{
				try
				{
					// Send a GET request to the specified URL
					HttpResponseMessage response = await client.GetAsync(apiUrl);

					// Check if the request was successful
					if (response.IsSuccessStatusCode)
					{
						// Read the content of the response and output it to the console
						string content = await response.Content.ReadAsStringAsync();
						Console.WriteLine(content);
						return Ok(content);
					}
					else
					{
						return BadRequest();
						Console.WriteLine("Error: " + response.StatusCode);
					}
				}
				catch (HttpRequestException e)
				{
					return BadRequest();
				}
			}
		}

		public IActionResult Privacy()
    {
        // return View();
        return Ok(new { success = true });
    }

		private static readonly string[] Summaries = new[]
	{
		"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	};
	}
}
