namespace Beekeeping.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Beekeeping.Data.Common.DataConstants.IncomeValidations;

    public class Income
    {
        public int Id { get; set; }

        [Required]
        [StringLength(IncomeTypeMaxLenght)]
        public string TypeOfIncome { get; set; } = null!;

        [Required]
        public decimal IncomeValue { get; set; }
    }
}