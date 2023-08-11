namespace Beekeeping.Test.Services
{
    #nullable disable

    using Microsoft.EntityFrameworkCore;

    using Data.Models;
    using Models.Apiary;
    using Models.BeeColony;
    using Models.BeeQueen;

    [TestFixture]
    internal class BeeColonyServiceTest
    {
        private BeekeepingDbContext context;
        private IBeeColonyService beeColonyService;

        private int beeColonyIdForTests;
        private int apiaryIdForTests;

        [SetUp]
        public async Task SetUp()
        {
            beeColonyIdForTests = 10001;
            apiaryIdForTests = 9150;

            var apiaries = GenerateApiariesData();

            var beeQueens = GenerateBeeQueenData();

            var beeColonies = GenerateBeeColonyData();

            context = new BeekeepingDbContext(GetContextOptions());

            await context.Apiaries.AddRangeAsync(apiaries);
            await context.BeeQueens.AddRangeAsync(beeQueens);
            await context.BeeColonies.AddRangeAsync(beeColonies);

            await context.SaveChangesAsync();

            beeColonyService = new BeeColonyService(context);
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
                          .Where(b => b.ApiaryId == apiaryIdForTests && b.OwnerOfTheApiary == UserId)
                          .Include(b => b.BeeQueen)
                          .Include(b => b.Apiary)
                          .Select(b => new BeeColonyViewModel
                          {
                              Id = b.Id,
                              PlateNumber = b.PlateNumber,
                              AdditionalComment = b.AdditionalComment,
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

            var actual = await beeColonyService.AllColoniesAsync(UserId, apiaryIdForTests);

            Assert.Multiple(() =>
            {
                Assert.That(actual!.Count(), Is.EqualTo(expected.Length));
                Assert.That(actual!.First().Id, Is.EqualTo(expected.First().Id));
                Assert.That(actual!.First().PlateNumber, Is.EqualTo(expected.First().PlateNumber));
                Assert.That(actual!.First().AdditionalComment, Is.EqualTo(expected.First().AdditionalComment));
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
                                         .Where(a => a.OwnerId == UserId)
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
                OwnerOfTheApiary = UserId,
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

            await beeColonyService.AddNewBeeColonyAsync(expected, UserId);

            var colonies = await context.BeeColonies.Select(b => b.Id).ToListAsync();

            var actual = await context.BeeColonies.FirstOrDefaultAsync(b => b.OwnerOfTheApiary == UserId && b.Id == 10004);

            Assert.Multiple(() =>
            {
                Assert.That(actual!.PlateNumber, Is.EqualTo(expected.PlateNumber));
                Assert.That(actual!.AdditionalComment, Is.EqualTo(expected.AdditionalComment));
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
            await beeColonyService.DeleteBeeColonyAsync(UserId, beeColonyIdForTests);

            var expected = await context.BeeColonies.FirstOrDefaultAsync(b => b.Id == beeColonyIdForTests && b.OwnerOfTheApiary == UserId);

            Assert.That(expected, Is.Null);
        }

        [Test]
        public void DeleteBeeColonyAsyncShouldThrowIfOwnerDoesNotExist()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await beeColonyService.DeleteBeeColonyAsync(NotExistingUserdId, beeColonyIdForTests));
        }

        [Test]
        public void DeleteBeeColonyAsyncShouldThrowIfApiaryDoesNotExist()
        {
            int beeColonyIdToBeDeleted = 9999;

            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await beeColonyService.DeleteBeeColonyAsync(UserId, beeColonyIdToBeDeleted));
        }

        [Test]
        public async Task GetBeeColonyForEditAsyncShoulReturnCorectBeeColony()
        {
            var beeColony = await context.BeeColonies.FirstOrDefaultAsync(b => b.Id == beeColonyIdForTests);

            var beeQueen = await context.BeeQueens
                               .Where(b => b.Id == beeColony.BeeQueenId)
                               .Select(b => new BeeQueenFormModel()
                               {
                                   Breeder = b.Breeder,
                                   BeeQueenType = b.BeeQueenType,
                                   BeeQueenYearOfBirth = b.BeeQueenYearOfBirth
                               })
                               .FirstOrDefaultAsync();

            var expected = new BeeColonyFormModel
            {
                Id = beeColony.Id,
                PlateNumber = beeColony.PlateNumber,
                AdditionalComment = beeColony.AdditionalComment,
                TypeOfBroodBox = beeColony.TypeOfBroodBox,
                Super = beeColony.Super,
                NumberOfSupers = beeColony.NumberOfSupers,
                SecondBroodBox = beeColony.SecondBroodBox,
                NumberOfAdditionalBoxes = beeColony.NumberOfAdditionalBoxes,
                MatedBeeQueen = beeColony.MatedBeeQueen,
                BeeQueenId = beeColony.BeeQueenId,
                BeeQueen = beeQueen
            };

            var actual = await beeColonyService.GetBeeColonyForEditAsync(UserId, beeColonyIdForTests);

            Assert.Multiple(() =>
            {
                Assert.That(actual!.PlateNumber, Is.EqualTo(expected.PlateNumber));
                Assert.That(actual!.AdditionalComment, Is.EqualTo(expected.AdditionalComment));
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
        public void GetBeeColonyForEditAsyncShouldThrowIfOwnerDoesNotExist()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await beeColonyService.GetBeeColonyForEditAsync(NotExistingUserdId, beeColonyIdForTests));
        }

        [Test]
        public void GetBeeColonyForEditAsyncShouldThrowIfApiaryDoesNotExist()
        {
            int beeColonyIdToBeDeleted = 9999;

            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await beeColonyService.GetBeeColonyForEditAsync(UserId, beeColonyIdToBeDeleted));
        }

        [Test]
        public async Task EditBeeColonyAsyncShoulReturnCorectBeeColony()
        {
            var beeColonyForEdit = await context.BeeColonies.FirstOrDefaultAsync(b => b.Id == beeColonyIdForTests);

            var beeQueen = await context.BeeQueens
                               .Where(b => b.Id == beeColonyForEdit.BeeQueenId)
                               .Select(b => new BeeQueenFormModel()
                               {
                                   Breeder = b.Breeder,
                                   BeeQueenType = b.BeeQueenType,
                                   BeeQueenYearOfBirth = b.BeeQueenYearOfBirth
                               })
                               .FirstOrDefaultAsync();

            var expected = new BeeColonyFormModel
            {
                Id = beeColonyForEdit.Id,
                PlateNumber = beeColonyForEdit.PlateNumber,
                AdditionalComment = "Много силно семейство",
                TypeOfBroodBox = "Лангстрот рут",
                Super = true,
                NumberOfSupers = 2,
                SecondBroodBox = true,
                NumberOfAdditionalBoxes = 2,
                MatedBeeQueen = beeColonyForEdit.MatedBeeQueen,
                BeeQueenId = beeColonyForEdit.BeeQueenId,
                BeeQueen = beeQueen
            };

            await beeColonyService.EditBeeColonyAsync(expected, UserId, beeColonyIdForTests);

            var actual = await context.BeeColonies.FirstOrDefaultAsync(b => b.Id == beeColonyIdForTests);

            Assert.Multiple(() =>
            {
                Assert.That(actual!.PlateNumber, Is.EqualTo(expected.PlateNumber));
                Assert.That(actual!.AdditionalComment, Is.EqualTo(expected.AdditionalComment));
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
        public async Task EditColonyAsyncShouldThrowIfOwnerDoesNotExist()
        {
            var beeColonyForEdit = await context.BeeColonies.FirstOrDefaultAsync(b => b.Id == beeColonyIdForTests);

            var beeQueen = await context.BeeQueens
                               .Where(b => b.Id == beeColonyForEdit.BeeQueenId)
                               .Select(b => new BeeQueenFormModel()
                               {
                                   Breeder = b.Breeder,
                                   BeeQueenType = b.BeeQueenType,
                                   BeeQueenYearOfBirth = b.BeeQueenYearOfBirth
                               })
                               .FirstOrDefaultAsync();

            var beeColonyModel = new BeeColonyFormModel
            {
                Id = beeColonyForEdit.Id,
                PlateNumber = beeColonyForEdit.PlateNumber,
                AdditionalComment = "Много силно семейство",
                TypeOfBroodBox = "Лангстрот рут",
                Super = true,
                NumberOfSupers = 2,
                SecondBroodBox = true,
                NumberOfAdditionalBoxes = 2,
                MatedBeeQueen = beeColonyForEdit.MatedBeeQueen,
                BeeQueenId = beeColonyForEdit.BeeQueenId,
                BeeQueen = beeQueen
            };

            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await beeColonyService.EditBeeColonyAsync(beeColonyModel, NotExistingUserdId, beeColonyIdForTests));
        }

        [Test]
        public async Task GetDetailsForTheBeeColonyAsyncShouldReturnCorectInformation()
        {
            var beeColony = await context.BeeColonies.FirstOrDefaultAsync(b => b.OwnerOfTheApiary == UserId && b.Id == beeColonyIdForTests);

            var expected = new BeeColonyViewModel
            {

                Id = beeColony.Id,
                PlateNumber = beeColony.PlateNumber,
                AdditionalComment = beeColony.AdditionalComment,
                TypeOfBroodBox = beeColony.TypeOfBroodBox,
                Super = beeColony.Super == true ? "Има" : "Няма",
                NumberOfSupers = beeColony.NumberOfSupers,
                SecondBroodBox = beeColony.SecondBroodBox == true ? "Има" : "Няма",
                NumberOfAdditionalBoxes = beeColony.NumberOfAdditionalBoxes,
                MatedBeeQueen = beeColony.MatedBeeQueen == true ? "Има" : "Няма",
                Apiary = beeColony.Apiary.Name,
                BeeQueen = new BeeQueenSelectViewModel()
                {
                    BeeQueenYearOfBirth = beeColony.BeeQueen.BeeQueenYearOfBirth,
                    Breeder = beeColony.BeeQueen.Breeder,
                    BeeQueenType = beeColony.BeeQueen.BeeQueenType
                }
            };

            var actual = await beeColonyService.GetDetailsForTheBeeColonyAsync(UserId, beeColonyIdForTests);

            Assert.Multiple(() =>
            {
                Assert.That(actual!.PlateNumber, Is.EqualTo(expected.PlateNumber));
                Assert.That(actual!.AdditionalComment, Is.EqualTo(expected.AdditionalComment));
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
        public void GetDetailsForTheBeeColonyAsyncShouldThrowIfOwnerDoesNotExist()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await beeColonyService.GetDetailsForTheBeeColonyAsync(NotExistingUserdId, beeColonyIdForTests));
        }

        [Test]
        public void GetDetailsForTheBeeColonyAsyncShouldThrowIfBeeColonyDoesNotExist()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await beeColonyService.GetDetailsForTheBeeColonyAsync(UserId, 1111));
        }

        [Test]
        public async Task IsTheUserOwnerShoulReturnTrueIfUserIsCorrect()
        {
            var result = await beeColonyService.IsTheUserOwner(UserId);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task IsTheUserOwnerShoulReturnFalseIfUserDoesNotExist()
        {
            var result = await beeColonyService.IsTheUserOwner(NotExistingUserdId);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task DoesBeeColonyExistShoulReturnTrueIfColonyExist()
        {
            var result = await beeColonyService.DoesBeeColonyExist(UserId, beeColonyIdForTests);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task DoesBeeColonyExistShoulReturnFalseIfColonyDoesNotExist()
        {
            var result = await beeColonyService.DoesBeeColonyExist(UserId, 1111);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task DoesBeeColonyExistShoulReturnFalseIfUserDoesNotExist()
        {
            var result = await beeColonyService.DoesBeeColonyExist(NotExistingUserdId, beeColonyIdForTests);

            Assert.That(result, Is.False);
        }
    }
}
