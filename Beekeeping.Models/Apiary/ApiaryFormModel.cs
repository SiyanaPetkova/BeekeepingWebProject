namespace Beekeeping.Models.Apiary
{
    using System.ComponentModel.DataAnnotations;

    using static Beekeeping.Common.Validations.DataConstants.ApiaryValidations;

    public class ApiaryFormModel
    {
        [Required]
        [StringLength(ApiaryNameMaxLenght,
                      MinimumLength = ApiaryNameMinLenght,
                      ErrorMessage = "Името трябва да съдържа между {2} и {1} символа")]
        [Display(Name = "Наименование")]
        public string Name { get; set; } = null!;

        [StringLength(LocationMaxLenght,
                      MinimumLength = LocationMinLenght,
                      ErrorMessage = "Адресът трябва да съдържа между {2} и {1} символа")]
        [Display(Name = "Адрес")]
        public string? Location { get; set; }

        [StringLength(RegistrationMaxLenght,
                      MinimumLength = RegistrationMinLenght,
                      ErrorMessage = "Регистрационният номер трябва да съдържа между {2} и {1} символа")]
        [Display(Name = "Регистрационен номер")]
        public string? RegistrationNumber { get; set; }

    }
}