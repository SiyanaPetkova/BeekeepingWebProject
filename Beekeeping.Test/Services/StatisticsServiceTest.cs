namespace Beekeeping.Test.Services
{
    using Beekeeping.Models.Statistics;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class StatisticsServiceTest
    {
        private BeekeepingDbContext context;
        private IStatisticsService statisticsService;

        [SetUp]
        public async Task SetUp()
        {
            var apiaries = GenerateApiariesData();
            var beeColonies = GenerateBeeColonyData();
            var costs = GenerateCostData();
            var incomes = GenerateIncomeData();
            var inspections = GenerateInspectionsData();

            context = new BeekeepingDbContext(GetContextOptions());

            await context.Apiaries.AddRangeAsync(apiaries);
            await context.BeeColonies.AddRangeAsync(beeColonies);
            await context.Costs.AddRangeAsync(costs);
            await context.Incomes.AddRangeAsync(incomes);
            await context.Inspections.AddRangeAsync(inspections);

            await context.SaveChangesAsync();

            statisticsService = new StatisticsService(context);
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }

        [Test]
        public async Task GetStatisticsForUserAsyncMustReturnCorrectInformation()
        {
            var expected = new StatisticsViewModel()
            {
                ApiariesCount = 2,
                BeeColoniesCount = 3,
                TotalCost = 220,
                TotalIncome = 1070,
                FinancialResult = 850,
                BeeColoniesAverageStrenght = 4.5
            };

            var actual = await statisticsService.GetStatisticsForUserAsync(UserId);

            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual.ApiariesCount, Is.EqualTo(expected.ApiariesCount));
                Assert.That(actual.BeeColoniesAverageStrenght, Is.EqualTo(expected.BeeColoniesAverageStrenght));
                Assert.That(actual.BeeColoniesCount, Is.EqualTo(expected.BeeColoniesCount));
                Assert.That(actual.TotalIncome, Is.EqualTo(expected.TotalIncome));
                Assert.That(actual.TotalCost, Is.EqualTo(expected.TotalCost));
                Assert.That(actual.FinancialResult, Is.EqualTo(expected.FinancialResult));
            });
        }
    }
}