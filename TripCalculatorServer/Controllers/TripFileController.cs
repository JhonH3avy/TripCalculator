using System.Threading.Tasks;
using Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Interfaces;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripController : ControllerBase
    {

        private readonly ILogger<TripController> _logger;
        private readonly ITripCalculationService _calculationService;

        public TripController(ILogger<TripController> logger,
        ITripCalculationService calculationService)
        {
            _calculationService = calculationService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<Trip>> CalculateTrip([FromBody] DayOfWork dow)
        {
            _logger.Log(LogLevel.Information, $"{nameof(TripController)}: {nameof(CalculateTrip)}", dow);
            return await _calculationService.CalculateTripAsync(dow);
        }
    }
}