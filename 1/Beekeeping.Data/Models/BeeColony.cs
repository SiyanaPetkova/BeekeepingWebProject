namespace Beekeeping.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    using static Beekeeping.Data.Common.DataConstants.BeeHiveValidations;

    public class BeeColony
    {

        public int Id { get; set; }

        [StringLength(PlateNumberMaxLenght)]
        public string? PlateNumber { get; set; }

        public int NumberOfFrames { get; set; }

        public int? NumberOfBroodFrames { get; set; }

        public string? AdditionalComмent { get; set; }

        public string? TypeOfBroodBox { get; set; }

        public int Strenght { get; set; }

        public int Temperament { get; set; }

        public bool Super { get; set; }

        public int? NumberOfSupers { get; set; }

        public bool SecondBroodBox { get; set; }

        public int? NumberOfAdditionalBoxes { get; set; }

        public bool MatedBeeQueen { get; set; }

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
    }
}
