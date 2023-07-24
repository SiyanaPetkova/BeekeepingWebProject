namespace Beekeeping.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Beekeeping.Common.Validations.DataConstants.FeedingValidations;

    public class HiveFeeding
    {
        public int Id { get; set; }

        [Required]
        [StringLength(FeedingTypeMaxLenght)]
        public string FeedingType { get; set; } = null!;

        [Required]
        public DateTime DayOfFeeding { get; set; }

        [Required] 
        public int NumberOfBeeHives { get; set; }

        [Required]
        public decimal PriceOfFeeding { get; set; }

        [Required]
        public string CreatorId { get; set; } = null!;

    }
}