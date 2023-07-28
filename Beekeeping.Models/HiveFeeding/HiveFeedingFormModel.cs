namespace Beekeeping.Models.HiveFeeding
{
    using System.ComponentModel.DataAnnotations;

    using static Common.Validations.DataConstants.FeedingValidations;
    using static Common.NotificationMessages.ErrorMessages;

    public class HiveFeedingFormModel
    {
        public int Id { get; set; }

        [Display(Name = "Тип хранене")]
        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [StringLength(FeedingTypeMaxLenght, 
                      MinimumLength = FeedingTypeMinLenght, 
                      ErrorMessage = FieldMinAndMaxStringLenghtErrorMessage)]
        public string FeedingType { get; set; } = null!;

        [Display(Name = "Дата на храненето")]
        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        public DateTime DayOfFeeding { get; set; }

        [Display(Name = "Общо семейства")]
        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [Range(NumberOfFedColoniesMinValue, 
               NumberOfFedColoniesMaxValue, 
               ErrorMessage = FieldMinAndMaxRangeValueErrorMessage)]
        public int NumberOfBeeHives { get; set; }

        [Display(Name = "Стойност на храненето")]
        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [Range(FeedingPriceMinValue, 
               FeedingPriceMaxValue,
               ErrorMessage = FieldMinAndMaxRangeValueErrorMessage)]
        public decimal PriceOfFeeding { get; set; }

    }
}