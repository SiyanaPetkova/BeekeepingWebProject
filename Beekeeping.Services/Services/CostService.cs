namespace Beekeeping.Services.Services
{
    using Beekeeping.Data;
    using Beekeeping.Models.Cost;
    using Beekeeping.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CostService : ICostService
    {
        private readonly BeekeepingDbContext context;

        public CostService(BeekeepingDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<CostViewModel>?> AllCostAsync(string userId)
        {
            return await context.Costs
                                .Where(c => c.CreatorId == userId)
                                .OrderByDescending(f => f.DayOfTheCost)
                                .Select(c => new CostViewModel()
                                {
                                    Id = c.Id,
                                    DayOfTheCost = c.DayOfTheCost,
                                    CostValue = c.CostValue,
                                    TypeOfCost = c.TypeOfCost,
                                    CreatorId = userId
                              
                                })
                                .ToArrayAsync();                              
        }
    }
}
