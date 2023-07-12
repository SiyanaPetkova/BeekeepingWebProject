namespace Beekeeping.Models.Inspection
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Beekeeping.Common.Validations.DataConstants.InspectionValidations;

    public class InspectionFormModel
    {
        public int Id { get; set; }

        public DateTime DayOfInspection { get; set; }

        [StringLength(InspectionMaxLenght,
                      MinimumLength = InspectionMinLenght,
                      ErrorMessage = "Описанието трябва да бъде между {2} и {1} символа")]
        public string? Description { get; set; }

        [Range(1, 30, ErrorMessage = "Броят рамки в семейството трябва да бъде цяло число между {1} и {2}")]
        public int NumberOfFrames { get; set; }

        [Range(0, 20, ErrorMessage = "Рамките с пило трябва да бъдат цяло число между {1} и {2}")]
        public int? NumberOfBroodFrames { get; set; }

        [Range(1, 10, ErrorMessage = "Силата на семейството трябва да бъде цяло число между {1} и {2}")]
        public int Strenght { get; set; }

        [Range(1, 10, ErrorMessage = "Темпераментът на семейството трябва да бъде цяло число между {1} и {2}")]
        public int Temperament { get; set; }

        [Range(2010, 2030, ErrorMessage = "Годината на майката трябва да бъде цяло число между {1} и {2}")]
        public int BeeQueenYearOfBirth { get; set; }

        public int BeeColonyId { get; set; }
    }
}