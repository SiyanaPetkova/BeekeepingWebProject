namespace Beekeeping.Test.Services
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;

    using Data.Models;
    using Models.NoteToDo;

    internal class NoteTodoServiceTest
    {
        private BeekeepingDbContext context;
        private INoteToDoService noteToDoService;

        private int noteIdForTests;

        [SetUp]
        public async Task SetUp()
        {
            noteIdForTests = 20001;

            var notes = GenerateNoteToDoData();

            context = new BeekeepingDbContext(GetContextOptions());

            await context.NoteToDos.AddRangeAsync(notes);

            await context.SaveChangesAsync();

            noteToDoService = new NoteToDoService(context);
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }

        [Test]
        public async Task AddNotesAsyncShouldAddNewCost()
        {
            var expected = new NoteToDoFormModel()
            {
                Id = 20003,
                DateToBeDone = DateTime.Parse("06.15.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                Description = "Пролетно подхранване",
                CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888",
                Finished = false
            };

            await noteToDoService.AddNoteToDoAsync(expected, UserdId);

            var actual = await context.NoteToDos.FirstOrDefaultAsync(c => c.Id == expected.Id);

            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual!.DateToBeDone, Is.EqualTo(expected.DateToBeDone));
                Assert.That(actual.Description, Is.EqualTo(expected.Description));
                Assert.That(actual.CreatorId, Is.EqualTo(expected.CreatorId));
                Assert.That(actual.Finished, Is.EqualTo(expected.Finished));
            });
        }

        [Test]
        public async Task AllNotesAsyncShouldReturnCorectInformation()
        {
            var expected = await context.NoteToDos
                .Where(n => n.CreatorId == UserdId)
                .OrderByDescending(n => n.DateToBeDone)
                .Select(n => new NoteToDoViewModel()
                {
                    Id = n.Id,
                    DateToBeDone = n.DateToBeDone.ToLongDateString(),
                    Description = n.Description,
                    Finished = n.Finished == true ? "Да" : "Не",
                    CreatorId = UserdId
                })
                .ToArrayAsync();

            var actual = await noteToDoService.AllNotesAsync(UserdId);

            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual!.First().DateToBeDone, Is.EqualTo(expected.First().DateToBeDone));
                Assert.That(actual!.First().Description, Is.EqualTo(expected.First().Description));
                Assert.That(actual!.First().CreatorId, Is.EqualTo(expected.First().CreatorId));
                Assert.That(actual!.First().Finished, Is.EqualTo(expected.First().Finished));
            });
        }

        [Test]
        public async Task AllNotesAsyncShouldReturnNullIfUserHasNoNotes()
        {
            var actual = await noteToDoService.AllNotesAsync(NotExistingUserdId);

            Assert.That(actual, Is.Null);
        }

        [Test]
        public async Task DeleteNoteAsyncShouldDeleteNote()
        {
            await noteToDoService.DeleteNotesAsync(UserdId, noteIdForTests);

            var findNote = await context.NoteToDos.FirstOrDefaultAsync(c => c.Id == noteIdForTests);

            Assert.That(findNote, Is.Null);
        }

        [Test]
        public void DeleteNoteAsyncShouldThrowIfOwnerDoesNotExist()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await noteToDoService.DeleteNotesAsync(NotExistingUserdId, noteIdForTests));
        }

        [Test]
        public void DeleteNoteAsyncShouldThrowIfNoteDoesNotExist()
        {
            int noteIdoBeDeleted = 9999;

            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await noteToDoService.DeleteNotesAsync(UserdId, noteIdoBeDeleted));
        }

        [Test]
        public async Task DoesNoteExistsShouldReturnTrue()
        {
            var result = await noteToDoService.DoesNoteExists(UserdId, noteIdForTests);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task DoesNoteExistsShouldReturnFalseIfUserDoesNotExist()
        {
            var result = await noteToDoService.DoesNoteExists(NotExistingUserdId, noteIdForTests);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task DoesNoteExistsShouldReturnFalseIfNoteDoesNotExist()
        {
            var result = await noteToDoService.DoesNoteExists(UserdId, 9999);

            Assert.That(result, Is.False);
        }
    }
}