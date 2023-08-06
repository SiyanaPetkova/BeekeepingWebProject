namespace Beekeeping.Services.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Data;
    using Data.Models;
    using Models.Cost;
    using Interfaces;
  
    public class CostService : ICostService
    {
        private readonly BeekeepingDbContext context;

        public CostService(BeekeepingDbContext context)
        {
            this.context = context;
        }

        public async Task AddCostAsync(CostFormModel model, string userId)
        {
            var cost = new Cost()
            {
                DayOfTheCost = model.DayOfTheCost,
                TypeOfCost = model.TypeOfCost,
                CostValue = model.CostValue,
                CreatorId = userId
            };

            await context.Costs.AddAsync(cost);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CostViewModel>?> AllCostAsync(string userId)
        {         
            return await context.Costs
                                .Where(c => c.CreatorId == userId)
                                .OrderByDescending(f => f.DayOfTheCost)
                                .Select(c => new CostViewModel()
                                {
                                    Id = c.Id,
                                    DayOfTheCost = c.DayOfTheCost.ToLongDateString(),
                                    CostValue = c.CostValue,
                                    TypeOfCost = c.TypeOfCost,
                                    CreatorId = userId
                                })
                                .ToArrayAsync();
        }

        public async Task DeleteCostAsync(string userId, int id)
        {
            var cost = await context.Costs
                           .FirstOrDefaultAsync(f => f.Id == id && f.CreatorId == userId)
                           ?? throw new InvalidOperationException();
                          
            context.Costs.Remove(cost);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DoesCostExists(string userId, int id)
        {
            return await context.Costs
                         .AnyAsync(f => f.Id == id && f.CreatorId == userId);
        }

        public async Task<decimal> GetTotalCostAsync(string userId)
        {
            return await context.Costs.Where(i => i.CreatorId == userId).SumAsync(i => i.CostValue);
        }
    }
}
