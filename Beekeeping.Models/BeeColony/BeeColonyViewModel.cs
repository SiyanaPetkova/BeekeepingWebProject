namespace Beekeeping.Models.BeeHive
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using Beekeeping.Models.Apiary;
    using Beekeeping.Models.BeeQueen;

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

        public string OwnerOfTheApiary { get; set; }

        public int ApiaryId { get; set; }

        public IEnumerable<AllApiariesForSelectModel> Apiaries { get; set; } = new HashSet<AllApiariesForSelectModel>();

        public int BeeQueenId { get; set; }

        public IEnumerable<BeeQueenSelectViewModel> Queens { get; set; } = new HashSet<BeeQueenSelectViewModel>();
    }
}