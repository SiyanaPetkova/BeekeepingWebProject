namespace Beekeeping.Test.Services
{
    using Microsoft.CodeAnalysis;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;

    using Data;
    using Models.Inspection;
    using Beekeeping.Models.BeeColony;
    using Beekeeping.Models.BeeQueen;
    using Beekeeping.Services.Services;

    [TestFixture]
    internal class InspectionServiseTest
    {
        private BeekeepingDbContext context;
        private IInspectionService inspectionService;

        private int inspectionIdForTests;
        private int beeColonyIdForTests;

        [SetUp]
        public async Task SetUp()
        {
            inspectionIdForTests = 100000;
            beeColonyIdForTests = 10001;

            var inspections = GenerateInspectionsData();

            var beeColonies = GenerateBeeColonyData();

            context = new BeekeepingDbContext(GetContextOptions());

            await context.Inspections.AddRangeAsync(inspections);
            await context.BeeColonies.AddRangeAsync(beeColonies);

            await context.SaveChangesAsync();

            inspectionService = new InspectionService(context);
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }

        [Test]
        public async Task AddNewInspectionAsyncShouldAddNewInspection()
        {
            var expected = new InspectionFormModel
            {
                Id = 100002,
                DayOfInspection = DateTime.Parse("01.03.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                Description = "Пролетен преглед",
                NumberOfFrames = 8,
                NumberOfBroodFrames = 6,
                Strenght = 9,
                Temperament = 8,
                BeeColonyId = beeColonyIdForTests
            };

            await inspectionService.AddNewInspectionAsync(expected, UserId);

            var actual = await context.Inspections.FirstOrDefaultAsync(i => i.Id == expected.Id);

            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual!.DayOfInspection, Is.EqualTo(expected.DayOfInspection));
                Assert.That(actual!.Description, Is.EqualTo(expected.Description));
                Assert.That(actual!.NumberOfBroodFrames, Is.EqualTo(expected.NumberOfBroodFrames));
                Assert.That(actual!.NumberOfFrames, Is.EqualTo(expected.NumberOfFrames));
                Assert.That(actual!.Strenght, Is.EqualTo(expected.Strenght));
                Assert.That(actual!.Temperament, Is.EqualTo(expected.Temperament));
                Assert.That(actual!.BeeColonyId, Is.EqualTo(expected.BeeColonyId));
            });
        }

        [Test]
        public async Task AllInspectionsAsyncPerColonyShouldReturnAllAppiaries()
        {
            var expected = await context.Inspections
                          .Where(i => i.BeeColonyId == beeColonyIdForTests)
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

            var actual = await inspectionService.AllInspectionsPerColonyAsync(UserId, beeColonyIdForTests);

            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual!.First().DayOfInspection, Is.EqualTo(expected.First().DayOfInspection));
                Assert.That(actual!.First().Description, Is.EqualTo(expected.First().Description));
                Assert.That(actual!.First().NumberOfBroodFrames, Is.EqualTo(expected.First().NumberOfBroodFrames));
                Assert.That(actual!.First().NumberOfFrames, Is.EqualTo(expected.First().NumberOfFrames));
                Assert.That(actual!.First().Strenght, Is.EqualTo(expected.First().Strenght));
                Assert.That(actual!.First().Temperament, Is.EqualTo(expected.First().Temperament));
                Assert.That(actual!.First().BeeColonyId, Is.EqualTo(expected.First().BeeColonyId));
            });
        }

        [Test]
        public async Task DeleteInspectionAsyncShouldDeleteInspection()
        {
            await inspectionService.DeleteInspectionAsync(UserId, inspectionIdForTests);

            var expected = await context.Inspections.FirstOrDefaultAsync(a => a.Id == inspectionIdForTests);

            Assert.That(expected, Is.Null);
        }

        [Test]
        public void DeleteInspectionAsyncShouldThrowIfOwnerDoesNotExist()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await inspectionService.DeleteInspectionAsync(NotExistingUserdId, inspectionIdForTests));
        }

        [Test]
        public void DeleteInspectionAsyncShouldThrowIfInspectionDoesNotExist()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await inspectionService.DeleteInspectionAsync(UserId, 9999));
        }

        [Test]
        public async Task GetInspectionForEditAsyncShouldReturnCorrectInspection()
        {
            var inspection = await context.Inspections.FirstOrDefaultAsync(a => a.Id == inspectionIdForTests);

            var expected = new InspectionFormModel
            {
                Id = inspectionIdForTests,
                DayOfInspection = inspection.DayOfInspection,
                NumberOfFrames = inspection.NumberOfFrames,
                NumberOfBroodFrames = inspection.NumberOfBroodFrames,
                Strenght = inspection.Strenght,
                Temperament = inspection.Temperament,
                Description = inspection.Description,
                BeeColonyId = inspection.BeeColonyId
            };

            var actual = await inspectionService.GetInspectionForEditAsync(UserId, inspectionIdForTests);

            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual!.DayOfInspection, Is.EqualTo(expected.DayOfInspection));
                Assert.That(actual!.Description, Is.EqualTo(expected.Description));
                Assert.That(actual!.NumberOfBroodFrames, Is.EqualTo(expected.NumberOfBroodFrames));
                Assert.That(actual!.NumberOfFrames, Is.EqualTo(expected.NumberOfFrames));
                Assert.That(actual!.Strenght, Is.EqualTo(expected.Strenght));
                Assert.That(actual!.Temperament, Is.EqualTo(expected.Temperament));
                Assert.That(actual!.BeeColonyId, Is.EqualTo(expected.BeeColonyId));
            });
        }
        [Test]
        public void GetInspectionForEditAsyncShouldThrowIfOwnerDoesNotExist()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await inspectionService.GetInspectionForEditAsync(NotExistingUserdId, inspectionIdForTests));
        }

        [Test]
        public void GetInspectionForEditAsyncShouldThrowIfInspectionDoesNotExist()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await inspectionService.GetInspectionForEditAsync(UserId, 9999));
        }

        [Test]
        public async Task EditInspectionAsyncShouldEditInspectionCorrectly()
        {
            var inspection = await context.Inspections.FirstOrDefaultAsync(a => a.Id == inspectionIdForTests);

            var expected = new InspectionFormModel()
            {
                Id = inspectionIdForTests,
                DayOfInspection = inspection!.DayOfInspection,
                NumberOfFrames = 10,
                NumberOfBroodFrames = 8,
                Strenght = 4,
                Temperament = 2,
                Description = inspection.Description,
                BeeColonyId = inspection.BeeColonyId
            };

            await inspectionService.EditInspectionAsync(expected, UserId, inspectionIdForTests);

            var actual = await context.Inspections.FirstOrDefaultAsync(a => a.Id == inspectionIdForTests);

            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual!.DayOfInspection, Is.EqualTo(expected.DayOfInspection));
                Assert.That(actual!.Description, Is.EqualTo(expected.Description));
                Assert.That(actual!.NumberOfBroodFrames, Is.EqualTo(expected.NumberOfBroodFrames));
                Assert.That(actual!.NumberOfFrames, Is.EqualTo(expected.NumberOfFrames));
                Assert.That(actual!.Strenght, Is.EqualTo(expected.Strenght));
                Assert.That(actual!.Temperament, Is.EqualTo(expected.Temperament));
                Assert.That(actual!.BeeColonyId, Is.EqualTo(expected.BeeColonyId));
            });
        }

        [Test]
        public void EditInspectionAsyncShouldThrowIfOwnerDoesNotExist()
        {
            var inspectionModel = new InspectionFormModel()
            {
                Id = inspectionIdForTests,
                DayOfInspection = DateTime.Parse("01.03.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                Description = "Пролетен преглед",
                NumberOfFrames = 10,
                NumberOfBroodFrames = 6,
                Strenght = 9,
                Temperament = 8,
                BeeColonyId = beeColonyIdForTests
            };

            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await inspectionService.EditInspectionAsync(inspectionModel, NotExistingUserdId, inspectionIdForTests));
        }

        [Test]
        public void EditInspectionAsyncShouldThrowIfInspectionDoesNotExist()
        {
            var inspectionModel = new InspectionFormModel()
            {
                Id = 10005,
                DayOfInspection = DateTime.Parse("01.03.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                Description = "Пролетен преглед",
                NumberOfFrames = 10,
                NumberOfBroodFrames = 6,
                Strenght = 9,
                Temperament = 8,
                BeeColonyId = beeColonyIdForTests
            };

            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await inspectionService.EditInspectionAsync(inspectionModel, UserId, 10005));
        }

        [Test]
        public async Task DoesInspectionExistsShouldReturnTrue()
        {
            var result = await inspectionService.DoesInspectionExist(UserId, inspectionIdForTests);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task DoesInspectionExistsShouldReturnFalseIfUserDoesNotExist()
        {
            var result = await inspectionService.DoesInspectionExist(NotExistingUserdId, inspectionIdForTests);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task DoesInspectionExistsShouldReturnFalseIfInspectionDoesNotExist()
        {
            var result = await inspectionService.DoesInspectionExist(UserId, 9999);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task GetCurrentInspectionBeeColonyIdShouldReturnCorrectId()
        {
            var expected = 10001;

            var actual = await inspectionService.GetCurrentInspectionBeeColonyId(UserId, inspectionIdForTests);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetCurrentInspectionBeeColonyIdIfUserDoesNotExist()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async ()
                    => await inspectionService.GetCurrentInspectionBeeColonyId(NotExistingUserdId, inspectionIdForTests));
        }

        [Test]
        public void GetCurrentInspectionBeeColonyIdIfInspectionDoesNotExist()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async ()
                    => await inspectionService.GetCurrentInspectionBeeColonyId(UserId, 10005));
        }
    }
}

