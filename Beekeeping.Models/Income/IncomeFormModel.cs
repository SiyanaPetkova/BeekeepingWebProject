namespace Beekeeping.Models.Income
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Beekeeping.Common.Validations.DataConstants.IncomeValidations;

    public class IncomeFormModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Вид приход")]
        [StringLength(IncomeTypeMaxLenght,
                      MinimumLength = IncomeTypeMinLenght,
                      ErrorMessage = "Полето трябва да съдържа между {1} и {2} символа")]
        public string TypeOfIncome { get; set; } = null!;

        [Required]
        [Display(Name = "Дата на прихода")]
        public DateTime DayOfTheIncome { get; set; }

        [Required]
        [Display(Name = "Стойност на прихода")]
        [Range(IncomeValueMinValue,
               IncomeValueMaxValue,
               ErrorMessage = "Стойността трябва да бъде число между {1} и {2}")]
        public decimal IncomeValue { get; set; }

    }
}