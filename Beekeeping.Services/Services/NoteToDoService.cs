namespace Beekeeping.Services.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Data;
    using Data.Models;
    using Models.NoteToDo;
    using Interfaces;

    public class NoteToDoService : INoteToDoService
    {
        private readonly BeekeepingDbContext context;

        public NoteToDoService(BeekeepingDbContext context)
        {
            this.context = context;
        }

        public async Task AddNoteToDoAsync(NoteToDoFormModel model, string userId)
        {
            var note = new NoteToDo()
            {
                DateToBeDone = model.DateToBeDone,
                Description = model.Description,
                Finished = model.Finished,
                CreatorId = userId
            };

            await context.NoteToDos.AddAsync(note);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<NoteToDoViewModel>?> AllNotesAsync(string userId)
        {
            bool doesUserHasNotesAdded = await context.NoteToDos.AnyAsync(a => a.CreatorId == userId);

            if (!doesUserHasNotesAdded)
            {
                return null;
            }

            return await context.NoteToDos
                                 .Where(n => n.CreatorId == userId)
                                 .OrderByDescending(n => n.DateToBeDone)
                                 .Select(n => new NoteToDoViewModel()
                                 {
                                     Id = n.Id,
                                     DateToBeDone = n.DateToBeDone,
                                     Description = n.Description,
                                     Finished = n.Finished == true ? "Да" : "Не",
                                     CreatorId = userId
                                 })
                                 .ToArrayAsync();
        }

        public async Task DeleteNotesAsync(string userId, int id)
        {
            var note = await context.NoteToDos
                          .FirstOrDefaultAsync(f => f.Id == id && f.CreatorId == userId);

            if (note == null)
            {
                throw new InvalidOperationException();
            }

            context.NoteToDos.Remove(note);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DoesNoteExists(string userId, int id)
        {
            return await context.NoteToDos
                          .AnyAsync(f => f.Id == id && f.CreatorId == userId);
        }

        public async Task EditNoteAsync(NoteToDoFormModel model, string userId, int id)
        {
            var note = await context.NoteToDos
                         .FirstOrDefaultAsync(f => f.Id == id && f.CreatorId == userId);

            if (note == null)
            {
                throw new InvalidOperationException();
            }

            note.DateToBeDone = model.DateToBeDone;
            note.Description = model.Description;
            note.Finished = model.Finished;

            await context.SaveChangesAsync();
        }

        public async Task<NoteToDoFormModel> GetNoteForEditAsync(string userId, int id)
        {
            var note = await context.NoteToDos
                         .FirstOrDefaultAsync(f => f.Id == id && f.CreatorId == userId);

            if (note == null)
            {
                throw new InvalidOperationException();
            }

            return new NoteToDoFormModel()
            {
                Id = id,
                DateToBeDone = note.DateToBeDone,
                Description = note.Description,
                Finished = note.Finished,
                CreatorId = note.CreatorId
            };
        }
    }   
}