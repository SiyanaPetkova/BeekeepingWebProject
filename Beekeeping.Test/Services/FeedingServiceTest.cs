namespace Beekeeping.Test.Services
{
    #nullable disable

    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;

    using Data.Models;
    using Models.HiveFeeding;

    internal class FeedingServiceTest
    {
        private BeekeepingDbContext context;
        private IFeedingService feedingService;

        private int feedingIdForTests;

        [SetUp]
        public async Task SetUp()
        {
            feedingIdForTests = 30001;

            List<HiveFeeding> feedings = GenerateFeedingData();

            context = new BeekeepingDbContext(GetContextOptions());

            await context.HiveFeeding.AddRangeAsync(feedings);

            await context.SaveChangesAsync();

            feedingService = new FeedingService(context);
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }

        [Test]
        public async Task AddFeedingAsyncShouldAddNewCost()
        {
            var expected = new HiveFeedingFormModel()
            {
                Id = 30003,
                DayOfFeeding = DateTime.Parse("01.01.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                FeedingType = "Питка",
                PriceOfFeeding = 120,
                NumberOfBeeHives = 10
            };

            await feedingService.AddFeedingAsync(expected, UserId);

            var actual = await context.HiveFeeding.FirstOrDefaultAsync(c => c.Id == expected.Id);

            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual!.DayOfFeeding, Is.EqualTo(expected.DayOfFeeding));
                Assert.That(actual.FeedingType, Is.EqualTo(expected.FeedingType));
                Assert.That(actual.PriceOfFeeding, Is.EqualTo(expected.PriceOfFeeding));
                Assert.That(actual.NumberOfBeeHives, Is.EqualTo(expected.NumberOfBeeHives));
            });
        }

        [Test]
        public async Task AllFeedingAsyncShouldReturnCorectInformation()
        {
            var expected = await context.HiveFeeding
                .Where(f => f.CreatorId == UserId)
                .OrderByDescending(f => f.DayOfFeeding)
                .Select(f => new HiveFeedingViewModel()
                {
                    Id = f.Id,
                    FeedingType = f.FeedingType,
                    NumberOfBeeHives = f.NumberOfBeeHives,
                    PriceOfFeeding = f.PriceOfFeeding,
                    DayOfFeeding = f.DayOfFeeding.ToLongDateString(),
                })
                .ToArrayAsync();

            var actual = await feedingService.AllFeedingsAsync(UserId);

            Assert.Multiple(() =>
            {
                Assert.That(actual!.Count(), Is.EqualTo(expected.Length));
                Assert.That(actual!.First().Id, Is.EqualTo(expected.First().Id));
                Assert.That(actual!.First().DayOfFeeding, Is.EqualTo(expected.First().DayOfFeeding));
                Assert.That(actual!.First().PriceOfFeeding, Is.EqualTo(expected.First().PriceOfFeeding));
                Assert.That(actual!.First().FeedingType, Is.EqualTo(expected.First().FeedingType));
                Assert.That(actual!.First().NumberOfBeeHives, Is.EqualTo(expected.First().NumberOfBeeHives));
            });
        }

        [Test]
        public async Task AllFeedoingsAsyncShouldReturnNullIfUserHasNoNotes()
        {
            var actual = await feedingService.AllFeedingsAsync(NotExistingUserdId);

            Assert.That(actual, Is.Null);
        }

        [Test]
        public async Task DeleteFeedingAsyncShouldDeleteFeeding()
        {
            await feedingService.DeleteFeedingAsync(UserId, feedingIdForTests);

            var findFeeding = await context.HiveFeeding.FirstOrDefaultAsync(c => c.Id == feedingIdForTests);

            Assert.That(findFeeding, Is.Null);
        }

        [Test]
        public void DeleteFeedingAsyncShouldThrowIfOwnerDoesNotExist()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await feedingService.DeleteFeedingAsync(NotExistingUserdId, feedingIdForTests));
        }

        [Test]
        public void DeleteFeedingAsyncShouldThrowIfFeedingDoesNotExist()
        {
            int feedingIdoBeDeleted = 9999;

            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await feedingService.DeleteFeedingAsync(UserId, feedingIdoBeDeleted));
        }

        [Test]
        public async Task DoesFeedingExistsShouldReturnTrue()
        {
            var result = await feedingService.DoesFeedingExists(UserId, feedingIdForTests);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task DoesFeedingExistsShouldReturnFalseIfUserDoesNotExist()
        {
            var result = await feedingService.DoesFeedingExists(NotExistingUserdId, feedingIdForTests);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task DoesFeedingExistsShouldReturnFalseIfFeedingDoesNotExist()
        {
            var result = await feedingService.DoesFeedingExists(UserId, 9999);

            Assert.That(result, Is.False);
        }
    }
}