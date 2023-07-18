namespace Beekeeping.Models.Event
{
    using System;

    public class HiveFeedingViewModel
    {
        public int Id { get; set; }

        public string FeedingType { get; set; } = null!;

        public DateTime DayOfFeeding { get; set; }

        public int NumberOfBeeHives { get; set; }

        public decimal PriceOfFeeding { get; set; }

        public string CreatorId { get; set; } = null!;
    }
}