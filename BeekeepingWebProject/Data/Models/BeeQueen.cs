using System.ComponentModel.DataAnnotations.Schema;

namespace BeekeepingWebProject.Data.Models
{

    public class BeeQueen
    {
        public int Id { get; set; }

        public string? Breeder { get; set; }

        public int? BeeQueenType { get; set; }

        public int BeeQueenYearOfBirth { get; set; }

        [ForeignKey(nameof(BeeHive))]
        public int BeeHiveId { get; set; }
        public BeeHive? BeeHive { get; set; }
    }
}
