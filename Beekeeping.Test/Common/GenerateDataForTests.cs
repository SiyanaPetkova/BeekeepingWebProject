namespace Beekeeping.Test.Common
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using Data.Models;

    public class GenerateDataForTests
    {
        public static DbContextOptions<BeekeepingDbContext> GetContextOptions()
        {
            return new DbContextOptionsBuilder<BeekeepingDbContext>()
               .UseInMemoryDatabase(databaseName: "BeekeepingInMemory")
               .Options;
        }

        public static List<Apiary> GenerateApiariesData()
        {
            return new()
            {
                 new Apiary()
                 {
                    Id = 9150,
                    Name = "Климентово",
                    Location = "Село Климентово, Варна",
                    OwnerId = UserdId,
                    RegistrationNumber = "9150-0015",
                    Latitude = 43.346222,
                    Longitude = 27.946315
                  },

             new Apiary()
                {
                    Id = 9156,
                    Name = "Зорница",
                    Location = "Село Зорница, Варна",
                    OwnerId = UserdId,
                    RegistrationNumber = "9156-0017",
                    Latitude = 43.330429,
                    Longitude = 27.734944
                  }
             };
        }

        public static List<BeeQueen> GenerateBeeQueenData()
        {
            return new()
            {
                    new BeeQueen
                 {
                     Id = 10001,
                     Breeder = "Собствено производство",
                     BeeQueenYearOfBirth = 2023,
                     BeeQueenType = "Карника"
                 },
                     new BeeQueen()
                 {
                     Id = 10002,
                     Breeder = "Собствено производство",
                     BeeQueenYearOfBirth = 2023,
                     BeeQueenType = "Карника"
                 },
                     new BeeQueen()
                 {
                     Id = 10003,
                     Breeder = "Роева",
                     BeeQueenYearOfBirth = 2023,
                     BeeQueenType = "Неизвестна"
                 }
            };
        }

        public static List<BeeColony> GenerateBeeColonyData()
        {
            return new()
            {
                     new BeeColony()
                  {
                     Id = 10001,
                     PlateNumber = "100-4447",
                     AdditionalComment = "Основно семейство",
                     TypeOfBroodBox = "Многокорпусен",
                     SecondBroodBox = true,
                     NumberOfAdditionalBoxes = 1,
                     Super = true,
                     NumberOfSupers = 1,
                     MatedBeeQueen = true,
                     OwnerOfTheApiary = UserdId,
                     ApiaryId = 9150,
                     BeeQueenId = 10001
                 },
                     new BeeColony()
            {
            Id = 10002,
                     PlateNumber = "100-4448",
                     AdditionalComment = "Основно семейство",
                     TypeOfBroodBox = "Многокорпусен",
                     SecondBroodBox = false,
                     NumberOfAdditionalBoxes = 0,
                     Super = true,
                     NumberOfSupers = 1,
                     MatedBeeQueen = true,
                     OwnerOfTheApiary = UserdId,
                     ApiaryId = 9150,
                     BeeQueenId = 10002
                 },
                     new BeeColony()
            {
            Id = 10003,
                     PlateNumber = "100-4449",
                     AdditionalComment = "Отводка",
                     TypeOfBroodBox = "Многокорпусен",
                     SecondBroodBox = false,
                     NumberOfAdditionalBoxes = 0,
                     Super = false,
                     NumberOfSupers = 0,
                     MatedBeeQueen = true,
                     OwnerOfTheApiary = UserdId,
                     ApiaryId = 9160,
                     BeeQueenId = 10003
            }
        };
        }

        public static List<Cost> GenerateCostData()
        {
            return new()
            {
                new Cost()
            {
                Id = 50001,
                DayOfTheCost = DateTime.Parse("01.01.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                TypeOfCost = "Третиране",
                CostValue = 100,
                CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888"
            },
                new Cost()
            {
                Id = 50002,
                DayOfTheCost = DateTime.Parse("01.01.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                TypeOfCost = "Хранене",
                CostValue = 120,
                CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888"
            }
            };
        }

        public static List<HiveFeeding> GenerateFeedingData()
        {
            return new()
            {
             new HiveFeeding()
            {
                Id = 30001,
                DayOfFeeding = DateTime.Parse("01.01.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                FeedingType = "Питка",
                PriceOfFeeding =  120,
                NumberOfBeeHives = 10,
                CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888"
            },
                 new HiveFeeding()
            {
                Id = 30002,
                DayOfFeeding = DateTime.Parse("02.01.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                FeedingType =  "Сироп",
                PriceOfFeeding = 80,
                NumberOfBeeHives = 10,
                CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888"
            }
        };
        }

        public static List<Income> GenerateIncomeData()
        {
            return new()
            {
                 new Income()
                {
                    Id = 60001,
                    IncomeValue = 950,
                    TypeOfIncome = "Продаден прашец",
                    DayOfTheIncome = DateTime.Parse("04.20.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                    CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888"
                },
                 new Income()
                {
                    Id = 60002,
                    IncomeValue = 120,
                    TypeOfIncome = "Продаден мед",
                    DayOfTheIncome = DateTime.Parse("05.10.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                    CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888"
                 }
            };
        }

        public static List<Inspection> GenerateInspectionsData()
        {
            return new()
            {
                new Inspection()
                    {
                        Id = 100000,
                        DayOfInspection = DateTime.Parse("01.01.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                        Description = "Общ преглед",
                        NumberOfFrames = 5,
                        NumberOfBroodFrames = 1,
                        Strenght = 4,
                        Temperament = 8,
                        BeeColonyId = 10001
                    },
                 new Inspection()
                    {
                        Id = 100001,
                        DayOfInspection = DateTime.Parse("01.02.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                        Description = "Общ преглед",
                        NumberOfFrames = 6,
                        NumberOfBroodFrames = 2,
                        Strenght = 5,
                        Temperament = 8,
                        BeeColonyId = 10001
                    }
            };
        }

        public static List<NoteToDo> GenerateNoteToDoData()
        {
            return new()
            {
            new NoteToDo()
            {
                Id = 20001,
                DateToBeDone = DateTime.Parse("07.22.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                Description = "Третиране против акар",
                CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888",
                Finished = false
            },
                new NoteToDo()
            {
                Id = 20002,
                DateToBeDone = DateTime.Parse("03.15.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                Description = "Пролетно подхранване",
                CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888",
                Finished = true
            }
        };

        }

        public static List<HiveTreatment> GeneratetreatmentData()
        {
            return new()
            {
           new HiveTreatment()
                {
                    Id = 40001,
                    TreatmentDate = DateTime.Parse("01.01.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                    ResultAndCommentAboutTheTreatment = $"Опаразитеност около 1%",
                    MedicationName = "Оксалова киселина",
                    ActiveIngredient = "Оксалова киселина",
                    PriceOfTheTreatment = 40,
                    NumberOfTreatedColonies = 10,
                    CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888"
                },
           new HiveTreatment()
                {
                    Id = 40002,
                    TreatmentDate = DateTime.Parse("02.01.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                    ResultAndCommentAboutTheTreatment = $"Опаразитеност около 2%",
                    MedicationName =  "Апивар",
                    ActiveIngredient = "Амитраз",
                    PriceOfTheTreatment = 100,
                    NumberOfTreatedColonies = 10,
                    CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888"
                }
            };
        }
    }
}

