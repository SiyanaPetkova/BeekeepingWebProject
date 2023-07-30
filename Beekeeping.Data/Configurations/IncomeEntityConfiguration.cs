namespace Beekeeping.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Collections.Generic;
    using System.Linq;

    using Data.Models;
    using System.Globalization;

    public class IncomeEntityConfiguration : IEntityTypeConfiguration<Income>
    {
        public void Configure(EntityTypeBuilder<Income> builder)
        {
            builder
                   .Property(i => i.IncomeValue)
                   .HasPrecision(18, 2);

            builder.HasData(GenerateIncome());
        }

        private static Income[] GenerateIncome()
        {
            ICollection<Income> incomes = new HashSet<Income>();

            Income income;

            income = new Income()
            {
                Id = 60001,
                IncomeValue = 950,
                TypeOfIncome = "Продаден прашец",
                DayOfTheIncome = DateTime.Parse("04.20.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888"
            };
            incomes.Add(income);

            income = new Income()
            {
                Id = 60002,
                IncomeValue = 120,
                TypeOfIncome = "Продаден мед",
                DayOfTheIncome = DateTime.Parse("05.10.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888"
            };
            incomes.Add(income);

            income = new Income()
            {
                Id = 60003,
                IncomeValue = 250,
                TypeOfIncome = "Продаден мед",
                DayOfTheIncome = DateTime.Parse("05.14.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888"
            };
            incomes.Add(income);

            income = new Income()
            {
                Id = 60004,
                IncomeValue = 240,
                TypeOfIncome = "Продаден прашец",
                DayOfTheIncome = DateTime.Parse("05.28.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888"
            };
            incomes.Add(income);

            income = new Income()
            {
                Id = 60005,
                IncomeValue = 110,
                TypeOfIncome = "Продаден прополис",
                DayOfTheIncome = DateTime.Parse("05.31.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888"
            };
            incomes.Add(income);

            income = new Income()
            {
                Id = 60006,
                IncomeValue = 1350,
                TypeOfIncome = "Продаден мед",
                DayOfTheIncome = DateTime.Parse("06.06.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888"
            };
            incomes.Add(income);

            income = new Income()
            {
                Id = 60007,
                IncomeValue = 290,
                TypeOfIncome = "Продаден мед",
                DayOfTheIncome = DateTime.Parse("06.30.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888"
            };
            incomes.Add(income);

            return incomes.ToArray();
        }
    }
}