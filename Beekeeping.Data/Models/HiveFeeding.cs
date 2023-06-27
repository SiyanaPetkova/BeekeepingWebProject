namespace Beekeeping.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Beekeeping.Data.Common.DataConstants.FeedingValidations;

    public class HiveFeeding
    {
        public int Id { get; set; }

        [Required]
        [StringLength(FeedintTypeMaxLenght)]
        public string FeedingType { get; set; } = null!;

        [Required]
        public decimal PriceOfFeeding { get; set; }

        public ICollection<BeeColony> BeeHives { get; set; } = new HashSet<BeeColony>();
    }
}