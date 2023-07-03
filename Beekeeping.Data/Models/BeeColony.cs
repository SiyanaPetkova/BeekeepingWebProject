namespace Beekeeping.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    using static Beekeeping.Common.Validations.DataConstants.BeeColonyValidations;

    public class BeeColony
    {
        public int Id { get; set; }

        [StringLength(PlateNumberMaxLenght)]
        public string? PlateNumber { get; set; }

        public string? AdditionalComмent { get; set; }

        public string? TypeOfBroodBox { get; set; }

        public bool Super { get; set; }

        public int? NumberOfSupers { get; set; }

        public bool SecondBroodBox { get; set; }

        public int? NumberOfAdditionalBoxes { get; set; }

        public bool MatedBeeQueen { get; set; }

        [Required]
        public string OwnerOfTheApiary { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Apiary))]
        public int ApiaryId { get; set; }
        public Apiary Apiary { get; set; } = null!;

        [ForeignKey(nameof(BeeQueen))]
        public int BeeQueenId { get; set; }
        public BeeQueen? BeeQueen { get; set; }

        public ICollection<Inspection> Inspections { get; set; } = new HashSet<Inspection>();
    }
}
