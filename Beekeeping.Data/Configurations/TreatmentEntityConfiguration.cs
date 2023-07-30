namespace Beekeeping.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Globalization;

    using Data.Models;

    public class TreatmentEntityConfiguration : IEntityTypeConfiguration<HiveTreatment>
    {
        public void Configure(EntityTypeBuilder<HiveTreatment> builder)
        {

            builder
                   .Property(ht => ht.PriceOfTheTreatment)
                   .HasPrecision(18, 2);

            builder.HasData(Generatetreatments());
        }

        private static HiveTreatment[] Generatetreatments()
        {
            ICollection<HiveTreatment> treatments = new HashSet<HiveTreatment>();

            for (int i = 1; i <= 4; i++)
            {
                string dayOfTreatment = $"{i}.01.2023";
            
                HiveTreatment feeding = new HiveTreatment()
                {
                    Id = 40000 + i,
                    TreatmentDate = DateTime.Parse(dayOfTreatment, CultureInfo.InvariantCulture, DateTimeStyles.None),
                    ResultAndCommentAboutTheTreatment = $"Опаразитеност около {i}%",
                    MedicationName = i % 2 == 0 ? "Оксалова киселина" : "Апивар",
                    ActiveIngredient = i % 2 == 0 ? "Оксалова киселина" : "Амитраз",
                    PriceOfTheTreatment = i % 2 == 0 ? 40 : 100,
                    NumberOfTreatedColonies = 10,
                    CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888"
                };

                treatments.Add(feeding);
            }

            return treatments.ToArray();
        }
    }
}