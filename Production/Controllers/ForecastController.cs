using Microsoft.AspNetCore.Mvc;
using Production.Services.Context;

namespace Production.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForecastController : ControllerBase
    {
        protected readonly IForecastService _forecastService;

        public ForecastController(IForecastService forecastService) 
        { 
            _forecastService = forecastService;
        }

        [HttpGet]
        public async Task<ActionResult<double>> GetForecast()
        {
            return Ok(await _forecastService.GenerateForecast());
        }
    }
}
