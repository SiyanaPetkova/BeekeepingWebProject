namespace Beekeeping.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    using Beekeeping.Data.Models;


    public class BeekeepingDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public BeekeepingDbContext(DbContextOptions options)
       : base(options)
        {
        }

        public DbSet<Apiary> Apiaries { get; init; } = null!;
        public DbSet<BeeColony> BeeColonies { get; init; } = null!;
        public DbSet<BeeQueen> BeeQueens { get; init; } = null!;
        public DbSet<HiveTreatment> HiveTreatments { get; init; } = null!;
        public DbSet<HiveFeeding> HiveFeeding { get; init; } = null!;
        public DbSet<Inspection> Inspections { get; init; } = null!;
        public DbSet<Cost> Costs { get; init; } = null!;
        public DbSet<Income> Incomes { get; init; } = null!;
        public DbSet<NoteToDo> NoteToDos { get; init; } = null!;
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(BeekeepingDbContext))
                                    ?? Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);

         
            builder.Entity<Cost>()
                   .Property(c => c.CostValue)
                   .HasPrecision(18, 2);

            builder.Entity<Income>()
            .Property(i => i.IncomeValue)
                   .HasPrecision(18, 2);
          
            base.OnModelCreating(builder);
        }
    }
}
