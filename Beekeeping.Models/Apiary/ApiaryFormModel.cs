namespace Beekeeping.Models.Apiary
{
    using System.ComponentModel.DataAnnotations;

    using static Common.Validations.DataConstants.ApiaryValidations;
    using static Common.NotificationMessages.ErrorMessages;

    public class ApiaryFormModel
    {
        [Display(Name = "Наименование")]
        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [StringLength(ApiaryNameMaxLenght,
               MinimumLength = ApiaryNameMinLenght,
               ErrorMessage = FieldMinAndMaxStringLenghtErrorMessage)]
        public string Name { get; set; } = null!;

        [Display(Name = "Адрес")]
        [StringLength(LocationMaxLenght,
                      MinimumLength = LocationMinLenght,
                      ErrorMessage = FieldMinAndMaxStringLenghtErrorMessage)]
        public string? Location { get; set; }

        [Display(Name = "Регистрационен номер")]
        [StringLength(RegistrationMaxLenght,
                      MinimumLength = RegistrationMinLenght,
                      ErrorMessage = FieldMinAndMaxStringLenghtErrorMessage)]
        public string? RegistrationNumber { get; set; }

        [Display(Name = "φ")]
        public double Latitude { get; set; }

        [Display(Name = "λ")]
        public double Longitude { get; set; }

    }
}