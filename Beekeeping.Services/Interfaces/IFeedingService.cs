namespace Beekeeping.Services.Interfaces
{
    using Beekeeping.Models.HiveFeeding;

    public interface IFeedingService
    {
        Task<IEnumerable<HiveFeedingViewModel>?> AllFeedingsAsync(string userId);

        Task AddFeedingAsync(HiveFeedingFormModel model, string userId);
    }
}