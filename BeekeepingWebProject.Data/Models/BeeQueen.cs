namespace BeekeepingWebProject.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class BeeQueen
    {
        [Key, Required]
        public int Id { get; set; }

        public string? Breeder { get; set; }

        public int? BeeQueenType { get; set; }

        public int BeeQueenYearOfBirth { get; set; }

        [ForeignKey(nameof(BeeHive))]
        public int BeeHiveId { get; set; }
        public BeeHive? BeeHive { get; set; }
    }
}
