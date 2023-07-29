namespace Beekeeping.Models.Inspection
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Common.Validations.DataConstants.InspectionValidations;
    using static Common.NotificationMessages.ErrorMessages;

    public class InspectionFormModel
    {
        public int Id { get; set; }

        [Display(Name = "Дата на прегледа")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        public DateTime DayOfInspection { get; set; }

        [Display(Name = "Допълнителна информация за прегледа")]
        [StringLength(InspectionDescriptionMaxLenght,
                      MinimumLength = InspectionDescriptionMinLenght,
                      ErrorMessage = FieldMinAndMaxStringLenghtErrorMessage)]
        public string? Description { get; set; }

        [Display(Name = "Рамки, които покриват пчелите")]
        [Range(NumberOfFramesMinLenght, 
               NumberOfFramesMaxLenght,
               ErrorMessage = FieldMinAndMaxRangeValueErrorMessage)]
        public int NumberOfFrames { get; set; }

        [Display(Name = "Рамки с пило")]
        [Range(NumberOfBroodFramesMinLenght,  
               NumberOfBroodFramesMaxLenght,   
               ErrorMessage = FieldMinAndMaxRangeValueErrorMessage)]
        public int? NumberOfBroodFrames { get; set; }

        [Display(Name = "Сила на семейството от 1 до 10")]
        [Range(StrenghtMinLenght, 
               StrenghtMaxLenght, 
               ErrorMessage = FieldMinAndMaxRangeValueErrorMessage)]
        public int Strenght { get; set; }

        [Display(Name = "Темперамент на семейството от 1 до 10(от спокойни към агресивни)")]
        [Range(TemperamentMinLenght, 
               TemperamentMaxLenght, 
               ErrorMessage = FieldMinAndMaxRangeValueErrorMessage)]
        public int Temperament { get; set; }
              
        public int BeeColonyId { get; set; }
    }
}