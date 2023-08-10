namespace Beekeeping.Test.Services
{
    using Microsoft.EntityFrameworkCore;
    using System;  
    using System.Globalization;
    using System.Threading.Tasks;

     using Models.HiveTreatment;  

    internal class TreatmentServiceTest
    {
        private BeekeepingDbContext context;
        private ITreatmentService treatmentService;

        private int treatmentIdForTests;

        [SetUp]
        public async Task SetUp()
        {
            treatmentIdForTests = 40001;

            var treatments = GeneratetreatmentData();
                      
            context = new BeekeepingDbContext(GetContextOptions());

            await context.HiveTreatments.AddRangeAsync(treatments);

            await context.SaveChangesAsync();

            treatmentService = new TreatmentService(context);
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }

        [Test]
        public async Task AddTreatmentAsyncShouldAddNewCost()
        {
            var expected = new HiveTreatmentFormModel()
            {
                Id = 40003,
                TreatmentDate = DateTime.Parse("04.01.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                ResultAndCommentAboutTheTreatment = "Опаразитеност около 2%",
                MedicationName = "Апивар",
                ActiveIngredient = "Амитраз",
                PriceOfTheTreatment = 200,
                NumberOfTreatedColonies = 10
            };

            await treatmentService.AddTreatmentAsync(expected, UserdId);

            var actual = await context.HiveTreatments.FirstOrDefaultAsync(c => c.Id == expected.Id);

            Assert.Multiple(() =>
            {
                Assert.That(actual!.Id, Is.EqualTo(expected.Id));
                Assert.That(actual.TreatmentDate, Is.EqualTo(expected.TreatmentDate));
                Assert.That(actual.MedicationName, Is.EqualTo(expected.MedicationName));
                Assert.That(actual.ActiveIngredient, Is.EqualTo(expected.ActiveIngredient));
                Assert.That(actual.PriceOfTheTreatment, Is.EqualTo(expected.PriceOfTheTreatment));
                Assert.That(actual.ResultAndCommentAboutTheTreatment, Is.EqualTo(expected.ResultAndCommentAboutTheTreatment));
            });
        }

        [Test]
        public async Task AllTreatmentsAsyncShouldReturnCorectInformation()
        {
            var expected = await context.HiveTreatments
                .Where(t => t.CreatorId == UserdId)
                .OrderByDescending(t => t.TreatmentDate)
                .Select(t => new HiveTreatmentViewModel()
                {
                    Id = t.Id,
                    TreatmentDate = t.TreatmentDate.ToLongDateString(),
                    MedicationName = t.MedicationName,
                    ActiveIngredient = t.ActiveIngredient,
                    PriceOfTheTreatment = t.PriceOfTheTreatment,
                    ResultAndCommentAboutTheTreatment = t.ResultAndCommentAboutTheTreatment,
                    CreatorId = UserdId
                })
                .ToArrayAsync();

            var actual = await treatmentService.AllTreatmentsAsync(UserdId);

            Assert.Multiple(() =>
            {
                Assert.That(actual!.Count(), Is.EqualTo(expected.Length));
                Assert.That(actual!.First().Id, Is.EqualTo(expected.First().Id));
                Assert.That(actual!.First().TreatmentDate, Is.EqualTo(expected.First().TreatmentDate));
                Assert.That(actual!.First().MedicationName, Is.EqualTo(expected.First().MedicationName));
                Assert.That(actual!.First().ActiveIngredient, Is.EqualTo(expected.First().ActiveIngredient));
                Assert.That(actual!.First().PriceOfTheTreatment, Is.EqualTo(expected.First().PriceOfTheTreatment));
                Assert.That(actual!.First().ResultAndCommentAboutTheTreatment, Is.EqualTo(expected.First().ResultAndCommentAboutTheTreatment));
                Assert.That(actual!.First().CreatorId, Is.EqualTo(expected.First().CreatorId));
            });
        }

        [Test]
        public async Task AllTreatmentsAsyncShouldReturnNullIfUserHasNoNotes()
        {
            var actual = await treatmentService.AllTreatmentsAsync(NotExistingUserdId);

            Assert.That(actual, Is.Null);
        }

        [Test]
        public async Task DeleteTreatmentAsyncShouldDeleteTreatment()
        {
            await treatmentService.DeleteTreatmentAsync(UserdId, treatmentIdForTests);

            var findTreatment = await context.HiveTreatments.FirstOrDefaultAsync(c => c.Id == treatmentIdForTests);

            Assert.That(findTreatment, Is.Null);
        }

        [Test]
        public void DeleteTreatmentAsyncShouldThrowIfOwnerDoesNotExist()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await treatmentService.DeleteTreatmentAsync(NotExistingUserdId, treatmentIdForTests));
        }

        [Test]
        public void DeleteTreatmentAsyncShouldThrowIfTreatmentDoesNotExist()
        {
            int treatmentIdoBeDeleted = 9999;

            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await treatmentService.DeleteTreatmentAsync(UserdId, treatmentIdoBeDeleted));
        }

        [Test]
        public async Task DoesTreatmentExistsShouldReturnTrue()
        {
            var result = await treatmentService.DoesTreatmentExists(UserdId, treatmentIdForTests);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task DoestreatmentExistsShouldReturnFalseIfUserDoesNotExist()
        {
            var result = await treatmentService.DoesTreatmentExists(NotExistingUserdId, treatmentIdForTests);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task DoesTreatmentExistsShouldReturnFalseIfTreatmentDoesNotExist()
        {
            var result = await treatmentService.DoesTreatmentExists(UserdId, 9999);

            Assert.That(result, Is.False);
        }
    }
}