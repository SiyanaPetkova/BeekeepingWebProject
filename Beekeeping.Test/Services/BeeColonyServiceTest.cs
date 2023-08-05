namespace Beekeeping.Test.Services
{
    using Beekeeping.Data;
    using Beekeeping.Data.Models;
    using Beekeeping.Models.Apiary;
    using Beekeeping.Models.BeeColony;
    using Beekeeping.Models.BeeQueen;
    using Beekeeping.Services.Interfaces;
    using Beekeeping.Services.Services;
    using Microsoft.EntityFrameworkCore;

    [TestFixture]
    internal class BeeColonyServiceTest
    {
        private BeekeepingDbContext context;
        private IBeeColonyService beeColonyService;
        private IApiaryService apiaryService;

        private int beeColonyIdForTests;
        private int apiaryIdForTests;

        [SetUp]
        public async Task SetUp()
        {
            beeColonyIdForTests = 10001;
            apiaryIdForTests = 9150;

            List<Apiary> apiaries = new()
            {
                 new Apiary()
                 {
                    Id = apiaryIdForTests,
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

            List<BeeQueen> beeQueens = new()
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

            List<BeeColony> beeColonies = new()
            {
                     new BeeColony()
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
                     OwnerOfTheApiary = UserdId,
                     ApiaryId = apiaryIdForTests,
                     BeeQueenId = 10001
                 },
                     new BeeColony()
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
                     OwnerOfTheApiary = UserdId,
                     ApiaryId = apiaryIdForTests,
                     BeeQueenId = 10002
                 },
                     new BeeColony()
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
                     OwnerOfTheApiary = UserdId,
                     ApiaryId = 9160,
                     BeeQueenId = 10003
                 }
            };

            var options = new DbContextOptionsBuilder<BeekeepingDbContext>()
               .UseInMemoryDatabase(databaseName: "BeekeepingInMemory")
               .Options;
            context = new BeekeepingDbContext(options);

            await context.Apiaries.AddRangeAsync(apiaries);
            await context.BeeQueens.AddRangeAsync(beeQueens);
            await context.BeeColonies.AddRangeAsync(beeColonies);

            await context.SaveChangesAsync();

            beeColonyService = new BeeColonyService(context);
            apiaryService = new ApiaryService(context);
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }

        [Test]
        public async Task AllColoniesAsyncShoudReturnAllColoniesForApiary()
        {
            var expected = await context.BeeColonies
                          .Where(b => b.ApiaryId == apiaryIdForTests && b.OwnerOfTheApiary == UserdId)
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
                              BeeQueen = new BeeQueenSelectViewModel()
                              {
                                  BeeQueenYearOfBirth = b.BeeQueen.BeeQueenYearOfBirth,
                                  Breeder = b.BeeQueen.Breeder,
                                  BeeQueenType = b.BeeQueen.BeeQueenType
                              }
                          })
                          .ToArrayAsync();

            var actual = await beeColonyService.AllColoniesAsync(UserdId, apiaryIdForTests);

            Assert.Multiple(() =>
            {
                Assert.That(actual!.Count(), Is.EqualTo(expected.Length));
                Assert.That(actual!.First().Id, Is.EqualTo(expected.First().Id));
                Assert.That(actual!.First().PlateNumber, Is.EqualTo(expected.First().PlateNumber));
                Assert.That(actual!.First().AdditionalComмent, Is.EqualTo(expected.First().AdditionalComмent));
                Assert.That(actual!.First().TypeOfBroodBox, Is.EqualTo(expected.First().TypeOfBroodBox));
                Assert.That(actual!.First().Super, Is.EqualTo(expected.First().Super));
                Assert.That(actual!.First().NumberOfSupers, Is.EqualTo(expected.First().NumberOfSupers));
                Assert.That(actual!.First().SecondBroodBox, Is.EqualTo(expected.First().SecondBroodBox));
                Assert.That(actual!.First().NumberOfAdditionalBoxes, Is.EqualTo(expected.First().NumberOfAdditionalBoxes));
                Assert.That(actual!.First().MatedBeeQueen, Is.EqualTo(expected.First().MatedBeeQueen));
                Assert.That(actual!.First().BeeQueen.BeeQueenYearOfBirth, Is.EqualTo(expected.First().BeeQueen.BeeQueenYearOfBirth));
                Assert.That(actual!.First().BeeQueen.Breeder, Is.EqualTo(expected.First().BeeQueen.Breeder));
                Assert.That(actual!.First().BeeQueen.BeeQueenType, Is.EqualTo(expected.First().BeeQueen.BeeQueenType));
            });
        }

        [Test]
        public async Task AllColoniesAsyncShouldReturnNull()
        {
            var actual = await beeColonyService.AllColoniesAsync(NotExistingUserdId, apiaryIdForTests);

            Assert.That(actual, Is.Null);
        }

        [Test]
        public async Task AddNewBeeColonyAsyncShouldAddNewBeeColony()
        {
            var apiaries = await context.Apiaries
                                         .Where(a => a.OwnerId == UserdId)
                                         .Select(a => new AllApiariesForSelectModel()
                                         {
                                             Id = a.Id,
                                             Name = a.Name
                                         })
                                         .ToArrayAsync();

            var beeQueen = new BeeQueen()
            {
                Breeder = "Роева",
                BeeQueenYearOfBirth = 2023,
                BeeQueenType = "Неизвестна"
            };

            var expected = new BeeColonyFormModel()
            {
                PlateNumber = "0000-234",
                AdditionalComment = "Спокойно семейство",
                TypeOfBroodBox = "Дадан блат",
                Super = false,
                NumberOfSupers = 0,
                SecondBroodBox = false,
                NumberOfAdditionalBoxes = 0,
                MatedBeeQueen = true,
                OwnerOfTheApiary = UserdId,
                ApiaryId = apiaryIdForTests,
                Apiaries = apiaries,
                BeeQueenId = beeQueen.Id,
                BeeQueen = new BeeQueenFormModel()
                {
                    Breeder = beeQueen.Breeder,
                    BeeQueenType = beeQueen.BeeQueenType,
                    BeeQueenYearOfBirth = beeQueen.BeeQueenYearOfBirth
                }
            };

            await beeColonyService.AddNewBeeColonyAsync(expected, UserdId);

            var colonies = await context.BeeColonies.Select(b => b.Id).ToListAsync();

            var actual = await context.BeeColonies.FirstOrDefaultAsync(b => b.OwnerOfTheApiary == UserdId && b.Id == 10004);

            Assert.Multiple(() =>
            {
                Assert.That(actual!.PlateNumber, Is.EqualTo(expected.PlateNumber));
                Assert.That(actual!.AdditionalComмent, Is.EqualTo(expected.AdditionalComment));
                Assert.That(actual!.TypeOfBroodBox, Is.EqualTo(expected.TypeOfBroodBox));
                Assert.That(actual!.Super, Is.EqualTo(expected.Super));
                Assert.That(actual!.NumberOfSupers, Is.EqualTo(expected.NumberOfSupers));
                Assert.That(actual!.SecondBroodBox, Is.EqualTo(expected.SecondBroodBox));
                Assert.That(actual!.NumberOfAdditionalBoxes, Is.EqualTo(expected.NumberOfAdditionalBoxes));
                Assert.That(actual!.MatedBeeQueen, Is.EqualTo(expected.MatedBeeQueen));
                Assert.That(actual.BeeQueen!.BeeQueenYearOfBirth, Is.EqualTo(expected.BeeQueen.BeeQueenYearOfBirth));
                Assert.That(actual!.BeeQueen.Breeder, Is.EqualTo(expected.BeeQueen.Breeder));
                Assert.That(actual!.BeeQueen.BeeQueenType, Is.EqualTo(expected.BeeQueen.BeeQueenType));
            });
        }

        [Test]
        public async Task DeleteBeeColonyAsyncShoudDeleteColony()
        {
            await beeColonyService.DeleteBeeColonyAsync(UserdId, beeColonyIdForTests);

            var expected = await context.BeeColonies.FirstOrDefaultAsync(b => b.Id == beeColonyIdForTests && b.OwnerOfTheApiary == UserdId);

            Assert.That(expected, Is.Null);
        }


        [Test]
        public void DeleteBeeColonyAsyncShouldThrowIfOwnerDoesNotExist()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await apiaryService.DeleteApiaryAsync(NotExistingUserdId, beeColonyIdForTests));
        }

        [Test]
        public void DeleteBeeColonyAsyncShouldThrowIfApiaryDoesNotExist()
        {
            int beeColonyIdToBeDeleted = 9999;

            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await apiaryService.DeleteApiaryAsync(UserdId, beeColonyIdToBeDeleted));
        }


    }
}
