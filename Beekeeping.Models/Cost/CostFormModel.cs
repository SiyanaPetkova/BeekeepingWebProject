namespace Beekeeping.Models.Cost
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Beekeeping.Common.Validations.DataConstants.CostValidations;

    public class CostFormModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Полето e задължително.")]
        [Display(Name = "Вид разход")]
        [StringLength(CostTypeMaxLenght,
                      MinimumLength = CostTypeMinLenght,
                      ErrorMessage = "Полето трябва да съдържа между {1} и {2} символа")]
        public string TypeOfCost { get; set; } = null!;

        [Required(ErrorMessage = "Полето e задължително.")]
        [Display(Name = "Дата на разхода")]
        public DateTime DayOfTheCost { get; set; }

        [Required(ErrorMessage = "Полето e задължително.")]
        [Display(Name = "Стойност на разхода")]
        [Range(CostValueMinValue, 
               CostValueMaxValue,
               ErrorMessage = "Стойността трябва да бъде число между {1} и {2}")]
        public decimal CostValue { get; set; }

    }
}