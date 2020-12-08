using System.Threading.Tasks;
using Data;
using Entities;
using Microsoft.Extensions.Logging;
using Services.Interfaces;

namespace Services
{
    public class TripCalculationService : BaseService, ITripCalculationService
    {
        public TripCalculationService(DataContext context, ILogger<IBaseService> logger) : base(context, logger)
        {
        }

        public Task<Trip> CalculateTripAsync(DayOfWork dow)
        {
            _logger.Log(LogLevel.Information, $"{nameof(TripCalculationService)}: {nameof(CalculateTripAsync)}", dow);
            
            
            return null;
        }
    }
}