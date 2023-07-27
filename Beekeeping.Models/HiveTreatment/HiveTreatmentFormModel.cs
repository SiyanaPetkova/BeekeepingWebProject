namespace Beekeeping.Models.HiveTreatment
{
    using System.ComponentModel.DataAnnotations;

    using static Beekeeping.Common.Validations.DataConstants.HiveTreatmentValidations;

    public class HiveTreatmentFormModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Полето e задължително.")]
        [StringLength(MedicationNameMaxLenght, 
                      MinimumLength = MedicationNameMinLenght,
                      ErrorMessage = "Името на препарата трябва да съдържа между {1} и {2} символа")]
        [Display(Name = "Име на препарата")]
        public string MedicationName { get; set; } = null!;

        [Required(ErrorMessage = "Полето e задължително.")]
        [StringLength(ActiveIngredientMaxLenght,
                      MinimumLength = ActiveIngredientMinLenght,          
                      ErrorMessage = "Активната съставкана препарата трябва да съдържа между {1} и {2} символа")]
        [Display(Name = "Активна съставка")]
        public string ActiveIngredient { get; set; } = null!;

        [Display(Name = "Резултати и коментари")]
        public string? ResultAndCommentAboutTheTreatment { get; set; }

        [Display(Name = "Обща стойност на третирането")]
        [Range(TreatmentPriceMinValue, 
               TreatmentPriceMaxValue, 
               ErrorMessage = "Стойността на третирането трябва да бъде между {1} и {2}")]
        public decimal PriceOfTheTreatment { get; set; }

        [Display(Name = "Дата на третирането")]
        public DateTime TreatmentDate { get; set; }

        [Required(ErrorMessage = "Полето e задължително.")]
        [Display(Name = "Брой третирани семейства")]
        [Range(NumberOfTreatedColoniesMinValue, 
               NumberOfTreatedColoniesMaxValue, 
               ErrorMessage = "Броят на третираните кошери трябва да бъде между {1} и {2}")]
        public int NumberOfTreatedColonies { get; set; }

    }
}