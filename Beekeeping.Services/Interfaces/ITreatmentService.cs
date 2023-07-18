namespace Beekeeping.Services.Interfaces
{
    using Beekeeping.Models.Event;

    public interface ITreatmentService
    {
        Task<IEnumerable<HiveTreatmentViewModel>?> AllTreatmentsAsync(string ownerId);
    }
}