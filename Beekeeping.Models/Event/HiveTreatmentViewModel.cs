namespace Beekeeping.Models.Event
{
    using System;

    public class HiveTreatmentViewModel
    {
        public int Id { get; set; }

        public string MedicationName { get; set; } = null!;

        public string ActiveIngredient { get; set; } = null!;

        public string? ResultAndCommentAboutTheTreatment { get; set; }

        public decimal PriceOfTheTreatment { get; set; }

        public DateTime TreatmentDate { get; set; }

        public int NumberOfTreatedColonies { get; set; }

        public string CreatorId { get; set; } = null!;
    }
}