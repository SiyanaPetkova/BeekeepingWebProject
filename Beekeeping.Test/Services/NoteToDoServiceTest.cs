namespace Beekeeping.Test.Services
{
    #nullable disable 

    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Threading.Tasks;

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

            await noteToDoService.AddNoteToDoAsync(expected, UserId);

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
                .Where(n => n.CreatorId == UserId)
                .OrderByDescending(n => n.DateToBeDone)
                .Select(n => new NoteToDoViewModel()
                {
                    Id = n.Id,
                    DateToBeDone = n.DateToBeDone.ToLongDateString(),
                    Description = n.Description,
                    Finished = n.Finished == true ? "Да" : "Не",
                    CreatorId = UserId
                })
                .ToArrayAsync();

            var actual = await noteToDoService.AllNotesAsync(UserId);

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
            await noteToDoService.DeleteNotesAsync(UserId, noteIdForTests);

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
                   => await noteToDoService.DeleteNotesAsync(UserId, noteIdoBeDeleted));
        }

        [Test]
        public async Task DoesNoteExistsShouldReturnTrue()
        {
            var result = await noteToDoService.DoesNoteExists(UserId, noteIdForTests);

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
            var result = await noteToDoService.DoesNoteExists(UserId, 9999);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task GetNoteForEditAsyncShouldReturnCorrectApiaty()
        {
            var note = await context.NoteToDos.FirstOrDefaultAsync(f => f.Id == noteIdForTests && f.CreatorId == UserId);

            var expected = new NoteToDoFormModel()
                    {
                        Id = note.Id,
                        DateToBeDone = note.DateToBeDone,
                        Description = note.Description,
                        Finished = note.Finished,
                        CreatorId = note.CreatorId
                    };

            var actual = await noteToDoService.GetNoteForEditAsync(UserId, noteIdForTests);

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
        public void GetNoteForEditAsyncShouldThrowIfOwnerDoesNotExist()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await noteToDoService.GetNoteForEditAsync(NotExistingUserdId, noteIdForTests));
        }

        [Test]
        public void GetNoteForEditAsyncShouldThrowIfNoteDoesNotExist()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await noteToDoService.GetNoteForEditAsync(NotExistingUserdId, 9999));
        }

        [Test]
        public async Task EditApiaryAsyncShouldEditApiaryCorrectly()
        {
            var note = await context.NoteToDos.FirstOrDefaultAsync(f => f.Id == noteIdForTests && f.CreatorId == UserId);

            var actual = new NoteToDoFormModel()
            {
                Id = note.Id,
                DateToBeDone = note.DateToBeDone,
                Description = "Третиране",
                Finished = true,
                CreatorId = note.CreatorId
            };

            await noteToDoService.EditNoteAsync(actual, UserId, noteIdForTests);

            var expected = await context.NoteToDos.FirstOrDefaultAsync(f => f.Id == noteIdForTests && f.CreatorId == UserId);

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
        public void EditNoteAsyncShouldThrowIfOwnerDoesNotExist()
        {
            var model = new NoteToDoFormModel()
            {
                Id = 20001,
                DateToBeDone = DateTime.Parse("07.22.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                Description = "Третиране против акар",
                CreatorId = NotExistingUserdId,
                Finished = false
            };

            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await noteToDoService.EditNoteAsync(model, NotExistingUserdId, noteIdForTests));
        }

        [Test]
        public void EditNoteAsyncShouldThrowIfNoteDoesNotExist()
        {
            var model = new NoteToDoFormModel()
            {
                Id = 9999,
                DateToBeDone = DateTime.Parse("07.22.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                Description = "Третиране против акар",
                CreatorId = NotExistingUserdId,
                Finished = false
            };

            Assert.ThrowsAsync<InvalidOperationException>(async ()
                   => await noteToDoService.EditNoteAsync(model, UserId, 9999));
        }

        [Test]
        public async Task DoesUserHasNotFinishedTasksShouldReturnCountOfTasks()
        {
            var expected = 1;

            var actual = await noteToDoService.DoesUserHasNotFinishedTasks(UserId);

            Assert.That(actual, Is.EqualTo(expected));
        }

    }
}