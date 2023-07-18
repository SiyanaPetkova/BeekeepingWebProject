namespace Beekeeping.Services.Interfaces
{
    using Beekeeping.Models.BeeColony;
    using System.Threading.Tasks;

    public interface IBeeColonyService
    {
        Task AddNewBeeColonyAsync(BeeColonyFormModel model, string ownerId);

        Task<BeeColonyFormModel> GetBeeColonyForEditAsync(string ownerId, int colonyId);

        Task EditBeeColonyAsync(BeeColonyFormModel model, string ownerId, int colonyId);

        Task<IEnumerable<BeeColonyViewModel>?> AllColoniesAsync(string ownerId, int apiaryId);

        Task<BeeColonyViewModel> GetDetailsForTheBeeColonyAsync(string ownerId, int colonyId);       

        Task<bool> IsTheUserOwner(string ownerId);

        Task<bool> DoesBeeColonyExist(string userId, int id);

        Task DeleteBeeColonyAsync(string userId, int id);

    }
}