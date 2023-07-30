namespace Beekeeping.Services.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Data;
    using Data.Models;
    using Models.Income;
    using Interfaces;

    public class IncomeService : IIncomeService
    {
        private readonly BeekeepingDbContext context;

        public IncomeService(BeekeepingDbContext context)
        {
            this.context = context;
        }

        public async Task AddIncomeAsync(IncomeFormModel model, string userId)
        {
            var income = new Income()
            {
                DayOfTheIncome = model.DayOfTheIncome,
                TypeOfIncome = model.TypeOfIncome,
                IncomeValue = model.IncomeValue,
                CreatorId = userId
            };

            await context.Incomes.AddAsync(income);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<IncomeViewModel>?> AllIncomesAsync(string userId)
        {
            return await context.Incomes
                                 .Where(i => i.CreatorId == userId)
                                 .OrderByDescending(i => i.DayOfTheIncome)
                                 .Select(i => new IncomeViewModel()
                                 {
                                     Id = i.Id,
                                     DayOfTheIncome = i.DayOfTheIncome.ToLongDateString(),
                                     TypeOfIncome = i.TypeOfIncome,
                                     IncomeValue = i.IncomeValue,
                                     CreatorId = userId
                                 })
                                 .ToArrayAsync();
        }

        public async Task DeleteIncomeAsync(string userId, int id)
        {
            var income = await context.Incomes
                           .FirstOrDefaultAsync(f => f.Id == id && f.CreatorId == userId);

            if (income == null)
            {
                throw new InvalidOperationException();
            }

            context.Incomes.Remove(income);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DoesIncomeExists(string userId, int id)
        {
            return await context.Incomes
              .AnyAsync(f => f.Id == id && f.CreatorId == userId);
        }
    }
}