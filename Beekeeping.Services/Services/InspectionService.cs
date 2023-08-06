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
           return await context.Inspections.Where(i => i.BeeColonyId == beeColonyId)
                             .OrderByDescending(i => i.DayOfInspection)
                             .Select(i => new InspectionViewModel
                             {
                                 Id = i.Id,
                                 Description = i.Description,
                                 DayOfInspection = i.DayOfInspection.ToLongDateString(),
                                 NumberOfFrames = i.NumberOfFrames,
                                 NumberOfBroodFrames = i.NumberOfBroodFrames,
                                 Strenght = i.Strenght,
                                 Temperament = i.Temperament,
                                 BeeColonyId = i.BeeColonyId
                             })
                             .ToArrayAsync();
        }

        public async Task EditInspectionAsync(InspectionFormModel model, string ownerId, int id)
        {
            var inspection = await context.Inspections
                                .FirstOrDefaultAsync(i => i.Id == id && i.BeeColony!.OwnerOfTheApiary == ownerId) 
                                ?? throw new InvalidOperationException();

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

            return inspection == null
                   ? throw new InvalidOperationException()
                   : new InspectionFormModel
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
            return await context.Inspections.Where(i => i.Id == id && i.BeeColony!.OwnerOfTheApiary == ownerId)
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
        }

        public async Task<bool> DoesInspectionExist(string userId, int id)
        {
           return await context.Inspections
                                .AnyAsync(i => i.Id == id && i.BeeColony!.OwnerOfTheApiary == userId);
        }

        public async Task DeleteInspectionAsync(string userId, int id)
        {
            var inspection = await context.Inspections
                              .FirstOrDefaultAsync(i => i.Id == id && i.BeeColony!.OwnerOfTheApiary == userId) 
                              ?? throw new InvalidOperationException();

            context.Inspections.Remove(inspection);
            await context.SaveChangesAsync();
        }

        public async Task<int> GetCurrentInspectionBeeColonyId(string userId, int id)
        {
            var inspection = await context.Inspections
                             .FirstOrDefaultAsync(i => i.Id == id && i.BeeColony!.OwnerOfTheApiary == userId)
                             ?? throw new InvalidOperationException();

            return inspection!.BeeColonyId;
        }
    }
}