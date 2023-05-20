namespace BeekeepingWebProject.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    
    public class BeeHive
    {
        public BeeHive()
        {
            BeeQueens = new HashSet<BeeQueen>();
        }
        public int Id { get; set; }

        public int PlateNumber { get; set; }

        public int NumberOfFrames { get; set; }

        public int NumberOfBroodFrames { get; set; }

        public string AdditionalComмent { get; set; } = null!;

        [ForeignKey(nameof(Apiary))]
        public int ApiaryId { get; set; }
        public Apiary Apiary { get; set; } = null!;

        [ForeignKey(nameof(Treatment))]
        public int TreatmentId { get; set; }
        public HiveTreatment? Treatment { get; set; }

        public ICollection<BeeQueen> BeeQueens { get; set; }
    }
}
