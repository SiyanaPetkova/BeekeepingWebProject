namespace Beekeeping.Services.Interfaces
{
     using Models.NoteToDo;

    public interface INoteToDoService
    {
        Task<IEnumerable<NoteToDoViewModel>?> AllNotesAsync(string userId);

        Task AddNoteToDoAsync(NoteToDoFormModel model, string userId);

        Task DeleteNotesAsync(string ownerId, int id);

        Task<bool> DoesNoteExists(string userId, int id);

        Task<NoteToDoFormModel> GetNoteForEditAsync(string ownerId, int id);

        Task EditNoteAsync(NoteToDoFormModel model, string ownerId, int id);

        Task<int> DoesUserHasNotFinishedTasks(string userId);
    }
}