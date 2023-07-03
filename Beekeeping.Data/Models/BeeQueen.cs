namespace Beekeeping.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Beekeeping.Common.Validations.DataConstants.BeeQueenValidations;

    public class BeeQueen
    {
        [Required]
        public int Id { get; set; }

        [StringLength(BreederMaxLenght)]
        public string? Breeder { get; set; }

        [StringLength(BeeQueenTypeMaxLenght)]
        public string? BeeQueenType { get; set; }

        public int BeeQueenYearOfBirth { get; set; }

        public BeeColony? BeeColony { get; set; }
    }
}
