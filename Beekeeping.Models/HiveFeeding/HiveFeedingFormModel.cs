namespace Beekeeping.Models.HiveFeeding
{
    using System.ComponentModel.DataAnnotations;


    using static Beekeeping.Common.Validations.DataConstants.FeedingValidations;

    public class HiveFeedingFormModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(FeedintTypeMaxLenght, MinimumLength = FeedintTypeMinLenght)]
        public string FeedingType { get; set; } = null!;

        [Required]
        public DateTime DayOfFeeding { get; set; }

        [Required]
        public int NumberOfBeeHives { get; set; }

        [Required]
        public decimal PriceOfFeeding { get; set; }

    }
}