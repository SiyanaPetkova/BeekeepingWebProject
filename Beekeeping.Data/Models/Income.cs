namespace Beekeeping.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Beekeeping.Common.Validations.DataConstants.IncomeValidations;

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