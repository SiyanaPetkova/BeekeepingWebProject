namespace Beekeeping.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
 
    using Data.Models;

    public class BeeColonyEntityConfiguration : IEntityTypeConfiguration<BeeColony>
    {
        public void Configure(EntityTypeBuilder<BeeColony> builder)
        {
            builder.HasData(GenerateBeeColonies());
        }

        private static BeeColony[] GenerateBeeColonies()
        {
            ICollection<BeeColony> beeColonies = new HashSet<BeeColony>();

            BeeColony beeColony;

            beeColony = new BeeColony()
            {
                Id = 10001,
                PlateNumber = "100-4447",
                AdditionalComмent = "Основно семейство",
                TypeOfBroodBox = "Многокорпусен",
                SecondBroodBox = true,
                NumberOfAdditionalBoxes = 1,
                Super = true,
                NumberOfSupers = 1,
                MatedBeeQueen = true,
                OwnerOfTheApiary = "44C36B39-AD0A-4260-B448-45BB03158888",
                ApiaryId = 9150,
                BeeQueenId = 10001
            };

            beeColonies.Add(beeColony);

            beeColony = new BeeColony()
            {
                Id = 10002,
                PlateNumber = "100-4448",
                AdditionalComмent = "Основно семейство",
                TypeOfBroodBox = "Многокорпусен",
                SecondBroodBox = false,
                NumberOfAdditionalBoxes = 0,
                Super = true,
                NumberOfSupers = 1,
                MatedBeeQueen = true,
                OwnerOfTheApiary = "44C36B39-AD0A-4260-B448-45BB03158888",
                ApiaryId = 9150,
                BeeQueenId = 10002
            };

            beeColonies.Add(beeColony);

            beeColony = new BeeColony()
            {
                Id = 10003,
                PlateNumber = "100-4449",
                AdditionalComмent = "Отводка",
                TypeOfBroodBox = "Многокорпусен",
                SecondBroodBox = false,
                NumberOfAdditionalBoxes = 0,
                Super = false,
                NumberOfSupers = 0,
                MatedBeeQueen = true,
                OwnerOfTheApiary = "44C36B39-AD0A-4260-B448-45BB03158888",
                ApiaryId = 9150,
                BeeQueenId = 10003
            };

            beeColonies.Add(beeColony);

            beeColony = new BeeColony()
            {
                Id = 10004,
                PlateNumber = "100-4450",
                AdditionalComмent = "Основно семейство",
                TypeOfBroodBox = "Многокорпусен",
                SecondBroodBox = false,
                NumberOfAdditionalBoxes = 0,
                Super = true,
                NumberOfSupers = 1,
                MatedBeeQueen = true,
                OwnerOfTheApiary = "44C36B39-AD0A-4260-B448-45BB03158888",
                ApiaryId = 9150,
                BeeQueenId = 10004
            };

            beeColonies.Add(beeColony);

            beeColony = new BeeColony()
            {
                Id = 10005,
                PlateNumber = "100-4451",
                AdditionalComмent = "Основно семейство",
                TypeOfBroodBox = "Многокорпусен",
                SecondBroodBox = false,
                NumberOfAdditionalBoxes = 0,
                Super = true,
                NumberOfSupers = 1,
                MatedBeeQueen = true,
                OwnerOfTheApiary = "44C36B39-AD0A-4260-B448-45BB03158888",
                ApiaryId = 9150,
                BeeQueenId = 10005
            };

            beeColonies.Add(beeColony);

            beeColony = new BeeColony()
            {
                Id = 10006,
                PlateNumber = "100-4452",
                AdditionalComмent = "Отводка",
                TypeOfBroodBox = "Многокорпусен",
                SecondBroodBox = false,
                NumberOfAdditionalBoxes = 0,
                Super = true,
                NumberOfSupers = 1,
                MatedBeeQueen = true,
                OwnerOfTheApiary = "44C36B39-AD0A-4260-B448-45BB03158888",
                ApiaryId = 9150,
                BeeQueenId = 10006
            };

            beeColonies.Add(beeColony);


            beeColony = new BeeColony()
            {
                Id = 10007,
                PlateNumber = "100-4453",
                AdditionalComмent = "Отводка",
                TypeOfBroodBox = "Многокорпусен",
                SecondBroodBox = false,
                NumberOfAdditionalBoxes = 0,
                Super = true,
                NumberOfSupers = 1,
                MatedBeeQueen = true,
                OwnerOfTheApiary = "44C36B39-AD0A-4260-B448-45BB03158888",
                ApiaryId = 9156,
                BeeQueenId = 10007
            };

            beeColonies.Add(beeColony);


            beeColony = new BeeColony()
            {
                Id = 10008,
                PlateNumber = "100-4454",
                AdditionalComмent = "Отводка",
                TypeOfBroodBox = "Многокорпусен",
                SecondBroodBox = false,
                NumberOfAdditionalBoxes = 0,
                Super = true,
                NumberOfSupers = 1,
                MatedBeeQueen = true,
                OwnerOfTheApiary = "44C36B39-AD0A-4260-B448-45BB03158888",
                ApiaryId = 9156,
                BeeQueenId = 10008
            };

            beeColonies.Add(beeColony);


            beeColony = new BeeColony()
            {
                Id = 10009,
                PlateNumber = "100-4455",
                AdditionalComмent = "Отводка",
                TypeOfBroodBox = "Многокорпусен",
                SecondBroodBox = false,
                NumberOfAdditionalBoxes = 0,
                Super = true,
                NumberOfSupers = 1,
                MatedBeeQueen = true,
                OwnerOfTheApiary = "44C36B39-AD0A-4260-B448-45BB03158888",
                ApiaryId = 9156,
                BeeQueenId = 10009
            };

            beeColonies.Add(beeColony);

            return beeColonies.ToArray();
        }
    }
}