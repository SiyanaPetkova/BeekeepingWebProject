namespace Beekeeping.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Globalization;
    using System;

    using Data.Models;

    public class FeedingEntityConfiguration : IEntityTypeConfiguration<HiveFeeding>
    {
        public void Configure(EntityTypeBuilder<HiveFeeding> builder)
        {
            builder
                .Property(hf => hf.PriceOfFeeding)
                .HasPrecision(18, 2);

            builder.HasData(GenerateFeeding());

        }
        private static HiveFeeding[] GenerateFeeding()
        {
            ICollection<HiveFeeding> feedings = new HashSet<HiveFeeding>();

            for (int i = 1; i <= 10; i++)
            {
                string dayOfFeeding = $"{i}.01.2023";
          
                HiveFeeding feeding = new HiveFeeding()
                {
                    Id = 30000 + i,
                    DayOfFeeding = DateTime.Parse(dayOfFeeding, CultureInfo.InvariantCulture, DateTimeStyles.None),
                    FeedingType = i % 2 == 0 ? "Питка" : "Сироп",
                    PriceOfFeeding = i % 2 == 0 ? 120 : 80,
                    NumberOfBeeHives = 10,
                    CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888"
                };

                feedings.Add(feeding);
            }

            return feedings.ToArray();
        }
    }
}