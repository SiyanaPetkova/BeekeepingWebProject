namespace Beekeeping.Services.Services
{
    using Beekeeping.Data;
    using Beekeeping.Data.Models;
    using Beekeeping.Models.Inspection;
    using Beekeeping.Services.Interfaces;
    using System.Threading.Tasks;

    public class InspectionService : IInspectionService
    {
        private readonly BeekeepingDbContext dbcontext;

        public InspectionService(BeekeepingDbContext dbcontext)
        {
            this.dbcontext = dbcontext;

        }

        public async Task AddNewInspectionAsync(InspectionFormModel model, string ownerId)
        {
            var inspection = new Inspection()
            {
                DayOfInspection = model.DayOfInspection,
                Description = model.Description,
                NumberOfFrames = model.NumberOfFrames,
                NumberOfBroodFrames = model.NumberOfBroodFrames,
                Strenght = model.Strenght,
                Temperament = model.Temperament,
                BeeQueenYearOfBirth = model.BeeQueenYearOfBirth,
                BeeColonyId = model.BeeColonyId
            };

            await dbcontext.Inspections.AddAsync(inspection);
            await dbcontext.SaveChangesAsync();
        }
    }
}