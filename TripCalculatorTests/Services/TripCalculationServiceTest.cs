using System;
using Xunit;
using Moq;
using Services.Interfaces;
using Entities;
using System.Linq;
using Services;
using Data;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace TripCalculatorTests.Services
{
    public class TripCalculationServiceTest : IDisposable
    {
        private ITripService tripService;
        private ITripCalculationService calculationService;
        private IUserService userService;
        private IDayOfWorkService dowService;

        private AppUser user;

        private readonly int maxWeight = 50;

        public TripCalculationServiceTest()
        {
            user = new Mock<AppUser>().Object;
            tripService = new Mock<ITripService>().Object;
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(us => us.GetUserByIdentityNumber(It.IsAny<string>())).Returns(user);
            userService = mockUserService.Object;
            dowService = new Mock<IDayOfWorkService>().Object;
            var logger = new Mock<ILogger<IBaseService>>().Object;
            var mockConfig = new Mock<IConfigurationService>();
            mockConfig.Setup(mc => mc.GatValueInSection<int>(It.IsAny<string>(), It.IsAny<string>())).Returns(maxWeight);
            var config = mockConfig.Object;
            var dataContext = new Mock<IDataContext>().Object;
            calculationService = new TripCalculationService(dataContext, logger, config, userService, dowService, tripService);
        }

        public void Dispose()
        {
            
        }

        [Fact]
        public async void CreateTwoTripBagsForTrip()
        {            
            var dow = new DayOfWork();
            dow.User = user;
            dow.Elements = new List<TripElement>();
            dow.Elements.Add(new TripElement { Id = 1, Weight = 30 });
            dow.Elements.Add(new TripElement { Id = 2, Weight = 30 });
            dow.Elements.Add(new TripElement { Id = 3, Weight = 1 });
            dow.Elements.Add(new TripElement { Id = 4, Weight = 1 });
            var result = await calculationService.CalculateTripAsync(dow);
            Assert.Equal(2, result.Bags.Count);
            Assert.True(result.Bags.All(b => b.BagWeight == 31));
        }

        [Fact]
        public async void CreateOneTripBagWhenThereIsNoOption()
        {
            var dow = new DayOfWork();
            dow.User = user;
            dow.Elements = new List<TripElement>();
            dow.Elements.Add(new TripElement { Id = 1, Weight = 20 });
            dow.Elements.Add(new TripElement { Id = 2, Weight = 20 });
            dow.Elements.Add(new TripElement { Id = 3, Weight = 20 });
            var result = await calculationService.CalculateTripAsync(dow);
            Assert.Equal(1, result.Bags.Count);
            Assert.Equal(60, result.Bags.Sum(b => b.BagWeight));
        }

        [Fact]
        public async void CreateTwoTripBagsWhenThereIsRoom()
        {
            var dow = new DayOfWork();
            dow.User = user;
            dow.Elements = new List<TripElement>();
            dow.Elements.Add(new TripElement { Id = 1, Weight = 1 });
            dow.Elements.Add(new TripElement { Id = 2, Weight = 2 });
            dow.Elements.Add(new TripElement { Id = 3, Weight = 3 });
            dow.Elements.Add(new TripElement { Id = 4, Weight = 4 });
            dow.Elements.Add(new TripElement { Id = 5, Weight = 5 });
            dow.Elements.Add(new TripElement { Id = 6, Weight = 6 });
            dow.Elements.Add(new TripElement { Id = 7, Weight = 7 });
            dow.Elements.Add(new TripElement { Id = 8, Weight = 8 });
            dow.Elements.Add(new TripElement { Id = 9, Weight = 9 });
            dow.Elements.Add(new TripElement { Id = 10, Weight = 10 });
            dow.Elements.Add(new TripElement { Id = 11, Weight = 11 });
            var result = await calculationService.CalculateTripAsync(dow);
            Assert.Equal(2, result.Bags.Count);
            Assert.True(result.Bags.All(b => b.BagWeight < maxWeight));
        }

        [Fact]
        public async void CreateThreeTripBagWhenThereIsTooMuchElements()
        {
            var dow = new DayOfWork();
            dow.User = user;
            dow.Elements = new List<TripElement>();
            dow.Elements.Add(new TripElement { Id = 1, Weight = 9 });
            dow.Elements.Add(new TripElement { Id = 2, Weight = 19 });
            dow.Elements.Add(new TripElement { Id = 3, Weight = 29 });
            dow.Elements.Add(new TripElement { Id = 4, Weight = 39 });
            dow.Elements.Add(new TripElement { Id = 5, Weight = 49 });
            dow.Elements.Add(new TripElement { Id = 6, Weight = 59 });
            var result = await calculationService.CalculateTripAsync(dow);
            Assert.Equal(3, result.Bags.Count);
        }

        [Fact]
        public async void CreateEightTripBagsForTheBorderCase()
        {
            var dow = new DayOfWork();
            dow.User = user;
            dow.Elements = new List<TripElement>();
            dow.Elements.Add(new TripElement { Id = 1, Weight = 32 });
            dow.Elements.Add(new TripElement { Id = 2, Weight = 56 });
            dow.Elements.Add(new TripElement { Id = 3, Weight = 76 });
            dow.Elements.Add(new TripElement { Id = 4, Weight = 8 });
            dow.Elements.Add(new TripElement { Id = 5, Weight = 44 });
            dow.Elements.Add(new TripElement { Id = 6, Weight = 60 });
            dow.Elements.Add(new TripElement { Id = 7, Weight = 47 });
            dow.Elements.Add(new TripElement { Id = 8, Weight = 85 });
            dow.Elements.Add(new TripElement { Id = 9, Weight = 71 });
            dow.Elements.Add(new TripElement { Id = 10, Weight = 91 });
            var result = await calculationService.CalculateTripAsync(dow);
            Assert.Equal(8, result.Bags.Count);
        }
    }
}
