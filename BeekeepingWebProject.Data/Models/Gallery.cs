namespace BeekeepingWebProject.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Gallery
    {
        [Key, Required]
        public int Id { get; set; }
        public string PictureName { get; set; } = null!;
        public string PicturePath { get; set; } = null!;
    }
}
