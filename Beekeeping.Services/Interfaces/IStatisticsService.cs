namespace Beekeeping.Services.Interfaces
{
    using Models.Statistics;

    public interface IStatisticsService
    {
        Task<StatisticsViewModel> GetStatisticsForUserAsync(string userId);
    }
}