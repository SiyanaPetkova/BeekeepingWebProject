namespace Beekeeping.Services.Services
{
    using Beekeeping.Data;
    using Beekeeping.Data.Models;
    using Beekeeping.Models.HiveFeeding;
    using Beekeeping.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;

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

            await context.HiveFeeding.AddAsync(feeding);
            await context.SaveChangesAsync();
        }
    }
}