namespace Beekeeping.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Models.Apiary;

    public interface IApiaryService
    {
        Task AddNewApiaryAsync(ApiaryFormModel model, string ownerId);

        Task<IEnumerable<ApiaryViewModel>?> AllApiaryAsync(string ownerId);

        Task<ApiaryEditFormModel> GetApiaryForEditAsync(string ownerId, int apiaryId);

        Task EditApiaryAsync(ApiaryEditFormModel model, int id, string ownerId);

        Task<bool> IsTheUserOwner(string ownerId);

        Task<bool> DoesApiaryExists(string ownerId, int id);

        Task DeleteApiaryAsync(string ownerId, int apiaryId);

        List<AllApiariesForSelectModel> AllApiariesForSelectAsync(IEnumerable<ApiaryViewModel>? apiaries);
    }
}