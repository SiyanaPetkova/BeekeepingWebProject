namespace Beekeeping.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Globalization;

    using Data.Models;

    public class NoteToDoEntityConfiguration : IEntityTypeConfiguration<NoteToDo>
    {
        public void Configure(EntityTypeBuilder<NoteToDo> builder)
        {
            builder.HasData(GenerateNotesToDo());
        }

        private static NoteToDo[] GenerateNotesToDo()
        {
            ICollection<NoteToDo> notes = new HashSet<NoteToDo>();

            NoteToDo note;

            note = new NoteToDo()
            {
                Id = 20001,
                DateToBeDone = DateTime.Parse("07.22.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                Description = "Третиране против акар",
                CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888",
                Finished = false,
            };

            notes.Add(note);

            note = new NoteToDo()
            {
                Id = 20002,
                DateToBeDone = DateTime.Parse("03.15.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                Description = "Пролетно подхранване",
                CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888",
                Finished = true,
            };

            notes.Add(note);

            note = new NoteToDo()
            {
                Id = 20003,
                DateToBeDone = DateTime.Parse("06.30.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                Description = "Поставяне на магазини",
                CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888",
                Finished = true,
            };

            notes.Add(note);

            note = new NoteToDo()
            {
                Id = 20004,
                DateToBeDone = DateTime.Parse("10.22.2023", CultureInfo.InvariantCulture, DateTimeStyles.None),
                Description = "Третиране против нозематоза",
                CreatorId = "44C36B39-AD0A-4260-B448-45BB03158888",
                Finished = false,
            };

            notes.Add(note);

            return notes.ToArray();
        }
    }
}