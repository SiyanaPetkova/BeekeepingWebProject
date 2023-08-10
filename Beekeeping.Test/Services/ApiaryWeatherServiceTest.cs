namespace Beekeeping.Test.Services
{
    using Microsoft.CodeAnalysis;
    using Microsoft.EntityFrameworkCore;

    using Models.Apiary;
 
    [TestFixture]
    internal class ApiaryWeatherServiseTest
    {
        private BeekeepingDbContext context;
        private IApiaryWeatherService apiaryWeatherService;

        [SetUp]
        public async Task SetUp()
        {
            var apiaries = GenerateApiariesData();

            context = new BeekeepingDbContext(GetContextOptions());

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
                          .Where(a => a.OwnerId == UserId)
                          .Select(a => new ApiaryCoordinatesModel
                          {
                              ApiaryName = a.Name,
                              Latitude = a.Latitude,
                              Longitude = a.Longitude
                          })
                          .ToArrayAsync();

            var actual = await apiaryWeatherService.GetApiariesCoordinatesAsync(UserId);

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

