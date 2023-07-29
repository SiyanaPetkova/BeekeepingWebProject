namespace Beekeeping.Models.HiveFeeding
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class HiveFeedingViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Тип хранене")]
        public string FeedingType { get; set; } = null!;

        [Display(Name = "Дата на храненето")]
        [DataType(DataType.Date)]
        public DateTime DayOfFeeding { get; set; }

        [Display(Name = "Общо семейства")]
        public int NumberOfBeeHives { get; set; }

        [Display(Name = "Стойност на храненето")]
        public decimal PriceOfFeeding { get; set; }

        public string CreatorId { get; set; } = null!;
    }
}