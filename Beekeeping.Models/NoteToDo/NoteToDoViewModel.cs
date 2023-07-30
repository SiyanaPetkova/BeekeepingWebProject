namespace Beekeeping.Models.NoteToDo
{
    using System.ComponentModel.DataAnnotations;

    public class NoteToDoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Дата")]
        public string DateToBeDone { get; set; } = null!;

        [Display(Name = "Описание на задачата")]
        public string Description { get; set; } = null!;

        [Display(Name = "Завършена")]
        public string Finished { get; set; } = null!;

        public string CreatorId { get; set; } = null!;
    }
}