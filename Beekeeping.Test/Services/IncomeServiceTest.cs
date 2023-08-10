namespace Beekeeping.Test.Services
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Threading.Tasks;

    using Models.Income;

    internal class IncomeServiceTest
    {
        private BeekeepingDbContext context;
        private IIncomeService incomeService;

        private int incomeIdForTests;

        [SetUp]
        public async Task SetUp()
        {
            incomeIdForTests = 60001;

            var incomes = GenerateIncomeData();

            context = new BeekeepingDbContext(GetContextOptions());

            await context.Incomes.AddRangeAsync(incomes);

            await context.SaveChangesAsync();

            incomeService = new IncomeService(context);
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }

        [Test]
        public async Task AddIncomeAsyncShouldAddNewCost()
        {
            var expected = new IncomeFormModel()
            {
                Id = 60003,
                IncomeValue = 950,
                TypeOfIncome = "Продаден прашец",
                DayOfTheIncome = DateTime.Parse("04.20.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
            };

            await incomeService.AddIncomeAsync(expected, UserdId);

            var actual = await context.Incomes.FirstOrDefaultAsync(i => i.Id == expected.Id);

            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual!.DayOfTheIncome, Is.EqualTo(expected.DayOfTheIncome));
                Assert.That(actual!.TypeOfIncome, Is.EqualTo(expected.TypeOfIncome));
                Assert.That(actual!.IncomeValue, Is.EqualTo(expected.IncomeValue));
            });
        }

        [Test]
        public async Task AllIncomesAsyncShouldReturnCorectInformation()
        {
            var expected = await context.Incomes
                .Where(i => i.CreatorId == UserdId)
                .OrderByDescending(i => i.DayOfTheIncome)
                .Select(i => new IncomeViewModel()
                {
                    Id = i.Id,
                    DayOfTheIncome = i.DayOfTheIncome.ToLongDateString(),
                    IncomeValue = i.IncomeValue,
                    TypeOfIncome = i.TypeOfIncome,
                    CreatorId = UserdId
                })

                .ToArrayAsync();

            var actual = await incomeService.AllIncomesAsync(UserdId);

            Assert.Multiple(() =>
            {
                Assert.That(actual!.Count(), Is.EqualTo(expected.Length));
                Assert.That(actual!.First().Id, Is.EqualTo(expected.First().Id));
                Assert.That(actual!.First().DayOfTheIncome, Is.EqualTo(expected.First().DayOfTheIncome));
                Assert.That(actual!.First().IncomeValue, Is.EqualTo(expected.First().IncomeValue));
                Assert.That(actual!.First().TypeOfIncome, Is.EqualTo(expected.First().TypeOfIncome));
                Assert.That(actual!.First().CreatorId, Is.EqualTo(expected.First().CreatorId));
            });
        }

        [Test]
        public async Task DeleteIncomeAsyncShouldDeleteIncome()
        {
            await incomeService.DeleteIncomeAsync(UserdId, incomeIdForTests);

            var findIncome = await context.Incomes.FirstOrDefaultAsync(i => i.Id == incomeIdForTests);

            Assert.That(findIncome, Is.Null);
        }

        [Test]
        public void DeleteIncomeAsyncShouldThrowIfOwnerDoesNotExist()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await incomeService.DeleteIncomeAsync(NotExistingUserdId, incomeIdForTests));
        }

        [Test]
        public void DeleteIncomeAsyncShouldThrowIfIncomeDoesNotExist()
        {
            int costIdToBeDeleted = 5555;

            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await incomeService.DeleteIncomeAsync(UserdId, costIdToBeDeleted));
        }

        [Test]
        public async Task DoesIncomeExistsShouldReturnTrue()
        {
            var result = await incomeService.DoesIncomeExists(UserdId, incomeIdForTests);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task DoesIncomeExistsShouldReturnFalseIfUserDoesNotExist()
        {
            var result = await incomeService.DoesIncomeExists(NotExistingUserdId, incomeIdForTests);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task DoesIncomeExistsShouldReturnFalseIfIncomeDoesNotExist()
        {
            var result = await incomeService.DoesIncomeExists(UserdId, 9999);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task GetTotalIncomeAsyncShouldReturnCorrectvalue()
        {
            decimal expectedTotalIncome = 1070;

            var actual = await incomeService.GetTotalIncomeAsync(UserdId);

            Assert.That(actual, Is.EqualTo(expectedTotalIncome));
        }
    }
}