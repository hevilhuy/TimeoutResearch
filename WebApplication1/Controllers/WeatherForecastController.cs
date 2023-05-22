using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly MyService _myService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, MyService myService)
        {
            _logger = logger;
            _myService = myService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(1 * 1000);

            return await _myService.MyMethodAsync(cancellationTokenSource.Token);
        }
    }
}