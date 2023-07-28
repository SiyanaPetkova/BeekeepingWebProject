namespace Beekeeping.Models.Cost
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Common.Validations.DataConstants.CostValidations;
    using static Common.NotificationMessages.ErrorMessages;

    public class CostFormModel
    {
        public int Id { get; set; }

        [Display(Name = "Вид разход")]
        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [StringLength(CostTypeMaxLenght,
                      MinimumLength = CostTypeMinLenght,
                      ErrorMessage = FieldMinAndMaxStringLenghtErrorMessage)]
        public string TypeOfCost { get; set; } = null!;

        [Display(Name = "Дата на разхода")]
        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DayOfTheCost { get; set; }

        [Display(Name = "Стойност на разхода")]
        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [Range(CostValueMinValue, 
               CostValueMaxValue,
               ErrorMessage = FieldMinAndMaxRangeValueErrorMessage)]
        public decimal CostValue { get; set; }

    }
}