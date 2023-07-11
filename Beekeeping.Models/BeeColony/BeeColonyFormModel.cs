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

        [StringLength(PlateNumberMaxLenght,
            MinimumLength = PlateNumberMinLenght,
            ErrorMessage = "Номерът на кошера трябва да съдържа между {2} и {1} символа")]
        [Display(Name = "Регистрационен номер на кошера")]
        public string? PlateNumber { get; set; }

        [Display(Name = "Допълбителна информация за кошера")]
        public string? AdditionalComment { get; set; }

        [Display(Name = "Система на кошера")]
        public string? TypeOfBroodBox { get; set; }

        [Display(Name = "Има ли поставени магазини")]
        public bool Super { get; set; }

        [Display(Name = "Брой магазини")]
        public int? NumberOfSupers { get; set; }

        [Display(Name = "Има ли втори плодник")]
        public bool SecondBroodBox { get; set; }

        [Display(Name = "Брой допълнителни корпуси")]
        public int? NumberOfAdditionalBoxes { get; set; }

        [Display(Name = "Има ли оплодена майка")]
        public bool MatedBeeQueen { get; set; }

        public string? OwnerOfTheApiary { get; set; }

        [Display(Name = "Пчелин")]
        public int ApiaryId { get; set; }
        public IEnumerable<AllApiariesForSelectModel> Apiaries { get; set; } = new HashSet<AllApiariesForSelectModel>();

        public int BeeQueenId { get; set; }
        public BeeQueenFormModel? BeeQueen { get; set; }

    }
}