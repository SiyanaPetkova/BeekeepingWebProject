namespace Beekeeping.Models.Cost
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CostViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Тип на разхода")]
        public string TypeOfCost { get; set; } = null!;

        [Display(Name = "Дата на разхода")]
        public DateTime DayOfTheCost { get; set; }

        [Display(Name = "Стойност на разхода")]
        public decimal CostValue { get; set; }

        public string CreatorId { get; set; } = null!;
    }
}