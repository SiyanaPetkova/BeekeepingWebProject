namespace Beekeeping.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Data.Models;

    public class ApiaryEntityConfiguration : IEntityTypeConfiguration<Apiary>
    {
        public void Configure(EntityTypeBuilder<Apiary> builder)
        {
            builder.HasData(GenerateApiaries());
        }

        private static Apiary[] GenerateApiaries()
        {

            ICollection<Apiary> apiaries = new HashSet<Apiary>();

            Apiary apiary;

            apiary = new Apiary()
            {
                Id = 9150,
                Name = "Климентово",
                Location = "Село Климентово, Варна",
                OwnerId = "44C36B39-AD0A-4260-B448-45BB03158888",
                RegistrationNumber = "9150-0015",
                Latitude = 43.346222,
                Longitude = 27.946315
            };

            apiaries.Add(apiary);

            apiary = new Apiary()
            {
                Id = 9156,
                Name = "Зорница",
                Location = "Село Зорница, Варна",
                OwnerId = "44C36B39-AD0A-4260-B448-45BB03158888",
                RegistrationNumber = "9156-0017",
                Latitude = 43.330429,                
                Longitude = 27.734944
            };

            apiaries.Add(apiary);

            return apiaries.ToArray();

        }
    }
}