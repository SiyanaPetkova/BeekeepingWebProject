namespace Beekeeping.Services.Services
{
    using Beekeeping.Data;
    using Beekeeping.Models.HiveTreatment;
    using Beekeeping.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class TreatmentService : ITreatmentService
    {
        private readonly BeekeepingDbContext context;

        public TreatmentService(BeekeepingDbContext dbcontext)
        {
            this.context = dbcontext;

        }
        public async Task<IEnumerable<HiveTreatmentViewModel>?> AllTreatmentsAsync(string userId)
        {
            bool doesUserHasTreatmentsAdded = await context.HiveTreatments.AnyAsync(a => a.CreatorId == userId);

            if (!doesUserHasTreatmentsAdded)
            {
                return null;
            }

            return await context.HiveTreatments
                                .Where(t => t.CreatorId == userId)                                
                                .Select(t => new HiveTreatmentViewModel()
                                {
                                    Id = t.Id,
                                   TreatmentDate = t.TreatmentDate,
                                   MedicationName = t.MedicationName,
                                   ActiveIngredient = t.ActiveIngredient,
                                   PriceOfTheTreatment = t.PriceOfTheTreatment,
                                   ResultAndCommentAboutTheTreatment = t.ResultAndCommentAboutTheTreatment,
                                   CreatorId = userId
                                })
                                .ToArrayAsync();
        }
    }
}