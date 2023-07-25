namespace Beekeeping.Services.Interfaces
{
    using Beekeeping.Models.Cost;

    public interface ICostService
    {
        Task AddCostAsync(CostFormModel model, string userId);
        Task<IEnumerable<CostViewModel>?> AllCostAsync(string ownerId);
    }
}