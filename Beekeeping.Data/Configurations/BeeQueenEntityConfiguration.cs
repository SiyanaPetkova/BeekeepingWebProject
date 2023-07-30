namespace Beekeeping.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    using Data.Models;

    public class BeeQueenEntityConfiguration : IEntityTypeConfiguration<BeeQueen>
    {
        public void Configure(EntityTypeBuilder<BeeQueen> builder)
        {
            builder.HasData(GenerateBeeQueens());
        }

        private static BeeQueen[] GenerateBeeQueens()
        {
            ICollection<BeeQueen> beeQueens = new HashSet<BeeQueen>();

            BeeQueen beeQueen;

            beeQueen = new BeeQueen()
            {
                Id = 10001,
                Breeder = "Собствено производство",
                BeeQueenYearOfBirth = 2023,
                BeeQueenType = "Карника"
            };

            beeQueens.Add(beeQueen);

            beeQueen = new BeeQueen()
            {
                Id = 10002,
                Breeder = "Собствено производство",
                BeeQueenYearOfBirth = 2023,
                BeeQueenType = "Карника"
            };

            beeQueens.Add(beeQueen);

            beeQueen = new BeeQueen()
            {
                Id = 10003,
                Breeder = "Роева",
                BeeQueenYearOfBirth = 2023,
                BeeQueenType = "Неизвестна"
            };

            beeQueens.Add(beeQueen);

            beeQueen = new BeeQueen()
            {
                Id = 10004,
                Breeder = "Собствено производство",
                BeeQueenYearOfBirth = 2023,
                BeeQueenType = "Карника"
            };

            beeQueens.Add(beeQueen);

            beeQueen = new BeeQueen()
            {
                Id = 10005,
                Breeder = "Собствено производство",
                BeeQueenYearOfBirth = 2023,
                BeeQueenType = "БМП"
            };

                        beeQueens.Add(beeQueen);

            beeQueen = new BeeQueen()
            {
                Id = 10006,
                Breeder = "Собствено производство",
                BeeQueenYearOfBirth = 2022,
                BeeQueenType = "БМП"
            };

            beeQueens.Add(beeQueen);

            beeQueen = new BeeQueen()
            {
                Id = 10007,
                Breeder = "Собствено производство",
                BeeQueenYearOfBirth = 2023,
                BeeQueenType = "Карника"
            };

            beeQueens.Add(beeQueen);

            beeQueen = new BeeQueen()
            {
                Id = 10008,
                Breeder = "Роева",
                BeeQueenYearOfBirth = 2023,
                BeeQueenType = "Неизвестна"
            };

            beeQueens.Add(beeQueen);

            beeQueen = new BeeQueen()
            {
                Id = 10009,
                Breeder = "Собствено производство",
                BeeQueenYearOfBirth = 2022,
                BeeQueenType = "Карника"
            };

            beeQueens.Add(beeQueen);

            return beeQueens.ToArray();
        }
    }
}