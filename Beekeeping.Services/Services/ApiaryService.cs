namespace Beekeeping.Services.Services
{
    using Beekeeping.Data;
    using Beekeeping.Data.Models;
    using Beekeeping.Models.Apiary;
    using Beekeeping.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ApiaryService : IApiaryService
    {
        private readonly BeekeepingDbContext context;

        public ApiaryService(BeekeepingDbContext context)
        {
            this.context = context;
        }

        public async Task AddNewApiaryAsync(ApiaryFormModel model, string ownerId)
        {
            var apiary = new Apiary()
            {
                Name = model.Name,
                RegistrationNumber = model.RegistrationNumber,
                Location = model.Location,
                OwnerId = ownerId
            };

            await context.Apiaries.AddAsync(apiary);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ApiaryViewModel>?> AllApiaryAsync(string ownerId)
        {
            bool doesOwnerHasApiariesAdded = await context.Apiaries.AnyAsync(a => a.OwnerId == ownerId);

            if (!doesOwnerHasApiariesAdded)
            {
                return null;
            }

            return await context.Apiaries
                                            .Where(o => o.OwnerId == ownerId)
                                            .Include(o => o.BeeHives)
                                            .Select(o => new ApiaryViewModel()
                                            {
                                                Id = o.Id,
                                                Name = o.Name,
                                                Location = o.Location,
                                                RegistrationNumber = o.RegistrationNumber,
                                                NumberOfHives = o.BeeHives.Where(b => b.ApiaryId == o.Id).Count(),
                                                OwnerId = o.OwnerId
                                            })
                                            .ToArrayAsync();

        }

        public async Task DeleteApiaryAsync(string ownerId, int id)
        {
            var apiary = await context.Apiaries
                               .FirstOrDefaultAsync(a => a.Id == id && a.OwnerId == ownerId);

            if (apiary == null)
            {
                throw new InvalidOperationException();
            }

            context.Apiaries.Remove(apiary);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DoesApiaryExists(string ownerId, int id)
        {
            return await context.Apiaries
                .AnyAsync(a => a.Id == id && a.OwnerId == ownerId);
        }

        public async Task EditApiaryAsync(ApiaryEditFormModel model, int id, string ownerId)
        {
            var apiary = await context.Apiaries
                                .FirstOrDefaultAsync(a => a.Id == id && a.OwnerId == ownerId);

            if (apiary == null)
            {
                throw new InvalidOperationException();
            }

            apiary.Name = model.Name;
            apiary.Location = model.Location;
            apiary.RegistrationNumber = model.RegistrationNumber;

            await context.SaveChangesAsync();
        }

        public async Task<ApiaryEditFormModel> GetApiaryForEditAsync(string ownerId, int apiaryId)
        {
            var apiary = await context.Apiaries
                                .FirstOrDefaultAsync(a => a.Id == apiaryId && a.OwnerId == ownerId);

            if (apiary == null)
            {
                throw new InvalidOperationException();
            }

            return new ApiaryEditFormModel
            {
                Id = apiaryId,
                Name = apiary.Name,
                Location = apiary.Location,
                RegistrationNumber = apiary.RegistrationNumber
            };
        }

        public async Task<bool> IsTheUserOwner(string ownerId)
        {
            var apiary = await context.Apiaries.FirstOrDefaultAsync(a => a.OwnerId == ownerId);

            if (apiary == null)
            {
                return false;
            }

            return true;
        }


    }
}