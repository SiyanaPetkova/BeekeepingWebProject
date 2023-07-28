namespace Beekeeping.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Beekeeping.Common.Validations.DataConstants.InspectionValidations;

    public class Inspection
    {
        public int Id { get; set; }

        public DateTime DayOfInspection { get; set; }

        [StringLength(InspectionDescriptionMaxLenght)]
        public string? Description { get; set; }

        public int NumberOfFrames { get; set; }

        public int? NumberOfBroodFrames { get; set; }

        public int Strenght { get; set; }

        public int Temperament { get; set; }
             
        [ForeignKey(nameof(BeeColony))]
        public int BeeColonyId { get; set; }
        public BeeColony? BeeColony { get; set; }

    }
}