namespace Beekeeping.Models.Apiary
{
    using System.ComponentModel.DataAnnotations;

    using static Beekeeping.Common.Validations.DataConstants.ApiaryValidations;

    public class ApiaryFormModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ApiaryNameMaxLenght, MinimumLength = ApiaryNameMinLenght, ErrorMessage = "Името трябва да съдържа между {1} и {2} символа")]
        public string Name { get; set; } = null!;

        [StringLength(LocationMaxLenght, MinimumLength = LocationMinLenght, ErrorMessage = "Местоположението трябва да съдържа между {1} и {2} символа")]
        public string? Location { get; set; }

        public int? NumberOfHives { get; set; }

        [Required]
        [StringLength(OwnerIdMaxLenght, MinimumLength = OwnerIdMinLenght)]
        public string OwnerId { get; set; } = null!;
    }
}