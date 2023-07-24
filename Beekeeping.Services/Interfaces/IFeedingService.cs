namespace Beekeeping.Services.Interfaces
{
    using Beekeeping.Models.HiveFeeding;

    public interface IFeedingService
    {
        Task<IEnumerable<HiveFeedingViewModel>?> AllFeedingsAsync(string userId);

        Task AddFeedingAsync(HiveFeedingFormModel model, string userId);

        Task DeleteFeedingAsync(string ownerId, int id);

        Task<bool> DoesFeedingExists(string ownerId, int id);
        
    }
}