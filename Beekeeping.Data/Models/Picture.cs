namespace Beekeeping.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Beekeeping.Common.Validations.DataConstants.GalleryValidations;

    public class Picture
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(PictureNameMaxLenght)]
        public string PictureName { get; set; } = null!;

        [Required]
        [StringLength(PicturePathMaxLenght)]
        public string PicturePath { get; set; } = null!;
    }
}
