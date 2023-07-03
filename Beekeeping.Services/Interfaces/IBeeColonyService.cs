namespace Beekeeping.Services.Interfaces
{
    using Beekeeping.Models.BeeColony;
    using System.Threading.Tasks;

    public interface IBeeColonyService
    {
        Task AddNewBeeColonyAsync(BeeColonyFormModel model, string ownerId);
    }
}