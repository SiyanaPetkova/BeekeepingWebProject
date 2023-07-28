namespace Beekeeping.Models.BeeColony
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Models.Apiary;
    using Models.BeeQueen;

    using static Common.Validations.DataConstants.BeeColonyValidations;
    using static Common.NotificationMessages.ErrorMessages;

    public class BeeColonyFormModel
    {
        public int Id { get; set; }

        [Display(Name = "Регистрационен номер на кошера")]
        [Required(ErrorMessage = "Полето e задължително.")]
        [StringLength(PlateNumberMaxLenght,
                      MinimumLength = PlateNumberMinLenght,
                      ErrorMessage = FieldMinAndMaxStringLenghtErrorMessage)]
        public string? PlateNumber { get; set; }

        [Display(Name = "Допълнителна информация за кошера")]
        public string? AdditionalComment { get; set; }

        [Display(Name = "Система на кошера")]
        public string? TypeOfBroodBox { get; set; }

        [Display(Name = "Има ли поставени магазини")]
        public bool Super { get; set; }

        [Display(Name = "Брой магазини")]
        [Range(NumberOfSupersMinValue, 
               NumberOfSupersMaxValue, 
               ErrorMessage = FieldMinAndMaxRangeValueErrorMessage)]
        public int? NumberOfSupers { get; set; }

        [Display(Name = "Има ли втори плодник")]
        public bool SecondBroodBox { get; set; }

        [Display(Name = "Брой допълнителни корпуси")]
        [Range(NumberOfBoxesMinValue, 
               NumberOfBoxesMaxValue, 
               ErrorMessage = FieldMinAndMaxRangeValueErrorMessage)]
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