namespace Beekeeping.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
        }
        public virtual ICollection<Apiary> Apiaries { get; set; } = new HashSet<Apiary>();
    }
}