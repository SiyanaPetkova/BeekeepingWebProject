namespace Beekeeping.Models.BeeColony
{
    using Beekeeping.Models.BeeQueen;

    public class BeeColonyViewModel
    {
        public int Id { get; set; }

        public string? PlateNumber { get; set; }

        public string? AdditionalComмent { get; set; }

        public string? TypeOfBroodBox { get; set; }

        public string Super { get; set; } = null!;

        public int? NumberOfSupers { get; set; }

        public string SecondBroodBox { get; set; } = null!;

        public int? NumberOfAdditionalBoxes { get; set; } 

        public string MatedBeeQueen { get; set; } = null!;

        public int ApiaryId { get; set; }

        public string Apiary { get; set; } 

        public int BeeQueenId { get; set; }

        public BeeQueenSelectViewModel BeeQueen { get; set; }
    }
}