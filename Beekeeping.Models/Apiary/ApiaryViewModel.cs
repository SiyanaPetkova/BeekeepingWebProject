namespace Beekeeping.Models.Apiary
{
    using Beekeeping.Models.BeeHive;

    using System.Collections.Generic;

    public class ApiaryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Location { get; set; }

        public string? RegistrationNumber { get; set; }

        public int NumberOfHives { get; set; }
        public string OwnerId { get; set; }

    }
}