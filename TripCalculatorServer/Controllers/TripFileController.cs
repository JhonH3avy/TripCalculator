using System;
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
            if (string.IsNullOrEmpty(dow.User.IdentityNumber))
            {
                var ex = new NullReferenceException("IdentityNumber in DayOfWork.User is empty or null");
                _logger.LogError($"{nameof(TripController)}: {nameof(CalculateTrip)}", ex);
                return null;
            }
            return await _calculationService.CalculateTripAsync(dow);
        }
    }
}