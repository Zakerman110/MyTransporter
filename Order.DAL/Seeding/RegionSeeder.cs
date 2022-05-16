using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.DAL.Entities;
using Order.DAL.Interfaces;

namespace Order.DAL.Seeding
{
    public class RegionSeeder : ISeeder<Region>
    {
        private static readonly List<Region> Regions = new()
        {
            new Region
            {
                Id = 1,
                Name = "Chernivtsi Oblast",
                CountryId = 1
            },
            new Region
            {
                Id = 2,
                Name = "Lviv Oblast",
                CountryId = 1
            },
            new Region
            {
                Id = 3,
                Name = "Kyiv Oblast",
                CountryId = 1
            },
            new Region
            {
                Id = 4,
                Name = "Mazowieckie",
                CountryId = 2
            },
            new Region
            {
                Id = 5,
                Name = "Malopolskie",
                CountryId = 2
            },
            new Region
            {
                Id = 6,
                Name = "Berlin",
                CountryId = 3
            },
            new Region
            {
                Id = 7,
                Name = "Hessen",
                CountryId = 3
            },
            new Region
            {
                Id = 8,
                Name = "Île-de-France",
                CountryId = 4
            },
            new Region
            {
                Id = 9,
                Name = "Provence-Alpes-Cote d'Azur",
                CountryId = 4
            },
            new Region
            {
                Id = 10,
                Name = "Suceava",
                CountryId = 5
            },
            new Region
            {
                Id = 11,
                Name = "Bucuresti",
                CountryId = 5
            }
        };

        public void Seed(EntityTypeBuilder<Region> builder) => builder.HasData(Regions);
    }
}
