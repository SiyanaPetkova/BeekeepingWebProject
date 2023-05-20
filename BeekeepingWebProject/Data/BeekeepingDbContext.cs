namespace BeekeepingWebProject.Data
{
    using BeekeepingWebProject.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class BeekeepingDbContext : IdentityDbContext
    {
        public BeekeepingDbContext()
        {
        }

        public BeekeepingDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Apiary> Apiaries { get; init; } = null!;
        public DbSet<BeeHive> BeeHives { get; init; } = null!;
        public DbSet<BeeQueen> BeeQueens { get; init; } = null!;
        public DbSet<HiveTreatment> HiveTreatments { get; init; } = null!;

    }
}
