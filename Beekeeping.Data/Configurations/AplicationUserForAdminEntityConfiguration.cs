namespace Beekeeping.Data.Configurations
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    using Data.Models;

    public class AplicationUserForAdminEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(GenerateUserForAdministrator());
        }

        private static ApplicationUser GenerateUserForAdministrator()
        {

            static string GenerateSecurityStamp()
            {
                var guid = Guid.NewGuid();
                return String.Concat(Array.ConvertAll(guid.ToByteArray(), b => b.ToString("X2")));
            }

            string id = "d23c4f40-0178-4622-b307-b482a79aa316";

            var adminUser = new ApplicationUser()
            {
                Id = Guid.Parse(id),
                Email = "testAdmin@gmail.com",
                UserName = "testAdmin@gmail.com",
                NormalizedUserName = "TESTADMIN@GMAIL.COM",
                NormalizedEmail = "TESTADMIN@GMAIL.COM",
                SecurityStamp = GenerateSecurityStamp()
            };

            var hasher = new PasswordHasher<ApplicationUser>();

            string password = "testAdmin123";

            adminUser.PasswordHash = hasher.HashPassword(adminUser, password);

            return adminUser;
        }
    }
}
