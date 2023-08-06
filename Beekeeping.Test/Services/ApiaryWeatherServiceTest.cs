namespace Beekeeping.Test.Services
{
    using Microsoft.CodeAnalysis;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Models;
    using Models.Apiary;
    using Beekeeping.Services.Interfaces;
    using Beekeeping.Services.Services;

    [TestFixture]
    internal class ApiaryWeatherServiseTest
    {
        private BeekeepingDbContext context;
        private IApiaryWeatherService apiaryWeatherService;

        private int apiaryIdForTests;

        [SetUp]
        public async Task SetUp()
        {
            apiaryIdForTests = 9150;

            List<Apiary> apiaries = new()
            {
                 new Apiary()
                 {
                    Id = apiaryIdForTests,
                    Name = "Климентово",
                    Location = "Село Климентово, Варна",
                    OwnerId = UserdId,
                    RegistrationNumber = "9150-0015",
                    Latitude = 43.346222,
                    Longitude = 27.946315
                  },

             new Apiary()
                {
                    Id = 9156,
                    Name = "Зорница",
                    Location = "Село Зорница, Варна",
                    OwnerId = UserdId,
                    RegistrationNumber = "9156-0017",
                    Latitude = 43.330429,
                    Longitude = 27.734944
                  }
             };

            var options = new DbContextOptionsBuilder<BeekeepingDbContext>()
                .UseInMemoryDatabase(databaseName: "BeekeepingInMemory")
                .Options;
            context = new BeekeepingDbContext(options);

            await context.Apiaries.AddRangeAsync(apiaries);

            await context.SaveChangesAsync();

            apiaryWeatherService = new ApiaryWeatherService(context);
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }

        [Test]
        public async Task GetApiariesCoordinatesAsyncShouldReturnCorectData()
        {
            var expected = await context.Apiaries
                          .Where(a => a.OwnerId == UserdId)
                          .Select(a => new ApiaryCoordinatesModel
                          {
                              ApiaryName = a.Name,
                              Latitude = a.Latitude,
                              Longitude = a.Longitude
                          })
                          .ToArrayAsync();

            var actual = await apiaryWeatherService.GetApiariesCoordinatesAsync(UserdId);

            Assert.Multiple(() =>
            {
                Assert.That(actual!.Count(), Is.EqualTo(expected.Length));
                Assert.That(actual!.First().ApiaryName, Is.EqualTo(expected.First().ApiaryName));
                Assert.That(actual!.First().Latitude, Is.EqualTo(expected.First().Latitude));
                Assert.That(actual!.First().Longitude, Is.EqualTo(expected.First().Longitude));
            });
        }
    }
}

