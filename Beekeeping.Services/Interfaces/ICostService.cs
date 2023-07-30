namespace Beekeeping.Services.Interfaces
{
    using Beekeeping.Models.Cost;

    public interface ICostService
    {
        Task AddCostAsync(CostFormModel model, string userId);

        Task<IEnumerable<CostViewModel>?> AllCostAsync(string ownerId);

        Task DeleteCostAsync(string userId, int id);

        Task<bool> DoesCostExists(string userId, int id);

        Task<decimal> GetTotalCostAsync(string userId);
    }
}