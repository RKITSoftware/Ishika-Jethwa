using Microsoft.AspNetCore.Mvc;

namespace Logging.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
      

        private readonly ILogger _logger;

        //public WeatherForecastController(ILoggerFactory logger)
        //{
        //    _logger = logger.CreateLogger("Custom Logger factory");
        //}

        //public WeatherForecastController(ILogger logger)
        //{
        //    this._logger = logger;
        //}
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Error")]
        public void Get()
        {
            _logger.LogTrace(2,"Log trace");
            _logger.LogDebug(1,"Log debug");
            _logger.LogInformation(30,"Log information");
            _logger.LogWarning(4,"Log warning");
            _logger.LogError(55,"Log Error"); 
            _logger.LogCritical(3,"Log critical");

        }
    }
}