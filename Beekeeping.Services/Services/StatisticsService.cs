namespace Beekeeping.Services.Services
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Models.Statistics;
    using Interfaces;

    public class StatisticsService : IStatisticsService
    {
        private readonly BeekeepingDbContext context;

        public StatisticsService(BeekeepingDbContext context)
        {
            this.context = context;
        }

        public async Task<StatisticsViewModel> GetStatisticsForUserAsync(string userId)
        {
            var totalIncome = await context.Incomes
                .Where(i => i.CreatorId == userId)
                .SumAsync(i => i.IncomeValue);

            var totalCost = await context.Costs
                .Where(c => c.CreatorId == userId)
                .SumAsync(c => c.CostValue);

            var financialResult = totalIncome - totalCost;

            var apiariesCount = await context.Apiaries
                .Where(a => a.OwnerId == userId)
                .CountAsync();

            var beeColoniesCount = await context.BeeColonies
                .Where(b => b.OwnerOfTheApiary == userId)
                .CountAsync();

            var beeColoniesStrenght = await context.BeeColonies
                .Where(b => b.OwnerOfTheApiary == userId)
                .Include(b => b.Inspections)
                .Select(b => new
                {
                    Id = b.Id,
                    ColonyStrenght = b.Inspections
                                   .OrderByDescending(i => i.DayOfInspection)
                                   .Select(i => new
                                   {
                                       i.Strenght
                                   })
                                   .First()
                })
                .ToArrayAsync();

            double beeColoniesAverageStrenght = beeColoniesStrenght.Average(a => a.ColonyStrenght.Strenght);

            return new StatisticsViewModel()
            {
                TotalIncome = totalIncome,
                TotalCost = totalCost,
                FinancialResult = financialResult,
                ApiariesCount = apiariesCount,
                BeeColoniesCount = beeColoniesCount,
                BeeColoniesAverageStrenght = beeColoniesAverageStrenght
            };
        }
    }
}
