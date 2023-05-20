﻿namespace BeekeepingWebProject.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class Apiary
    {
        public Apiary()
        {
            BeeHives = new HashSet<BeeHive>();   
        }
        public int Id { get; set; }

        [MaxLength(ApiaryNameMaxLenght)]
        public string Name { get; set; } = null!;

        [MaxLength(LocationMaxLenght)]
        public string? Location { get; set; }

        public int NumberOfHives { get; set; }

        public ICollection<BeeHive> BeeHives { get; set; }
    }
}
