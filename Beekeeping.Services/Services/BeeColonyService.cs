namespace Beekeeping.Services.Services
{
    using Beekeeping.Data;
    using Beekeeping.Data.Models;
    using Beekeeping.Models.BeeColony;
    using Beekeeping.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
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

        public async Task<IEnumerable<BeeColonyViewModel>?> AllColoniesAsync(string ownerId, int apiaryId)
        {
            var allColoniesAsync = await context.BeeColonies.Where(b => b.OwnerOfTheApiary == ownerId && b.ApiaryId == apiaryId)
                .Include(b => b.BeeQueen)
                .Include(b => b.Apiary)
                .Select(b => new BeeColonyViewModel
                {
                    Id = b.Id,
                    PlateNumber = b.PlateNumber,
                    AdditionalComмent = b.AdditionalComмent,
                    TypeOfBroodBox = b.TypeOfBroodBox,
                    Super = b.Super == true ? "Има" : "Няма",
                    NumberOfSupers = b.NumberOfSupers,
                    SecondBroodBox = b.SecondBroodBox == true ? "Има" : "Няма",
                    NumberOfAdditionalBoxes = b.NumberOfAdditionalBoxes,
                    MatedBeeQueen = b.MatedBeeQueen == true ? "Има" : "Няма",
                    Apiary = b.Apiary.Name,
                    BeeQueen = new Models.BeeQueen.BeeQueenSelectViewModel()
                    {
                        BeeQueenYearOfBirth = b.BeeQueen.BeeQueenYearOfBirth,
                        Breeder = b.BeeQueen.Breeder,
                        BeeQueenType = b.BeeQueen.BeeQueenType
                    }
                })
               .ToArrayAsync();

            return allColoniesAsync;
        }

        public async Task<BeeColonyViewModel> GetDetailsForTheBeeColonyAsync(string ownerId, int colonyId)
        {
            var findColony = await context.BeeColonies.FirstOrDefaultAsync(b => b.OwnerOfTheApiary == ownerId && b.Id == colonyId);


            var beeColony = await context.BeeColonies.Where(b => b.OwnerOfTheApiary == ownerId && b.Id == colonyId)
               .Include(b => b.BeeQueen)
               .Include(b => b.Apiary)
               .Select(b => new BeeColonyViewModel
               {
                   Id = b.Id,
                   PlateNumber = b.PlateNumber,
                   AdditionalComмent = b.AdditionalComмent,
                   TypeOfBroodBox = b.TypeOfBroodBox,
                   Super = b.Super == true ? "Има" : "Няма",
                   NumberOfSupers = b.NumberOfSupers,
                   SecondBroodBox = b.SecondBroodBox == true ? "Има" : "Няма",
                   NumberOfAdditionalBoxes = b.NumberOfAdditionalBoxes,
                   MatedBeeQueen = b.MatedBeeQueen == true ? "Има" : "Няма",
                   Apiary = b.Apiary.Name,
                   BeeQueen = new Models.BeeQueen.BeeQueenSelectViewModel()
                   {
                       BeeQueenYearOfBirth = b.BeeQueen.BeeQueenYearOfBirth,
                       Breeder = b.BeeQueen.Breeder,
                       BeeQueenType = b.BeeQueen.BeeQueenType
                   }
               })
              .FirstOrDefaultAsync();

            if (beeColony == null)
            {
                throw new InvalidOperationException();
            }

            return beeColony;
        }

        public async Task<bool> IsTheUserOwner(string ownerId)
        {
            var colonies = await context.BeeColonies.Where(a => a.OwnerOfTheApiary == ownerId).ToArrayAsync();

            if (colonies == null)
            {
                return false;
            }

            return true;
        }
    }
}