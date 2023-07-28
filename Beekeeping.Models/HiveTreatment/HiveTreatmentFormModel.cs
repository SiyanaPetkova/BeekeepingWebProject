namespace Beekeeping.Models.HiveTreatment
{
    using System.ComponentModel.DataAnnotations;

    using static Common.Validations.DataConstants.HiveTreatmentValidations;
    using static Common.NotificationMessages.ErrorMessages;

    public class HiveTreatmentFormModel
    {
        public int Id { get; set; }

        [Display(Name = "Име на препарата")]
        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [StringLength(MedicationNameMaxLenght,
                      MinimumLength = MedicationNameMinLenght,
                      ErrorMessage = FieldMinAndMaxStringLenghtErrorMessage)]
        public string MedicationName { get; set; } = null!;

        [Display(Name = "Активна съставка")]
        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [StringLength(ActiveIngredientMaxLenght,
                      MinimumLength = ActiveIngredientMinLenght,
                      ErrorMessage = FieldMinAndMaxStringLenghtErrorMessage)]
        public string ActiveIngredient { get; set; } = null!;

        [Display(Name = "Резултати и коментари")]
        public string? ResultAndCommentAboutTheTreatment { get; set; }

        [Display(Name = "Обща стойност на третирането")]
        [Range(TreatmentPriceMinValue,
               TreatmentPriceMaxValue,
               ErrorMessage = FieldMinAndMaxRangeValueErrorMessage)]
        public decimal PriceOfTheTreatment { get; set; }

        [Display(Name = "Дата на третирането")]
        public DateTime TreatmentDate { get; set; }

        [Display(Name = "Брой третирани семейства")]
        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [Range(NumberOfTreatedColoniesMinValue,
               NumberOfTreatedColoniesMaxValue,
               ErrorMessage = FieldMinAndMaxRangeValueErrorMessage)]
        public int NumberOfTreatedColonies { get; set; }

    }
}