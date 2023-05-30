namespace BeekeepingWebProject.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class HiveTreatment
    {
        public HiveTreatment()
        {
            BeeHives = new HashSet<BeeHive>();
        }

        [Key, Required]
        public int Id { get; set; }

        [Required, MaxLength(MedicationNameMaxLenght)]
        public string MedicationName { get; set; } = null!;

        [Required, MaxLength(ActiveIngredientMaxLenght)]
        public string ActiveIngredient { get; set; } = null!;

        public DateTime TreatmentDate { get; set; }

        public ICollection<BeeHive> BeeHives { get; set; }

    }
}
