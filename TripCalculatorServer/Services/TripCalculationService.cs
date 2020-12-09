using System.Threading.Tasks;
using Data;
using Entities;
using Microsoft.Extensions.Logging;
using Services.Interfaces;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Services
{
    public class TripCalculationService : BaseService, ITripCalculationService
    {
        private readonly IConfiguration _config;
        public TripCalculationService(DataContext context, ILogger<IBaseService> logger, IConfiguration config) : base(context, logger)
        {
            _config = config;
        }

        public async Task<Trip> CalculateTripAsync(DayOfWork dow)
        {
            _logger.Log(LogLevel.Information, $"{nameof(TripCalculationService)}: {nameof(CalculateTripAsync)}", dow);

            var user = _context.Users.First(u => u.IdentityNumber == dow.User.IdentityNumber);
            if (user == null)
            {
                await _context.Users.AddAsync(dow.User);
            }

            await _context.DayOfWorks.AddAsync(dow);

            var trip = new Trip();

            while (trip.ElementsAmount < dow.Elements.Count())
            {
                var tripBag = CreateTripBag(dow.Elements);
                trip.Bags.Add(tripBag);
            }

            return trip;
        }

        private TripBag CreateTripBag(IEnumerable<TripElement> elements)
        {
            var maxWeight = _config.GetSection("Calculation").GetValue<int>("MaxWeight");
            var elementsByWeight = elements.OrderByDescending(e => e.Weight).ToList();
            var tripBag = new TripBag();
            tripBag.Elements = new List<TripElement>();

            while (tripBag.AparentBagWeight < maxWeight)
            {
                var element = GetBestElement(elementsByWeight, tripBag);
                tripBag.Elements.Add(element);
            }
            return tripBag;
        }

        private TripElement GetBestElement(IEnumerable<TripElement> elements, TripBag tripBag)
        {
            var nonUsedElements = elements.Where(e => !tripBag.Elements.Any(tbe => tbe.Id == e.Id));
            if (tripBag.TopElement == null)
            {
                return nonUsedElements.First();
            }
            return nonUsedElements.Last();
        }
    }
}