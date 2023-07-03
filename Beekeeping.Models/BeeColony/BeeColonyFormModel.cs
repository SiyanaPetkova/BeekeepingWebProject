namespace Beekeeping.Models.BeeColony
{
    using Beekeeping.Models.Apiary;
    using Beekeeping.Models.BeeQueen;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Beekeeping.Common.Validations.DataConstants.BeeColonyValidations;

    public class BeeColonyFormModel
    {
        public int Id { get; set; }

        [StringLength(PlateNumberMaxLenght)]
        public string? PlateNumber { get; set; }

        public string? AdditionalComment { get; set; }

        public string? TypeOfBroodBox { get; set; }

        public bool Super { get; set; }

        public int? NumberOfSupers { get; set; }

        public bool SecondBroodBox { get; set; }

        public int? NumberOfAdditionalBoxes { get; set; }

        public bool MatedBeeQueen { get; set; }

        [Required]
        public string OwnerOfTheApiary { get; set; } = null!;

        public int ApiaryId { get; set; }
        public IEnumerable<AllApiariesForSelectModel> Apiaries { get; set; } = new HashSet<AllApiariesForSelectModel>();

        public int BeeQueenId { get; set; }
        public BeeQueenFormModel? BeeQueen { get; set; }

    }
}