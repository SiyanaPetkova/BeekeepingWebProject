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

            double beeColoniesAverageStrenght = 0;

            if (beeColoniesCount > 0)
            {
                var doesInspectionsExist = await context.Inspections
                    .AnyAsync(i => i.BeeColony!.OwnerOfTheApiary == userId);

                if (doesInspectionsExist)
                {
                    var inspectionsStrenght = await context.Inspections
                        .Where(i => i.BeeColony!.OwnerOfTheApiary == userId)
                        .AverageAsync(i => i.Strenght);

                    beeColoniesAverageStrenght = inspectionsStrenght;
                }            
            }                      

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
