namespace Beekeeping.Services.Interfaces
{
    using Beekeeping.Models.Event;

    public interface IFeedingService
    {
        Task<IEnumerable<HiveFeedingViewModel>?> AllFeedingsAsync(string ownerId);
    }
}