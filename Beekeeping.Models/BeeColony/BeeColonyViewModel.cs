namespace Beekeeping.Models.BeeHive
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class BeeColonyViewModel
    {
        public int Id { get; set; }

        public string? PlateNumber { get; set; }

        public string? AdditionalComмent { get; set; }

        public string? TypeOfBroodBox { get; set; }

        public bool Super { get; set; }

        public int? NumberOfSupers { get; set; }

        public bool SecondBroodBox { get; set; }

        public int? NumberOfAdditionalBoxes { get; set; }

        public bool MatedBeeQueen { get; set; }

        public string OwnerOfTheApiary { get; set; } = null!;

        public int ApiaryId { get; set; }

        public int TreatmentId { get; set; }

        public int FeedingId { get; set; }


    }
}