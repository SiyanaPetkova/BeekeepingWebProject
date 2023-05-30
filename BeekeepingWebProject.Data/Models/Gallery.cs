namespace BeekeepingWebProject.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Gallery
    {
        [Key, Required]
        public int Id { get; set; }

        [Required, MaxLength(PictureNameMaxLenght)]
        public string PictureName { get; set; } = null!;

        [Required, MaxLength(PicturePathMaxLenght)]
        public string PicturePath { get; set; } = null!;
    }
}
