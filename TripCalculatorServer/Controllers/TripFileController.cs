using System;
using System.Threading.Tasks;
using Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Interfaces;
using DTOs;
using AutoMapper;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripController : ControllerBase
    {

        private readonly ILogger<TripController> _logger;
        private readonly ITripCalculationService _calculationService;

        private readonly IMapper _mapper;

        public TripController(ILogger<TripController> logger,
        ITripCalculationService calculationService,
        IMapper mapper)
        {
            _calculationService = calculationService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<TripDto>> CalculateTrip([FromBody] DayOfWork dow)
        {
            _logger.Log(LogLevel.Information, $"{nameof(TripController)}: {nameof(CalculateTrip)}", dow);
            if (string.IsNullOrEmpty(dow.User.IdentityNumber))
            {
                var ex = new NullReferenceException("IdentityNumber in DayOfWork.User is empty or null");
                _logger.LogError($"{nameof(TripController)}: {nameof(CalculateTrip)}", ex);
                return null;
            }
            var trip = await _calculationService.CalculateTripAsync(dow);
            var tripDto = _mapper.Map<TripDto>(trip);
            return Ok(tripDto);
        }
    }
}