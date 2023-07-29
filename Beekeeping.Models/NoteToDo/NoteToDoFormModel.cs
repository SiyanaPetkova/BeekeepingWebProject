namespace Beekeeping.Models.NoteToDo
{
    using System.ComponentModel.DataAnnotations;

    using static Common.Validations.DataConstants.NoteToDoValidations;
    using static Common.NotificationMessages.ErrorMessages;

    public class NoteToDoFormModel
    {
        public int Id { get; set; }

        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateToBeDone { get; set; }
          
        [Display(Name = "Описание на задачата")]
        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [StringLength(NoteDescriptionMaxLenght,
                      MinimumLength = NoteDescriptionMinLenght,
                      ErrorMessage = FieldMinAndMaxStringLenghtErrorMessage)]
        public string Description { get; set; } = null!;

        [Display(Name = "Завършена")]
        [Required]
        public bool Finished { get; set; }

        public string? CreatorId { get; set; }

    }
}