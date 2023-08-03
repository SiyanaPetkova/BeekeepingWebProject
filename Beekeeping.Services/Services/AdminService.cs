namespace Beekeeping.Services.Services
{
    using Data;
    using Interfaces;
    using Models.Admin;

    public class AdminService : IAdminService
    {
        private readonly BeekeepingDbContext context;

        public AdminService(BeekeepingDbContext context)
        {
            this.context = context;
        }

        public UsersInformationModel GetInformationAboutTheUsersAsync()
        {
            var totalUsers = context.Users.Count();

            var totalUsersWithApiaries = context.Apiaries.GroupBy(a => a.OwnerId).Count();

            var totalApiaries = context.Apiaries.Count();

            var totalBeeColonies = context.BeeColonies.Count();

            return new UsersInformationModel()
            {
                TotalUsers = totalUsers,
                TotalUsersWithApiaries = totalUsersWithApiaries,
                TotalApiaries = totalApiaries,
                TotalBeeColonies = totalBeeColonies
            };
        }
    }
}