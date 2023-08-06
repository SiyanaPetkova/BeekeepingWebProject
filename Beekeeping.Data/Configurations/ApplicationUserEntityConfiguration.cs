namespace Beekeeping.Data.Configurations
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    using Data.Models;

    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(GenerateDemoUser());
        }

        private static ApplicationUser GenerateDemoUser()
        {

            static string GenerateSecurityStamp()
            {
                var guid = Guid.NewGuid();
                return String.Concat(Array.ConvertAll(guid.ToByteArray(), b => b.ToString("X2")));
            }

            string id = "44c36b39-ad0a-4260-b448-45bb03158888";

            var user = new ApplicationUser()
            {
                Id = Guid.Parse(id),
                Email = "demouser@gmail.com",
                UserName = "demouser@gmail.com",
                NormalizedUserName = "DEMOUSER@GMAIL.COM",
                NormalizedEmail = "DEMOUSER@GMAIL.COM",
                SecurityStamp = GenerateSecurityStamp()
            };

            var hasher = new PasswordHasher<ApplicationUser>();

            string password = "DemoUser1";

            user.PasswordHash = hasher.HashPassword(user, password);


            return user;
        }
    }
}