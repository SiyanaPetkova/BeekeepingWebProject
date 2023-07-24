namespace Beekeeping.Services.Interfaces
{
    using Beekeeping.Models.Apiary;
    using Beekeeping.Models.Income;

    public interface IIncomeService
    {
        Task<IEnumerable<IncomeViewModel>?> AllIncomesAsync(string ownerId);
    }
}