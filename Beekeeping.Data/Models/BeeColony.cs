namespace Beekeeping.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    using static Beekeeping.Common.Validations.DataConstants.BeeHiveValidations;

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

        [ForeignKey(nameof(Treatment))]
        public int TreatmentId { get; set; }
        public HiveTreatment? Treatment { get; set; }

        [ForeignKey(nameof(HiveFeeding))]
        public int FeedingId { get; set; }
        public HiveFeeding? HiveFeeding { get; set; }

        public ICollection<BeeQueen> BeeQueens { get; set; } = new HashSet<BeeQueen>();

        public ICollection<Inspection> Inspections { get; set; } = new HashSet<Inspection>();
    }
}
