namespace Beekeeping.Models.Admin
{
    public class UserAdminModel
    {
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool IsAdmin { get; set; }

    }
}