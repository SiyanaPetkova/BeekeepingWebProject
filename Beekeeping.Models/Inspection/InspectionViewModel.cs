namespace Beekeeping.Models.Inspection
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class InspectionViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Дата на прегледа")]
        [DataType(DataType.Date)]
        public DateTime DayOfInspection { get; set; }

        [Display(Name = "Допълнителна информация")]

        public string? Description { get; set; }

        [Display(Name = "Рамки")]
        public int NumberOfFrames { get; set; }

        [Display(Name = "Рамки с пило")]
        public int? NumberOfBroodFrames { get; set; }

        [Display(Name = "Сила")]
        public int Strenght { get; set; }

        [Display(Name = "Темперамент")]
        public int Temperament { get; set; }

        public int BeeColonyId { get; set; }
    }
}