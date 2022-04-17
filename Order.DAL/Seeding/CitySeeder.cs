using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.DAL.Entities;
using Order.DAL.Interfaces;

namespace Order.DAL.Seeding
{
    public class CitySeeder : ISeeder<City>
    {
        private static readonly List<City> Cities = new()
        {
            new City
            {
                Id = 1,
                Name = "Chernivtsi",
                RegionId = 1
            },
            new City
            {
                Id = 2,
                Name = "Novoselitsa",
                RegionId = 1
            },
            new City
            {
                Id = 3,
                Name = "Lviv",
                RegionId = 2
            },
            new City
            {
                Id = 4,
                Name = "Truskavets",
                RegionId = 2
            },
            new City
            {
                Id = 5,
                Name = "Kyiv",
                RegionId = 3
            },
            new City
            {
                Id = 6,
                Name = "Borispol",
                RegionId = 3
            },
            new City
            {
                Id = 7,
                Name = "Bila Tserkva",
                RegionId = 3
            },
            new City
            {
                Id = 8,
                Name = "Warsaw",
                RegionId = 4
            },
            new City
            {
                Id = 9,
                Name = "Radom",
                RegionId = 4
            },
            new City
            {
                Id = 10,
                Name = "Krakow",
                RegionId = 5
            },
            new City
            {
                Id = 11,
                Name = "Tarnow",
                RegionId = 5
            },
            new City
            {
                Id = 12,
                Name = "Berlin",
                RegionId = 6
            },
            new City
            {
                Id = 13,
                Name = "Wiesbaden",
                RegionId = 7
            },
            new City
            {
                Id = 14,
                Name = "Frankfurt",
                RegionId = 7
            },
            new City
            {
                Id = 15,
                Name = "Paris",
                RegionId = 8
            },
            new City
            {
                Id = 16,
                Name = "Marseille",
                RegionId = 9
            },
            new City
            {
                Id = 17,
                Name = "Siret",
                RegionId = 10
            },
            new City
            {
                Id = 18,
                Name = "Suceava",
                RegionId = 10
            },
            new City
            {
                Id = 19,
                Name = "Bucuresti",
                RegionId = 11
            }
        };

        public void Seed(EntityTypeBuilder<City> builder) => builder.HasData(Cities);
    }
}
