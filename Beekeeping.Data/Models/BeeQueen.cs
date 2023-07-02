namespace Beekeeping.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Beekeeping.Common.Validations.DataConstants.BeeQueenValidations;

    public class BeeQueen
    {
        [Key, Required]
        public int Id { get; set; }

        [StringLength(BreederMaxLenght)]
        public string? Breeder { get; set; }

        public int? BeeQueenType { get; set; }

        public int BeeQueenYearOfBirth { get; set; }

        [ForeignKey(nameof(BeeColony))]
        public int BeeColonyId { get; set; }
        public BeeColony? BeeColony { get; set; }
    }
}
