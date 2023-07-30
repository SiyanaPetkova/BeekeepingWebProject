namespace Beekeeping.Services.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Data;
    using Data.Models;
    using Models.Inspection;
    using Interfaces;

    public class InspectionService : IInspectionService
    {
        private readonly BeekeepingDbContext context;

        public InspectionService(BeekeepingDbContext dbcontext)
        {
            this.context = dbcontext;

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

            await context.Inspections.AddAsync(inspection);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<InspectionViewModel>?> AllInspectionsPerColonyAsync(string ownerId, int beeColonyId)
        {
            var allInspectionsAsync = await context.Inspections.Where(i => i.BeeColonyId == beeColonyId)
                             .Select(i => new InspectionViewModel
                             {
                                 Id = i.Id,
                                 DayOfInspection = i.DayOfInspection.ToLongDateString(),
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
            var inspection = await context.Inspections
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

            await context.SaveChangesAsync();
        }

        public async Task<InspectionFormModel> GetInspectionForEditAsync(string ownerId, int id)
        {
            var inspection = await context.Inspections
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
            var inspection = await context.Inspections.Where(i => i.Id == id && i.BeeColony!.OwnerOfTheApiary == ownerId)
                .Select(i => new InspectionViewModel
                {
                    Id = i.Id,
                    DayOfInspection = i.DayOfInspection.ToLongDateString(),
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
            var inspection = await context.Inspections
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
            var inspection = await context.Inspections
                              .FirstOrDefaultAsync(i => i.Id == id && i.BeeColony!.OwnerOfTheApiary == userId);

            if (inspection == null)
            {
                throw new InvalidOperationException();
            }

            context.Inspections.Remove(inspection);
            await context.SaveChangesAsync();
        }

        public async Task<int> GetCurrentInspectionBeeColonyId(string userId, int id)
        {
            var inspection = await context.Inspections
                             .FirstOrDefaultAsync(i => i.Id == id && i.BeeColony!.OwnerOfTheApiary == userId);

            return inspection!.BeeColonyId;
        }
    }
}