namespace Beekeeping.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    using Data.Models;
    using System.Globalization;

    public class CostEntityConfiguration : IEntityTypeConfiguration<Cost>
    {
        public void Configure(EntityTypeBuilder<Cost> builder)
        {
            builder
                   .Property(c => c.CostValue)
                   .HasPrecision(18, 2);

            builder.HasData(GenerateCosts());
        }

        private static Cost[] GenerateCosts()
        {
            ICollection<Cost> costs = new HashSet<Cost>();

            Cost cost;

            cost = new Cost()
            {
                Id = 50001,
                DayOfTheCost = DateTime.Parse("01.01.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                TypeOfCost = "Третиране",
                CostValue = 100,
                CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888"
            };
            costs.Add(cost);

            cost = new Cost()
            {
                Id = 50002,
                DayOfTheCost = DateTime.Parse("01.01.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                TypeOfCost = "Хранене",
                CostValue = 120,
                CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888"
            };
            costs.Add(cost);

            cost = new Cost()
            {
                Id = 50003,
                DayOfTheCost = DateTime.Parse("02.01.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                TypeOfCost = "Третиране",
                CostValue = 40,
                CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888"
            };
            costs.Add(cost);

            cost = new Cost()
            {
                Id = 50004,
                DayOfTheCost = DateTime.Parse("02.01.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                TypeOfCost = "Хранене",
                CostValue = 80,
                CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888"
            };
            costs.Add(cost);

            cost = new Cost()
            {
                Id = 50005,
                DayOfTheCost = DateTime.Parse("03.01.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                TypeOfCost = "Третиране",
                CostValue = 100,
                CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888"
            };
            costs.Add(cost);

            cost = new Cost()
            {
                Id = 50006,
                DayOfTheCost = DateTime.Parse("03.01.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                TypeOfCost = "Хранене",
                CostValue = 120,
                CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888"
            };
            costs.Add(cost);

            cost = new Cost()
            {
                Id = 50007,
                DayOfTheCost = DateTime.Parse("04.01.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                TypeOfCost = "Третиране",
                CostValue = 40,
                CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888"
            };
            costs.Add(cost);

            cost = new Cost()
            {
                Id = 50008,
                DayOfTheCost = DateTime.Parse("05.22.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                TypeOfCost = "Транспорт",
                CostValue = 200,
                CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888"
            };
            costs.Add(cost);

            cost = new Cost()
            {
                Id = 50009,
                DayOfTheCost = DateTime.Parse("06.15.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                TypeOfCost = "Пчеларски инвентар",
                CostValue = 150,
                CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888"
            };
            costs.Add(cost);

            return costs.ToArray();
        }
    }
}