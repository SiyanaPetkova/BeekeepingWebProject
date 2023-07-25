namespace Beekeeping.Services.Interfaces
{
    using Beekeeping.Models.Income;

    public interface IIncomeService
    {
        Task AddIncomeAsync(IncomeFormModel model, string userId);
        Task<IEnumerable<IncomeViewModel>?> AllIncomesAsync(string ownerId);
    }
}