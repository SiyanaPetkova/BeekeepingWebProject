namespace Beekeeping.Services.Interfaces
{
    using Models.Admin;

    public interface IAdminService
    {
        UsersInformationModel GetInformationAboutTheUsersAsync();
    }
}