using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Reflection;

namespace IpLimiterTutorial.Controllers
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

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            AuthorizeAsync();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

    public void AuthorizeAsync()
    {
        TokenClientOptions tokenClientOption = new TokenClientOptions
        {
            ClientId = "coltcoffee",
            ClientSecret = "G6Ht0AoZFj"
        };

        HttpClient client = HttpClientFactory.Create();

        client.BaseAddress = new Uri("https://dafateridentity.azurewebsites.net/connect/token");

        var tokenClient = new TokenClient(client, tokenClientOption);
            //"SystemAPI.Document.Write"
        Task<TokenResponse>? tokenResponse = tokenClient.RequestTokenAsync("client_credentials");


        if (tokenResponse.Result.IsError)
        {
                var s = tokenResponse.Result?.HttpStatusCode;
           
           
        }
        var aa= tokenResponse.Result.AccessToken;

       


    }
}
}