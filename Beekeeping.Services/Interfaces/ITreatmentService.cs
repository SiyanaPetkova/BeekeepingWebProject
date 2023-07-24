namespace Beekeeping.Services.Interfaces
{
    using Beekeeping.Models.HiveTreatment;

    public interface ITreatmentService
    {
        Task<IEnumerable<HiveTreatmentViewModel>?> AllTreatmentsAsync(string ownerId);

        Task AddTreatmentAsync(HiveTreatmentFormModel model, string userId);

        Task DeleteTreatmentAsync(string ownerId, int id);

        Task<bool> DoesTreatmentExists(string ownerId, int id);
    }
}