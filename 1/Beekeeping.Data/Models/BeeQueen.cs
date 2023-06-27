namespace Beekeeping.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Beekeeping.Data.Common.DataConstants.BeeQueenValidations;

    public class BeeQueen
    {
        [Key, Required]
        public int Id { get; set; }

        [StringLength(BreederMaxLenght)]
        public string? Breeder { get; set; }

        public int? BeeQueenType { get; set; }

        public int BeeQueenYearOfBirth { get; set; }

        [ForeignKey(nameof(BeeHive))]
        public int BeeHiveId { get; set; }
        public BeeColony? BeeHive { get; set; }
    }
}
