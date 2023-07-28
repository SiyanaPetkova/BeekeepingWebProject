namespace Beekeeping.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class NoteToDo
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateToBeDone { get; set; }

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public bool Finished { get; set; } 

        [Required]
        public string CreatorId { get; set; } = null!;
    }
}