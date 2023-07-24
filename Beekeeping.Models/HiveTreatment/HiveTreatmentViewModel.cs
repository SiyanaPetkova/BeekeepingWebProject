namespace Beekeeping.Models.HiveTreatment
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.InteropServices;

    public class HiveTreatmentViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Име на препарата")]
        public string MedicationName { get; set; } = null!;

        [Display(Name = "Активна съставка")]
        public string ActiveIngredient { get; set; } = null!;

        [Display(Name = "Резултати и коментари")]
        public string? ResultAndCommentAboutTheTreatment { get; set; }

        [Display(Name = "Обща стойност на третирането")]
        public decimal PriceOfTheTreatment { get; set; }


        [Display(Name = "Дата на третирането")]
        public DateTime TreatmentDate { get; set; }


        [Display(Name = "Брой третирани семейства")]
        public int NumberOfTreatedColonies { get; set; }

        public string CreatorId { get; set; } = null!;
    }
}