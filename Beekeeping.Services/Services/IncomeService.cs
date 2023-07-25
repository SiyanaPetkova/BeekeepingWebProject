namespace Beekeeping.Services.Services
{
    using Beekeeping.Data;
    using Beekeeping.Models.Income;
    using Beekeeping.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class IncomeService : IIncomeService
    {
        private readonly BeekeepingDbContext context;

        public IncomeService(BeekeepingDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<IncomeViewModel>?> AllIncomesAsync(string userId)
        {
            return await context.Incomes
                                 .Where(i => i.CreatorId == userId)
                                 .OrderByDescending(i => i.DayOfTheIncome)
                                 .Select(i => new IncomeViewModel()
                                 {
                                     Id = i.Id,
                                     DayOfTheIncome = i.DayOfTheIncome,
                                     TypeOfIncome = i.TypeOfIncome,
                                     IncomeValue = i.IncomeValue,
                                     CreatorId = userId
                                 })
                                 .ToArrayAsync();
        }
    }
}