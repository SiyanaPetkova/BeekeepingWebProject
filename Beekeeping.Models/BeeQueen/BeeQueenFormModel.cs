namespace Beekeeping.Models.BeeQueen
{
    using System.ComponentModel.DataAnnotations;

    using static Beekeeping.Common.Validations.DataConstants.BeeQueenValidations;

    public class BeeQueenFormModel
    {
        [StringLength(BreederMaxLenght,
                      MinimumLength = BreederMinLenght,
                      ErrorMessage = "Името на майкопроизводителя трябва да бъде между {2} и {1} символа.")]
        [Display(Name = "Майкопроизводител")]
        public string? Breeder { get; set; }

        [StringLength(BreederMaxLenght,
                     MinimumLength = BreederMinLenght,
                     ErrorMessage = "Породата на майката трябва да бъде между {2} и {1} символа.")]
        [Display(Name = "Порода на майката")]
        public string? BeeQueenType { get; set; }

        [Display(Name = "Година на излюпване")]
        public int BeeQueenYearOfBirth { get; set; }

        public int BeeColonyId { get; set; }
    }
}