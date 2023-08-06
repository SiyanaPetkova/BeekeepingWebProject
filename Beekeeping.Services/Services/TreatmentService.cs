namespace Beekeeping.Services.Services
{
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Models;
    using Models.HiveTreatment;
    using Interfaces;

    public class TreatmentService : ITreatmentService
    {
        private readonly BeekeepingDbContext context;

        public TreatmentService(BeekeepingDbContext dbcontext)
        {
            this.context = dbcontext;

        }

        public async Task AddTreatmentAsync(HiveTreatmentFormModel model, string userId)
        {
            var treatment = new HiveTreatment()
            {
                TreatmentDate = model.TreatmentDate,
                MedicationName = model.MedicationName,
                ActiveIngredient = model.ActiveIngredient,
                PriceOfTheTreatment = model.PriceOfTheTreatment,
                NumberOfTreatedColonies = model.NumberOfTreatedColonies,
                ResultAndCommentAboutTheTreatment = model.ResultAndCommentAboutTheTreatment,
                CreatorId = userId
            };

            var cost = new Cost()
            {
                DayOfTheCost = treatment.TreatmentDate,
                CostValue = treatment.PriceOfTheTreatment,
                TypeOfCost = treatment.MedicationName,
                CreatorId = userId
            };

            await context.Costs.AddAsync(cost);
            await context.HiveTreatments.AddAsync(treatment);
            await context.SaveChangesAsync();
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
                                .OrderByDescending(t => t.TreatmentDate)
                                .Select(t => new HiveTreatmentViewModel()
                                {
                                    Id = t.Id,
                                    TreatmentDate = t.TreatmentDate.ToLongDateString(),
                                    MedicationName = t.MedicationName,
                                    ActiveIngredient = t.ActiveIngredient,
                                    PriceOfTheTreatment = t.PriceOfTheTreatment,
                                    ResultAndCommentAboutTheTreatment = t.ResultAndCommentAboutTheTreatment,
                                    CreatorId = userId
                                })
                                .ToArrayAsync();
        }

        public async Task DeleteTreatmentAsync(string ownerId, int id)
        {
            var treatment = await context.HiveTreatments
                              .FirstOrDefaultAsync(t => t.Id == id && t.CreatorId == ownerId);

            if (treatment == null)
            {
                throw new InvalidOperationException();
            }

            context.HiveTreatments.Remove(treatment);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DoesTreatmentExists(string ownerId, int id)
        {

            return await context.HiveTreatments
               .AnyAsync(t => t.Id == id && t.CreatorId == ownerId);
        }
    }
}