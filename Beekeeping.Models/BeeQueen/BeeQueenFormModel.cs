namespace Beekeeping.Models.BeeQueen
{
    using System.ComponentModel.DataAnnotations;

    using static Common.Validations.DataConstants.BeeQueenValidations;
    using static Common.NotificationMessages.ErrorMessages;

    public class BeeQueenFormModel
    {
        [Display(Name = "Майкопроизводител")]
        [RegularExpression(StringRequirmentRegex, ErrorMessage = StringRequirmentFieldsErrorMessage)]
        [StringLength(BreederMaxLenght,
                      MinimumLength = BreederMinLenght,
                      ErrorMessage = FieldMinAndMaxStringLenghtErrorMessage)]
        public string? Breeder { get; set; }

        [Display(Name = "Порода на майката")]
        [RegularExpression(StringRequirmentRegex, ErrorMessage = StringRequirmentFieldsErrorMessage)]
        [StringLength(BreederMaxLenght,
                     MinimumLength = BreederMinLenght,
                     ErrorMessage = FieldMinAndMaxStringLenghtErrorMessage)]
        public string? BeeQueenType { get; set; }

        [Display(Name = "Година на излюпване")]
        [Range(BeeQueenYearMinValue, 
               BeeQueenYearMaxValue, 
               ErrorMessage = FieldMinAndMaxRangeValueErrorMessage)]
        public int BeeQueenYearOfBirth { get; set; }

        public int BeeColonyId { get; set; }
    }
}