﻿namespace Beekeeping.Services.Interfaces
{
    using Beekeeping.Models.HiveTreatment;

    public interface ITreatmentService
    {
        Task<IEnumerable<HiveTreatmentViewModel>?> AllTreatmentsAsync(string ownerId);

        Task AddTreatmentAsync(HiveTreatmentFormModel model, string userId);
    }
}