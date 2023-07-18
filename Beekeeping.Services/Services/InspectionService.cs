namespace Beekeeping.Services.Services
{
    using Beekeeping.Data;
    using Beekeeping.Data.Models;
    using Beekeeping.Models.Inspection;
    using Beekeeping.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
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
                BeeColonyId = model.BeeColonyId
            };

            await dbcontext.Inspections.AddAsync(inspection);
            await dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<InspectionViewModel>?> AllInspectionsPerColonyAsync(string ownerId, int beeColonyId)
        {
            var allInspectionsAsync = await dbcontext.Inspections.Where(i => i.BeeColonyId == beeColonyId)
                             .Select(i => new InspectionViewModel
                             {
                                 Id = i.Id,
                                 DayOfInspection = i.DayOfInspection,
                                 NumberOfFrames = i.NumberOfFrames,
                                 NumberOfBroodFrames = i.NumberOfBroodFrames,
                                 Strenght = i.Strenght,
                                 BeeColonyId = i.BeeColonyId
                             })
                             .OrderByDescending(i => i.DayOfInspection)
                             .ToArrayAsync();

            return allInspectionsAsync;
        }

        public async Task EditInspectionAsync(InspectionFormModel model, string ownerId, int id)
        {
            var inspection = await dbcontext.Inspections
                                .FirstOrDefaultAsync(i => i.Id == id && i.BeeColony!.OwnerOfTheApiary == ownerId);

            if (inspection == null)
            {
                throw new InvalidOperationException();
            }

            inspection.DayOfInspection = model.DayOfInspection;
            inspection.NumberOfFrames = model.NumberOfFrames;
            inspection.NumberOfBroodFrames = model.NumberOfBroodFrames;
            inspection.Temperament = model.Temperament;
            inspection.Strenght = model.Strenght;
            inspection.Description = model.Description;

            await dbcontext.SaveChangesAsync();
        }

        public async Task<InspectionFormModel> GetInspectionForEditAsync(string ownerId, int id)
        {
            var inspection = await dbcontext.Inspections
                                .FirstOrDefaultAsync(i => i.Id == id && i.BeeColony!.OwnerOfTheApiary == ownerId);

            if (inspection == null)
            {
                throw new InvalidOperationException();
            }

            return new InspectionFormModel
            {
                Id = id,
                DayOfInspection = inspection.DayOfInspection,
                NumberOfFrames = inspection.NumberOfFrames,
                NumberOfBroodFrames = inspection.NumberOfBroodFrames,
                Strenght = inspection.Strenght,
                Temperament = inspection.Temperament,
                Description = inspection.Description,
                BeeColonyId = inspection.BeeColonyId
            };
        }

        public async Task<InspectionViewModel?> GetDetailsForTheInspectionAsync(string ownerId, int id)
        {
            var inspection = await dbcontext.Inspections.Where(i => i.Id == id && i.BeeColony!.OwnerOfTheApiary == ownerId)
                .Select(i => new InspectionViewModel
                {
                    Id = i.Id,
                    DayOfInspection = i.DayOfInspection,
                    NumberOfFrames = i.NumberOfFrames,
                    NumberOfBroodFrames = i.NumberOfBroodFrames,
                    Strenght = i.Strenght,
                    Temperament = i.Temperament,
                    Description = i.Description
                })
                .FirstOrDefaultAsync();

            return inspection;
        }

        public async Task<bool> DoesInspectionExist(string userId, int id)
        {
            var inspection = await dbcontext.Inspections
                                 .FirstOrDefaultAsync(i => i.Id == id && i.BeeColony!.OwnerOfTheApiary == userId);

            if (inspection == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task DeleteInspectionAsync(string userId, int id)
        {
            var inspection = await dbcontext.Inspections
                              .FirstOrDefaultAsync(i => i.Id == id && i.BeeColony!.OwnerOfTheApiary == userId);

            if (inspection == null)
            {
                throw new InvalidOperationException();
            }

            dbcontext.Inspections.Remove(inspection);
            await dbcontext.SaveChangesAsync();
        }
    }
}