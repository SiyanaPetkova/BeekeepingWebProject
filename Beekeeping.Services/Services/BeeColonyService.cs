namespace Beekeeping.Services.Services
{
    using Beekeeping.Data;
    using Beekeeping.Data.Models;
    using Beekeeping.Models.Apiary;
    using Beekeeping.Models.BeeColony;
    using Beekeeping.Models.BeeQueen;
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
                ApiaryId = model.ApiaryId,
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

            if (allColoniesAsync == null)
            {

            }

            return allColoniesAsync;
        }

        public async Task DeleteBeeColonyAsync(string userId, int id)
        {
            var beeColony = await context.BeeColonies.FirstOrDefaultAsync(b => b.Id == id && b.OwnerOfTheApiary == userId);

            if (beeColony == null)
            {
                throw new InvalidOperationException();
            }

            context.BeeColonies.Remove(beeColony);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DoesBeeColonyExist(string userId, int id)
        {
            return await context.BeeColonies.AnyAsync(b => b.OwnerOfTheApiary == userId && b.Id == id);
        }

        public async Task EditBeeColonyAsync(BeeColonyFormModel model, string ownerId, int colonyId)
        {
            var beeColony = await context.BeeColonies
                               .FirstOrDefaultAsync(a => a.Id == colonyId && a.OwnerOfTheApiary == ownerId);

            if (beeColony == null)
            {
                throw new InvalidOperationException();
            }

            var beeQueen = await context.BeeQueens.FindAsync(beeColony.BeeQueenId);

            beeQueen.Breeder = model.BeeQueen.Breeder;
            beeQueen.BeeQueenYearOfBirth = model.BeeQueen.BeeQueenYearOfBirth;
            beeQueen.BeeQueenType = model.BeeQueen.BeeQueenType;

            beeColony.BeeQueen = beeQueen;
            beeColony.PlateNumber = model.PlateNumber;
            beeColony.AdditionalComмent = model.AdditionalComment;
            beeColony.Super = model.Super;
            beeColony.NumberOfSupers = model.NumberOfSupers;
            beeColony.SecondBroodBox = model.SecondBroodBox;
            beeColony.NumberOfAdditionalBoxes = model.NumberOfAdditionalBoxes;
            beeColony.MatedBeeQueen = model.MatedBeeQueen;
            beeColony.ApiaryId = model.ApiaryId;

            await context.SaveChangesAsync();
        }

        public async Task<BeeColonyFormModel> GetBeeColonyForEditAsync(string ownerId, int colonyId)
        {
            var beeColony = await context.BeeColonies
                                .FirstOrDefaultAsync(a => a.Id == colonyId && a.OwnerOfTheApiary == ownerId);

            if (beeColony == null)
            {
                throw new InvalidOperationException();
            }

            var beeQueen = await context.BeeQueens
                                .Where(b => b.Id == beeColony.BeeQueenId)
                                .Select(b => new BeeQueenFormModel()
                                 {
                                     Breeder = b.Breeder,
                                     BeeQueenType = b.BeeQueenType,
                                     BeeQueenYearOfBirth = b.BeeQueenYearOfBirth
                                 })
                                .FirstOrDefaultAsync();

            return new BeeColonyFormModel
            {
                Id = colonyId,
                PlateNumber = beeColony.PlateNumber,
                AdditionalComment = beeColony.AdditionalComмent,
                TypeOfBroodBox = beeColony.TypeOfBroodBox,
                Super = beeColony.Super,
                NumberOfSupers = beeColony.NumberOfSupers,
                SecondBroodBox = beeColony.SecondBroodBox,
                NumberOfAdditionalBoxes = beeColony.NumberOfAdditionalBoxes,
                MatedBeeQueen = beeColony.MatedBeeQueen,
                BeeQueenId = beeColony.BeeQueenId,
                BeeQueen = beeQueen
            };
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