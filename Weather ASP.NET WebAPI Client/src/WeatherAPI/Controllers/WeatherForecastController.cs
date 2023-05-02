using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherClient _weatherClient;
        private readonly IMemoryCache _memoryCache;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherClient client, IMemoryCache cache)
        {
            _logger = logger;
            _weatherClient = client;
            _memoryCache = cache;
        }

        /// <summary>
        /// Set up _defaultCity in cache memory.
        /// </summary>
        /// <response code="200">Ok</response>
        [HttpPost("{city}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Post(string city)
        {
            _memoryCache.Set("_defaultCity", city);
            return Ok(new Dictionary<string, string>() { {"_defaultCity", city}, {"statusCode", "200"} });
        }

        /// <summary>
        /// Returns default city weather info if it is set, otherwise 404 Not Found.
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="404">Not found</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WeatherData>> Get()
        {
            if (!_memoryCache.TryGetValue("_defaultCity", out string city))
                return NotFound();

            return await Get(city);
        }
        
        /// <summary>
        /// Returns a JSON with weather info in specified coordinates.
        /// </summary>
        /// <params name="lat">"Latitude coordinate"</params>
        /// <params name="lon">"Longtitude coordinate"</params>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        [HttpGet("coordinates")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<WeatherData>> Get(double lat = 1, double lon = 1)
        {
            try 
            {
                return Ok(await _weatherClient.GetWeatherByCoordinates(lat, lon));
            }
            catch
            {
                return BadRequest();
            }
        }
        
        /// <summary>
        /// Returns a JSON with weather info in specified city.
        /// </summary>
        /// <params name="city">"Weather of this city will return."</params>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        [HttpGet("{city}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<WeatherData>> Get(string city)
        {
            try 
            {
                return Ok(await _weatherClient.GetWeatherByCity(city));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
