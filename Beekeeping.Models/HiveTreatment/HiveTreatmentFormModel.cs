namespace Beekeeping.Models.HiveTreatment
{
    using System.ComponentModel.DataAnnotations;

    using static Beekeeping.Common.Validations.DataConstants.HiveTreatmentValidations;

    public class HiveTreatmentFormModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(MedicationNameMaxLenght, MinimumLength = MedicationNameMinLenght)]
        public string MedicationName { get; set; } = null!;

        [Required]
        [StringLength(ActiveIngredientMaxLenght, MinimumLength = ActiveIngredientMinLenght)]
        public string ActiveIngredient { get; set; } = null!;

        public string? ResultAndCommentAboutTheTreatment { get; set; }

        public decimal PriceOfTheTreatment { get; set; }

        public DateTime TreatmentDate { get; set; }

        [Required]
        public int NumberOfTreatedColonies { get; set; }

    }
}