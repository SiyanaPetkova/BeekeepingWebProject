namespace Beekeeping.Models.HiveFeeding
{
    using System.ComponentModel.DataAnnotations;

    using static Beekeeping.Common.Validations.DataConstants.FeedingValidations;

    public class HiveFeedingFormModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(FeedingTypeMaxLenght, 
                      MinimumLength = FeedingTypeMinLenght, 
                      ErrorMessage = "Полето трябва да съдържа между {1} и {2} символа")]
        [Display(Name = "Тип хранене")]
        public string FeedingType { get; set; } = null!;

        [Required]
        [Display(Name = "Дата на храненето")]
        public DateTime DayOfFeeding { get; set; }

        [Required]
        [Display(Name = "Общо семейства")]
        [Range(NumberOfFedColoniesMinValue, 
               NumberOfFedColoniesMaxValue, 
               ErrorMessage = "Броят на подхранените кошери трябва да бъде между {1} и {2}")]
        public int NumberOfBeeHives { get; set; }

        [Required]
        [Display(Name = "Стойност на храненето")]
        [Range(FeedingPriceMinValue, 
               FeedingPriceMaxValue,
               ErrorMessage = "Стойността на храненето трябва да бъде между {1} и {2}")]
        public decimal PriceOfFeeding { get; set; }

    }
}