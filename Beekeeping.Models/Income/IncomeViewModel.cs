namespace Beekeeping.Models.Income
{
    using System.ComponentModel.DataAnnotations;

    public class IncomeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Вид приход")]
        public string TypeOfIncome { get; set; } = null!;

        [Display(Name = "Дата на прихода")]
        public string DayOfTheIncome { get; set; } = null!;

        [Display(Name = "Стойност на прихода")]
        public decimal IncomeValue { get; set; }

        public string CreatorId { get; set; } = null!;

    }
}