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
    public class TripCalculationServiceTest
    {
        private readonly ITripService tripService;
        private readonly ITripCalculationService calculationService;
        private readonly IUserService userService;
        private readonly IDayOfWorkService dowService;

        private readonly AppUser user;

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

        [Fact]
        public async void CreateTwoTripBagsForTrip()
        {            
            var dow = new DayOfWork
            {
                User = user,
                Elements = new List<TripElement>
                {
                    new TripElement { Id = 1, Weight = 30 },
                    new TripElement { Id = 2, Weight = 30 },
                    new TripElement { Id = 3, Weight = 1 },
                    new TripElement { Id = 4, Weight = 1 }
                }
            };
            var result = await calculationService.CalculateTripAsync(dow);
            Assert.Equal(2, result.Bags.Count);
            Assert.True(result.Bags.All(b => b.BagWeight == 31));
        }

        [Fact]
        public async void CreateOneTripBagWhenThereIsNoOption()
        {
            var dow = new DayOfWork
            {
                User = user,
                Elements = new List<TripElement>
                {
                    new TripElement { Id = 1, Weight = 20 },
                    new TripElement { Id = 2, Weight = 20 },
                    new TripElement { Id = 3, Weight = 20 }
                }
            };
            var result = await calculationService.CalculateTripAsync(dow);
            Assert.Equal(1, result.Bags.Count);
            Assert.Equal(60, result.Bags.Sum(b => b.BagWeight));
        }

        [Fact]
        public async void CreateTwoTripBagsWhenThereIsRoom()
        {
            var dow = new DayOfWork 
            {
                User = user,
                Elements = new List<TripElement>
                {
                    new TripElement { Id = 1, Weight = 1 },
                    new TripElement { Id = 2, Weight = 2 },
                    new TripElement { Id = 3, Weight = 3 },
                    new TripElement { Id = 4, Weight = 4 },
                    new TripElement { Id = 5, Weight = 5 },
                    new TripElement { Id = 6, Weight = 6 },
                    new TripElement { Id = 7, Weight = 7 },
                    new TripElement { Id = 8, Weight = 8 },
                    new TripElement { Id = 9, Weight = 9 },
                    new TripElement { Id = 10, Weight = 10 },
                    new TripElement { Id = 11, Weight = 11 }
                }
            };
            var result = await calculationService.CalculateTripAsync(dow);
            Assert.Equal(2, result.Bags.Count);
            Assert.True(result.Bags.All(b => b.BagWeight < maxWeight));
        }

        [Fact]
        public async void CreateThreeTripBagWhenThereIsTooMuchElements()
        {
            var dow = new DayOfWork
            {
                User = user,
                Elements = new List<TripElement>
                {
                    new TripElement { Id = 1, Weight = 9 },
                    new TripElement { Id = 2, Weight = 19 },
                    new TripElement { Id = 3, Weight = 29 },
                    new TripElement { Id = 4, Weight = 39 },
                    new TripElement { Id = 5, Weight = 49 },
                    new TripElement { Id = 6, Weight = 59 }
                }
            };
            var result = await calculationService.CalculateTripAsync(dow);
            Assert.Equal(3, result.Bags.Count);
        }

        [Fact]
        public async void CreateEightTripBagsForTheBorderCase()
        {
            var dow = new DayOfWork
            {
                User = user,
                Elements = new List<TripElement>
                {
                    new TripElement { Id = 1, Weight = 32 },
                    new TripElement { Id = 2, Weight = 56 },
                    new TripElement { Id = 3, Weight = 76 },
                    new TripElement { Id = 4, Weight = 8 },
                    new TripElement { Id = 5, Weight = 44 },
                    new TripElement { Id = 6, Weight = 60 },
                    new TripElement { Id = 7, Weight = 47 },
                    new TripElement { Id = 8, Weight = 85 },
                    new TripElement { Id = 9, Weight = 71 },
                    new TripElement { Id = 10, Weight = 91 }
                }
            };
            var result = await calculationService.CalculateTripAsync(dow);
            Assert.Equal(8, result.Bags.Count);
        }
    }
}
