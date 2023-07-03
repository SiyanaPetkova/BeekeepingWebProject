﻿namespace Beekeeping.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Beekeeping.Data.Common.DataConstants.HiveTreatmentValidations;

    public class HiveTreatment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(MedicationNameMaxLenght)]
        public string MedicationName { get; set; } = null!;

        [Required]
        [StringLength(ActiveIngredientMaxLenght)]
        public string ActiveIngredient { get; set; } = null!;

        public string? ResultAndCommentAboutTheTreatment { get; set; }

        public decimal PriceOfTheTreatment { get; set; }

        public DateTime TreatmentDate { get; set; }

        public ICollection<BeeColony> BeeHives { get; set; } = new HashSet<BeeColony>();

    }
}