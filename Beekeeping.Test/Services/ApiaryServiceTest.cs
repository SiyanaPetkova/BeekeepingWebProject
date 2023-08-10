namespace Beekeeping.Test.Services
{
    using Microsoft.CodeAnalysis;
    using Microsoft.EntityFrameworkCore;

    using Models.Apiary;

    [TestFixture]
    internal class ApiaryServiceTest
    {
        private BeekeepingDbContext context;
        private IApiaryService apiaryService;

        private int apiaryIdForTests;

        [SetUp]
        public async Task SetUp()
        {
            apiaryIdForTests = 9150;

            var apiaries = GenerateApiariesData();

            context = new BeekeepingDbContext(GetContextOptions());

            await context.Apiaries.AddRangeAsync(apiaries);

            await context.SaveChangesAsync();

            apiaryService = new ApiaryService(context);
        }


        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }

        [Test]
        public async Task AddNewApiaryAsyncShouldAddNewApiary()
        {
            var expectedApiary = new ApiaryFormModel
            {
                Name = "Изворско",
                Location = "Село Изворско, Варна",
                RegistrationNumber = "9156-0057",
                Latitude = 43.295834,
                Longitude = 27.764714
            };

            await apiaryService.AddNewApiaryAsync(expectedApiary, UserdId);

            var actualApiary = await context.Apiaries.FirstOrDefaultAsync(a => a.OwnerId == UserdId && a.Latitude == expectedApiary.Latitude && a.Longitude == expectedApiary.Longitude);

            Assert.Multiple(() =>
            {
                Assert.NotNull(actualApiary);
                Assert.That(actualApiary!.Name, Is.EqualTo(expectedApiary.Name));
                Assert.That(actualApiary!.Location, Is.EqualTo(expectedApiary.Location));
                Assert.That(actualApiary!.RegistrationNumber, Is.EqualTo(expectedApiary.RegistrationNumber));
                Assert.That(actualApiary!.Latitude, Is.EqualTo(expectedApiary.Latitude));
                Assert.That(actualApiary!.Longitude, Is.EqualTo(expectedApiary.Longitude));
            });
        }

        [Test]
        public async Task AllApiaryAsyncByGivenUserShouldReturnAllAppiaries()
        {
            var expected = await context.Apiaries
                          .Where(a => a.OwnerId == UserdId)
                          .Select(a => new ApiaryViewModel
                          {
                              Id = a.Id,
                              Name = a.Name,
                              Location = a.Location,
                              RegistrationNumber = a.RegistrationNumber,
                              NumberOfHives = a.BeeHives.Count(),
                              OwnerId = a.OwnerId,
                              Latitude = a.Latitude,
                              Longitude = a.Longitude
                          })
                          .ToArrayAsync();

            var actual = await apiaryService.AllApiaryAsync(UserdId);

            Assert.Multiple(() =>
            {
                Assert.That(actual!.Count(), Is.EqualTo(expected.Length));
                Assert.That(actual!.First().Id, Is.EqualTo(expected.First().Id));
                Assert.That(actual!.First().Name, Is.EqualTo(expected.First().Name));
                Assert.That(actual!.First().RegistrationNumber, Is.EqualTo(expected.First().RegistrationNumber));
                Assert.That(actual!.First().NumberOfHives, Is.EqualTo(expected.First().NumberOfHives));
                Assert.That(actual!.First().OwnerId, Is.EqualTo(expected.First().OwnerId));
                Assert.That(actual!.First().Latitude, Is.EqualTo(expected.First().Latitude));
                Assert.That(actual!.First().Longitude, Is.EqualTo(expected.First().Longitude));
            });
        }

        [Test]
        public async Task AllApiaryAsyncShouldReturnNullIfUserHasNoAppiaries()
        {
            var actual = await apiaryService.AllApiaryAsync(NotExistingUserdId);

            Assert.That(actual, Is.Null);
        }

        [Test]
        public async Task DeleteApiaryAsyncShouldDeleteApiary()
        {
            await apiaryService.DeleteApiaryAsync(UserdId, apiaryIdForTests);

            var expected = await context.Apiaries.FirstOrDefaultAsync(a => a.Id == apiaryIdForTests && a.OwnerId == UserdId);

            Assert.That(expected, Is.Null);
        }

        [Test]
        public void DeleteApiaryAsyncShouldThrowIfOwnerDoesNotExist()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await apiaryService.DeleteApiaryAsync(NotExistingUserdId, apiaryIdForTests));
        }

        [Test]
        public void DeleteApiaryAsyncShouldThrowIfApiaryDoesNotExist()
        {
            int apiaryIdToBeDeleted = 9999;

            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await apiaryService.DeleteApiaryAsync(UserdId, apiaryIdToBeDeleted));
        }

        [Test]
        public async Task GetApiaryForEditAsyncShouldReturnCorrectApiaty()
        {
            var apiary = await context.Apiaries
                                .FirstOrDefaultAsync(a => a.Id == apiaryIdForTests && a.OwnerId == UserdId);

            var expectedApiary = new ApiaryEditFormModel
            {
                Id = apiary!.Id,
                Name = apiary.Name,
                Location = apiary.Location,
                RegistrationNumber = apiary.RegistrationNumber,
                Latitude = apiary.Latitude,
                Longitude = apiary.Longitude
            };

            var actualApiary = await apiaryService.GetApiaryForEditAsync(UserdId, apiaryIdForTests);

            Assert.Multiple(() =>
            {
                Assert.NotNull(actualApiary);
                Assert.That(actualApiary!.Name, Is.EqualTo(expectedApiary.Name));
                Assert.That(actualApiary!.Location, Is.EqualTo(expectedApiary.Location));
                Assert.That(actualApiary!.RegistrationNumber, Is.EqualTo(expectedApiary.RegistrationNumber));
                Assert.That(actualApiary!.Latitude, Is.EqualTo(expectedApiary.Latitude));
                Assert.That(actualApiary!.Longitude, Is.EqualTo(expectedApiary.Longitude));
            });
        }
        [Test]
        public void GetApiaryForEditAsyncShouldThrowIfOwnerDoesNotExist()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await apiaryService.GetApiaryForEditAsync(NotExistingUserdId, apiaryIdForTests));
        }

        [Test]
        public void GetApiaryForEditAsyncShouldThrowIfApiaryDoesNotExist()
        {
            int apiaryIdToBeDeleted = 9999;

            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await apiaryService.GetApiaryForEditAsync(UserdId, apiaryIdToBeDeleted));
        }

        [Test]
        public async Task EditApiaryAsyncShouldEditApiaryCorrectly()
        {
            var apiaryForEdit = await context.Apiaries.FirstOrDefaultAsync(a => a.Id == apiaryIdForTests);

            var actualApiary = new ApiaryEditFormModel()
            {
                Id = apiaryForEdit.Id,
                Name = apiaryForEdit!.Name,
                Location = "Село Климентово, община Аксаково, област Варна",
                RegistrationNumber = "9150-0025",
                Latitude = apiaryForEdit.Latitude,
                Longitude = apiaryForEdit.Longitude
            };

            await apiaryService.EditApiaryAsync(actualApiary, apiaryForEdit.Id, UserdId);

            var expectedApiary = await context.Apiaries.FirstOrDefaultAsync(a => a.Id == apiaryForEdit.Id);

            Assert.Multiple(() =>
            {
                Assert.NotNull(actualApiary);
                Assert.That(actualApiary!.Name, Is.EqualTo(expectedApiary!.Name));
                Assert.That(actualApiary!.Location, Is.EqualTo(expectedApiary.Location));
                Assert.That(actualApiary!.RegistrationNumber, Is.EqualTo(expectedApiary.RegistrationNumber));
                Assert.That(actualApiary!.Latitude, Is.EqualTo(expectedApiary.Latitude));
                Assert.That(actualApiary!.Longitude, Is.EqualTo(expectedApiary.Longitude));
            });
        }

        [Test]
        public void EditApiaryAsyncShouldThrowIfOwnerDoesNotExist()
        {
            var apiaryModel = new ApiaryEditFormModel()
            {
                Id = apiaryIdForTests,
                Name = "Климентово",
                Location = "Село Климентово, Варна",
                RegistrationNumber = "9150-0015",
                Latitude = 43.346222,
                Longitude = 27.946315
            };

            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await apiaryService.EditApiaryAsync(apiaryModel, apiaryIdForTests, NotExistingUserdId));
        }

        [Test]
        public void EditApiaryAsyncShouldThrowIfApiaryDoesNotExist()
        {
            var apiaryModel = new ApiaryEditFormModel()
            {
                Id = 9999,
                Name = "Климентово",
                Location = "Село Климентово, Варна",
                RegistrationNumber = "9150-0015",
                Latitude = 43.346222,
                Longitude = 27.946315
            };

            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await apiaryService.EditApiaryAsync(apiaryModel, apiaryModel.Id, UserdId));
        }

        [Test]
        public async Task DoesApiaryExistsShouldReturnTrue()
        {
            var result = await apiaryService.DoesApiaryExists(UserdId, apiaryIdForTests);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task DoesApiaryExistsShouldReturnFalseIfUserDoesNotExist()
        {
            var result = await apiaryService.DoesApiaryExists(NotExistingUserdId, apiaryIdForTests);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task DoesApiaryExistsShouldReturnFalseIfApiaryDoesNotExist()
        {
            var result = await apiaryService.DoesApiaryExists(UserdId, 9999);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task IsTheUserOwnerShouldReturnTrue()
        {
            var result = await apiaryService.IsTheUserOwner(UserdId);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task IsTheUserOwnerShouldReturnFalseIfUserDoesNotExist()
        {
            var result = await apiaryService.IsTheUserOwner(NotExistingUserdId);

            Assert.That(result, Is.False);
        }
    }

}

