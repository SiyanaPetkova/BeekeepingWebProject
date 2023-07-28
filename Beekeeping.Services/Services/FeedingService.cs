namespace Beekeeping.Services.Services
{
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Models;
    using Models.HiveFeeding;
    using Interfaces;

    public class FeedingService : IFeedingService
    {
        private readonly BeekeepingDbContext context;

        public FeedingService(BeekeepingDbContext dbcontext)
        {
            this.context = dbcontext;

        }
        public async Task<IEnumerable<HiveFeedingViewModel>?> AllFeedingsAsync(string userId)
        {
            bool doesUserHasFeedingsAdded = await context.HiveFeeding.AnyAsync(a => a.CreatorId == userId);

            if (!doesUserHasFeedingsAdded)
            {
                return null;
            }

           return await context.HiveFeeding
                                .Where(f => f.CreatorId == userId)
                                .OrderByDescending(f => f.DayOfFeeding)
                                .Select(f => new HiveFeedingViewModel()
                                {
                                    Id = f.Id,
                                    FeedingType = f.FeedingType,
                                    NumberOfBeeHives = f.NumberOfBeeHives,
                                    PriceOfFeeding = f.PriceOfFeeding,
                                    DayOfFeeding = f.DayOfFeeding,
                                    CreatorId = userId

                                })
                                .ToArrayAsync();

        }

        public async Task AddFeedingAsync(HiveFeedingFormModel model, string userId)
        {
            var feeding = new HiveFeeding()
            {
            DayOfFeeding = model.DayOfFeeding,
            FeedingType = model.FeedingType,
            NumberOfBeeHives = model.NumberOfBeeHives,
            PriceOfFeeding =model.PriceOfFeeding,
            CreatorId = userId
            };

            var cost = new Cost()
            {
                DayOfTheCost = feeding.DayOfFeeding,
                CostValue = feeding.PriceOfFeeding,
                TypeOfCost = feeding.FeedingType,
                CreatorId = userId
            };

            await context.Costs.AddAsync(cost);
            await context.HiveFeeding.AddAsync(feeding);
            await context.SaveChangesAsync();
        }

        public async Task DeleteFeedingAsync(string ownerId, int id)
        {
            var feeding = await context.HiveFeeding
                           .FirstOrDefaultAsync(f => f.Id == id && f.CreatorId == ownerId);

            if (feeding == null)
            {
                throw new InvalidOperationException();
            }

            context.HiveFeeding.Remove(feeding);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DoesFeedingExists(string ownerId, int id)
        {
            return await context.HiveFeeding
               .AnyAsync(f => f.Id == id && f.CreatorId == ownerId);
        }
    }
}