namespace Beekeeping.Test.Services
{
    #nullable disable 

    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;

    using Data.Models;
    using Models.Cost;

    internal class CostServiceTest
    {
        private BeekeepingDbContext context;
        private ICostService costService;

        private int costIdForTests;

        [SetUp]
        public async Task SetUp()
        {
            costIdForTests = 50001;

            List<Cost> costs = GenerateCostData();

            context = new BeekeepingDbContext(GetContextOptions());

            await context.Costs.AddRangeAsync(costs);

            await context.SaveChangesAsync();

            costService = new CostService(context);
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }

        [Test]
        public async Task AddCostAsyncShouldAddNewCost()
        {
            var expected = new CostFormModel()
            {
                Id = 50003,
                DayOfTheCost = DateTime.Parse("01.05.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                TypeOfCost = "Третиране",
                CostValue = 200
            };

            await costService.AddCostAsync(expected, UserId);

            var actual = await context.Costs.FirstOrDefaultAsync(c => c.Id == expected.Id);

            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual!.DayOfTheCost, Is.EqualTo(expected.DayOfTheCost));
                Assert.That(actual!.TypeOfCost, Is.EqualTo(expected.TypeOfCost));
                Assert.That(actual!.CostValue, Is.EqualTo(expected.CostValue));
            });
        }

        [Test]
        public async Task AllCostsAsyncShouldReturnCorectInformation()
        {
            var expected = await context.Costs
                .Where(c => c.CreatorId == UserId)
                .OrderByDescending(c => c.DayOfTheCost)
                .Select(c => new CostViewModel()
                {
                    Id = c.Id,
                    DayOfTheCost = c.DayOfTheCost.ToLongDateString(),
                    CostValue = c.CostValue,
                    TypeOfCost = c.TypeOfCost,
                    CreatorId = UserId
                }).ToArrayAsync();

            var actual = await costService.AllCostAsync(UserId);

            Assert.Multiple(() =>
            {
                Assert.That(actual!.Count(), Is.EqualTo(expected.Length));
                Assert.That(actual!.First().Id, Is.EqualTo(expected.First().Id));
                Assert.That(actual!.First().DayOfTheCost, Is.EqualTo(expected.First().DayOfTheCost));
                Assert.That(actual!.First().CostValue, Is.EqualTo(expected.First().CostValue));
                Assert.That(actual!.First().TypeOfCost, Is.EqualTo(expected.First().TypeOfCost));
                Assert.That(actual!.First().CreatorId, Is.EqualTo(expected.First().CreatorId));
            });
        }

        [Test]
        public async Task DeleteCostAsyncShouldDeleteCost()
        {
            await costService.DeleteCostAsync(UserId, costIdForTests);

            var findCost = await context.Costs.FirstOrDefaultAsync(c => c.Id == costIdForTests);

            Assert.That(findCost, Is.Null);
        }

        [Test]
        public void DeleteCostAsyncShouldThrowIfOwnerDoesNotExist()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await costService.DeleteCostAsync(NotExistingUserdId, costIdForTests));
        }

        [Test]
        public void DeleteCostAsyncShouldThrowIfCostDoesNotExist()
        {
            int costIdToBeDeleted = 5555;

            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await costService.DeleteCostAsync(UserId, costIdToBeDeleted));
        }

        [Test]
        public async Task DoesCostExistsShouldReturnTrue()
        {
            var result = await costService.DoesCostExists(UserId, costIdForTests);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task DoesCostExistsShouldReturnFalseIfUserDoesNotExist()
        {
            var result = await costService.DoesCostExists(NotExistingUserdId, costIdForTests);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task DoesCostExistsShouldReturnFalseIfCostDoesNotExist()
        {
            var result = await costService.DoesCostExists(UserId, 9999);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task GetTotalCostAsyncShouldReturnCorrectvalue()
        {
            decimal expectedTotalCost = 220;

            var actual = await costService.GetTotalCostAsync(UserId);

            Assert.That(actual, Is.EqualTo(expectedTotalCost));
        }
    }
}