namespace Beekeeping.Models.Income
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Common.Validations.DataConstants.IncomeValidations;
    using static Common.NotificationMessages.ErrorMessages;

    public class IncomeFormModel
    {
        public int Id { get; set; }

        [Display(Name = "Вид приход")]
        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [RegularExpression(StringRequirmentRegex, ErrorMessage = StringRequirmentFieldsErrorMessage)]
        [StringLength(IncomeTypeMaxLenght,
                      MinimumLength = IncomeTypeMinLenght,
                      ErrorMessage = FieldMinAndMaxStringLenghtErrorMessage)]
        public string TypeOfIncome { get; set; } = null!;

        [Display(Name = "Дата на прихода")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        public DateTime DayOfTheIncome { get; set; }

        [Display(Name = "Стойност на прихода")]
        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [Range(IncomeValueMinValue,
               IncomeValueMaxValue,
               ErrorMessage = FieldMinAndMaxRangeValueErrorMessage)]
        public decimal IncomeValue { get; set; }

    }
}