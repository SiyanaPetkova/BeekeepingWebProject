namespace Beekeeping.Models.Apiary
{
    using System.ComponentModel.DataAnnotations;

    public class AllApiariesForSelectModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}