namespace Beekeeping.Data.Configurations
{
    using Beekeeping.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class InspectionEntityConfiguration : IEntityTypeConfiguration<Inspection>
    {
        public void Configure(EntityTypeBuilder<Inspection> builder)
        {
            builder.HasData(GenerateInspections());
        }

        private static Inspection[] GenerateInspections()
        {
            ICollection<Inspection> inspections = new HashSet<Inspection>();

            int idGenerateCount = 0;

            for (int i = 1; i <= 9; i++)
            {
                int beeColonyId = 10000 + i;

                for (int j = 1; j <= 6; j++)
                {
                    string dayOfInspection = $"01.0{j}.2023";

                    int inspectionId = 100000 + idGenerateCount;

                    var inspection = new Inspection()
                    {
                        Id = inspectionId,
                        DayOfInspection = DateTime.Parse(dayOfInspection, CultureInfo.InvariantCulture, DateTimeStyles.None),
                        Description = "Общ преглед",
                        NumberOfFrames = 4 + j,
                        NumberOfBroodFrames = 0 + j,
                        Strenght = 3 + j,
                        Temperament = 8,
                        BeeColonyId = beeColonyId
                    };
                    idGenerateCount++;

                    inspections.Add(inspection);
                }
            }
            return inspections.ToArray();
        }
    }
}