namespace Beekeeping.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Beekeeping.Data.Common.DataConstants.ApiaryValidations;

    public class Apiary
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ApiaryNameMaxLenght)]
        public string Name { get; set; } = null!;

        [StringLength(LocationMaxLenght)]
        public string? Location { get; set; }

        public int NumberOfHives { get; set; }

        public ICollection<BeeColony> BeeHives { get; set; } = new HashSet<BeeColony>();
    }
}
