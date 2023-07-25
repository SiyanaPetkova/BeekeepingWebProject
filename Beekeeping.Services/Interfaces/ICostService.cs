namespace Beekeeping.Services.Interfaces
{
    using Beekeeping.Models.Cost;

    public interface ICostService
    {
        Task<IEnumerable<CostViewModel>?> AllCostAsync(string ownerId);
    }
}