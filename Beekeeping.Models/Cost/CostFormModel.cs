namespace Beekeeping.Models.Cost
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Beekeeping.Common.Validations.DataConstants.CostValidations;

    public class CostFormModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(CostTypeMaxLenght, 
                      MinimumLength = CostTypeMinLenght, 
                      ErrorMessage = "Полето трябва да съдържа между {1} и {2] символа")]
        [Display(Name = "Тип на разхода")]
        public string TypeOfCost { get; set; } = null!;

        [Required]
        [Display(Name = "Дата на разхода")]
        public DateTime DayOfTheCost { get; set; }

        [Required]
        [Display(Name = "Стойност на разхода")]
        public decimal CostValue { get; set; }
    }
}