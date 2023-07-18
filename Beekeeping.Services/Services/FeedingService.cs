namespace Beekeeping.Services.Services
{
    using Beekeeping.Data;
    using Beekeeping.Models.Event;
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
    }
}