namespace Beekeeping.Models.Inspection
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Beekeeping.Common.Validations.DataConstants.InspectionValidations;

    public class InspectionFormModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Полето e задължително.")]
        [Display(Name = "Дата на прегледа")]
        public DateTime DayOfInspection { get; set; }

        [Display(Name = "Допълнителна информация за прегледа")]
        [StringLength(InspectionMaxLenght,
                      MinimumLength = InspectionMinLenght,
                      ErrorMessage = "Описанието трябва да бъде между {2} и {1} символа")]
        public string? Description { get; set; }

        [Display(Name = "Рамки, които покриват пчелите")]
        [Range(1, 30, ErrorMessage = "Броят рамки в семейството трябва да бъде цяло число между {1} и {2}")]
        public int NumberOfFrames { get; set; }

        [Display(Name = "Рамки с пило")]
        [Range(0, 20, ErrorMessage = "Рамките с пило трябва да бъдат цяло число между {1} и {2}")]
        public int? NumberOfBroodFrames { get; set; }

        [Display(Name = "Сила на семейството от 1 до 10")]
        [Range(1, 10, ErrorMessage = "Силата на семейството трябва да бъде цяло число между {1} и {2}")]
        public int Strenght { get; set; }

        [Display(Name = "Темперамент на семейството от 1 до 10(от спокойни към агресивни)")]
        [Range(1, 10, ErrorMessage = "Темпераментът на семейството трябва да бъде цяло число между {1} и {2}")]
        public int Temperament { get; set; }
              
        public int BeeColonyId { get; set; }
    }
}