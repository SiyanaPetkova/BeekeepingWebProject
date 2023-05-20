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
        public int Id { get; set; }

        [MaxLength(MedicationNameMaxLenght)]
        public string MedicationName { get; set; } = null!;

        [MaxLength(ActiveIngredientMaxLenght)]
        public string ActiveIngredient { get; set; } = null!;

        public DateTime TreatmentDate { get; set; }

        public ICollection<BeeHive> BeeHives { get; set; }

    }
}
