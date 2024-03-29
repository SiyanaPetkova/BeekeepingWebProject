﻿namespace Beekeeping.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Beekeeping.Common.Validations.DataConstants.CostValidations;

    public class Cost
    {
        public int Id { get; set; }

        [Required]
        [StringLength(CostTypeMaxLenght)]
        public string TypeOfCost { get; set; } = null!;

        [Required]
        public DateTime DayOfTheCost { get; set; } 

        [Required]
        public decimal CostValue { get; set; }

        [Required]
        public string CreatorId { get; set; } = null!;
    }
}