namespace Beekeeping.Web.Controllers
{
    using System.Diagnostics;
    using Beekeeping.Models.Apiary;
    using Beekeeping.Services.Interfaces;
    using Beekeeping.Services.Services;
    using Beekeeping.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;

    using Models.Errors;

    using static Common.ConstantValues;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IApiaryWeatherService weatherService;

        public HomeController(ILogger<HomeController> logger, IApiaryWeatherService weatherService)
        {
            _logger = logger;
            this.weatherService = weatherService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ApiaryWeather()
        {
            var userId = this.User.Id();

            var apiaries = await weatherService.GetApiariesCoordinatesAsync(userId);

            var weatherResults = new List<ApiaryWeatherModel>();

            foreach (var apiary in apiaries) 
            {
                double latitude = apiary.Latitude;
                double longitude = apiary.Longitude;
               
                string apiCall = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={OpenWeatherApiKey}";

                ApiaryWeatherModel results = weatherService.GetWeatherDataAsync(apiCall).Result;

                results.Title = apiary.ApiaryName;

                weatherResults.Add(results);
            }
            
            return View(weatherResults);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}