using System.Threading.Tasks;
using Data;
using Entities;
using Microsoft.Extensions.Logging;

namespace Services.Interfaces
{
    public class TripService : BaseService, ITripService
    {
        public TripService(IDataContext context, ILogger<IBaseService> logger) : base(context, logger)
        {
        }

        public async Task<Trip> AddTripAsync(Trip trip)
        {
            var result = await _context.Trips.AddAsync(trip);
            await _context.SaveAsync();
            return result.Entity;
        }
    }
}