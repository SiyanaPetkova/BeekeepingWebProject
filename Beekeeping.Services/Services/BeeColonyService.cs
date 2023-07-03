namespace Beekeeping.Services.Services
{
    using Beekeeping.Data;
    using Beekeeping.Models.BeeColony;
    using Beekeeping.Services.Interfaces;
    using System.Threading.Tasks;

    public class BeeColonyService : IBeeColonyService
    {
        private readonly BeekeepingDbContext context;

        public BeeColonyService(BeekeepingDbContext context)
        {
            this.context = context;
        }

        public Task AddNewBeeColonyAsync(BeeColonyFormModel model, string ownerId)
        {
            throw new NotImplementedException();
        }
    }
}