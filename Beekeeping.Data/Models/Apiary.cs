namespace Beekeeping.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Beekeeping.Common.Validations.DataConstants.ApiaryValidations;

    public class Apiary
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ApiaryNameMaxLenght)]
        public string Name { get; set; } = null!;

        [StringLength(LocationMaxLenght)]
        public string? Location { get; set; }

        [StringLength(RegistrationMaxLenght)]
        public string? RegistrationNumber { get; set; }


        public int NumberOfHives { get; set; }

        [Required]
        public string OwnerId { get; set; } = null!;

        public ICollection<BeeColony> BeeHives { get; set; } = new HashSet<BeeColony>();
    }
}
