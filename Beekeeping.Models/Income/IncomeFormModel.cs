namespace Beekeeping.Models.Income
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Beekeeping.Common.Validations.DataConstants.IncomeValidations;

    public class IncomeFormModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(IncomeTypeMaxLenght, 
                      MinimumLength = IncomeTypeMinLenght, 
                      ErrorMessage = "Полето трябва да съдържа между {1} и {2] символа")]
        [Display(Name = "Вид приход")]
        public string TypeOfIncome { get; set; } = null!;

        [Required]
        [Display(Name = "Дата на прихода")]
        public DateTime DayOfTheIncome { get; set; }

        [Required]
        [Display(Name = "Стойност на прихода")]
        public decimal IncomeValue { get; set; }
    }
}