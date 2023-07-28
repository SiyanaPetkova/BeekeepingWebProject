namespace Beekeeping.Services.Interfaces
{
    using System.Threading.Tasks;

    using Models.Inspection;

    public interface IInspectionService
    {
        Task AddNewInspectionAsync(InspectionFormModel model, string ownerId);

        Task<IEnumerable<InspectionViewModel>?> AllInspectionsPerColonyAsync(string ownerId, int id);

        Task<InspectionViewModel?> GetDetailsForTheInspectionAsync(string ownerId, int id);

        Task<InspectionFormModel> GetInspectionForEditAsync(string ownerId, int id);

        Task EditInspectionAsync(InspectionFormModel model, string ownerId, int id);

        Task<bool> DoesInspectionExist(string userId, int id);

        Task DeleteInspectionAsync(string userId, int id);

        Task<int> GetCurrentInspectionBeeColonyId(string userId, int id);

    }
}