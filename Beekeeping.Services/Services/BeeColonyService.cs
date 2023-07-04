namespace Beekeeping.Services.Services
{
    using Beekeeping.Data;
    using Beekeeping.Data.Models;
    using Beekeeping.Models.BeeColony;
    using Beekeeping.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class BeeColonyService : IBeeColonyService
    {
        private readonly BeekeepingDbContext context;

        public BeeColonyService(BeekeepingDbContext context)
        {
            this.context = context;
        }

        public async Task AddNewBeeColonyAsync(BeeColonyFormModel model, string ownerId)
        {
            var apiaryForUser = await context.Apiaries.FirstOrDefaultAsync(a => a.OwnerId == ownerId);

            if (apiaryForUser == null)
            {
                throw new InvalidOperationException();
            }

            var beeQueen = new BeeQueen()
            {
                Breeder = model.BeeQueen.Breeder,
                BeeQueenType = model.BeeQueen.BeeQueenType,
                BeeQueenYearOfBirth = model.BeeQueen.BeeQueenYearOfBirth
            };

            var beeColony = new BeeColony()
            {
                PlateNumber = model.PlateNumber,
                AdditionalComмent = model.AdditionalComment,
                TypeOfBroodBox = model.TypeOfBroodBox,
                Super = model.Super,
                NumberOfSupers = model.NumberOfSupers,
                SecondBroodBox = model.SecondBroodBox,
                NumberOfAdditionalBoxes = model.NumberOfAdditionalBoxes,
                MatedBeeQueen = model.MatedBeeQueen,
                OwnerOfTheApiary = ownerId,
                ApiaryId = apiaryForUser.Id,
                BeeQueen = beeQueen
            };
            
            await context.BeeColonies.AddAsync(beeColony);
            await context.BeeQueens.AddAsync(beeQueen);
            await context.SaveChangesAsync();
        }
    }
}