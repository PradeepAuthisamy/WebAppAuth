using Authentication.Models;
using Authentication.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Authentication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IWeatherForecast _weatherForecast;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration,
            IWeatherForecast weatherForecast)
        {
            _logger = logger;
            _configuration = configuration;
            _weatherForecast = weatherForecast;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _weatherForecast.Get();
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}