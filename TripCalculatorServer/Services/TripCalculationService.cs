using System.Threading.Tasks;
using Data;
using Entities;
using Microsoft.Extensions.Logging;
using Services.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace Services
{
    public class TripCalculationService : BaseService, ITripCalculationService
    {
        private readonly IUserService _userService;
        private readonly IDayOfWorkService _dayOfWorkService;
        private readonly ITripService _tripService;

        private readonly int _maxWeight;

        public TripCalculationService(
            IDataContext context,
            ILogger<IBaseService> logger,
            IConfigurationService config,
            IUserService userService,
            IDayOfWorkService dayOfWorkService,
            ITripService tripService) : base(context, logger)
        {
            _userService = userService;
            _dayOfWorkService = dayOfWorkService;
            _tripService = tripService;
            _maxWeight = config.GatValueInSection<int>("Calculation", "MaxWeight");
        }

        public async Task<Trip> CalculateTripAsync(DayOfWork dow)
        {
            _logger.Log(LogLevel.Information, $"{nameof(TripCalculationService)}: {nameof(CalculateTripAsync)}: started", dow);

            var user = _userService.GetUserByIdentityNumber(dow.User.IdentityNumber);
            if (user == null)
            {
                dow.User = await _userService.AddUserAsync(dow.User);
            }

            dow = await _dayOfWorkService.AddDayOfWorkAsync(dow);

            var trip = new Trip();

            while (trip.ElementsAmount < dow.Elements.Count)
            {
                var tripBag = CreateTripBag(dow.Elements.Where(e => !trip.Bags.Any(b => b.Elements.Contains(e))));
                if (tripBag.AparentBagWeight < _maxWeight)
                {
                    MergeBagToLighestBag(trip, tripBag);
                }
                else
                {
                    trip.Bags.Add(tripBag);
                }
            }

            trip = await _tripService.AddTripAsync(trip);

            _logger.LogInformation($"{nameof(TripCalculationService)}: {nameof(CalculateTripAsync)}: finished", trip);

            return trip;
        }

        private TripBag CreateTripBag(IEnumerable<TripElement> elements)
        {
            var elementsByWeight = elements.OrderByDescending(e => e.Weight).ToList();
            var tripBag = new TripBag();

            while (tripBag.AparentBagWeight < _maxWeight)
            {
                var element = GetBestElement(elementsByWeight, tripBag);
                if (element == null)
                {
                    break;
                }
                tripBag.Elements.Add(element);
            }
            return tripBag;
        }

        private static void MergeBagToLighestBag(Trip trip, TripBag tripBag)
        {
            while (tripBag.Elements.Count > 0)
            {
                var lightestBag = trip.Bags.OrderBy(b => b.AparentBagWeight).First();
                var element = tripBag.Elements.First();
                lightestBag.Elements.Add(element);
                tripBag.Elements.Remove(element);
            }
        }

        private static TripElement GetBestElement(IEnumerable<TripElement> elements, TripBag tripBag)
        {
            var nonUsedElements = elements.Where(e => !tripBag.Elements.Any(tbe => tbe.Id == e.Id));
            if (tripBag.TopElement == null)
            {
                return nonUsedElements.First();
            }
            return nonUsedElements.LastOrDefault();
        }
    }
}