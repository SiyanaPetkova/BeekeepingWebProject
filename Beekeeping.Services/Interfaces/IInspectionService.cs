namespace Beekeeping.Services.Interfaces
{
    using Beekeeping.Models.Inspection;
    using System.Threading.Tasks;

    public interface IInspectionService
    {
        Task AddNewInspectionAsync(InspectionFormModel model, string ownerId);
    }
}