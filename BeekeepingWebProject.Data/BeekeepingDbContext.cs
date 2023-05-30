namespace BeekeepingWebProject.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using BeekeepingWebProject.Data.Models;

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
        public DbSet<Gallery> Galleries { get; init; } = null!;

    }
}
