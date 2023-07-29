namespace Beekeeping.Models.Income
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class IncomeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Вид приход")]
        public string TypeOfIncome { get; set; } = null!;

        [Display(Name = "Дата на прихода")]
        [DataType(DataType.Date)]
        public DateTime DayOfTheIncome { get; set; }

        [Display(Name = "Стойност на прихода")]
        public decimal IncomeValue { get; set; }

        public string CreatorId { get; set; } = null!;
    }
}