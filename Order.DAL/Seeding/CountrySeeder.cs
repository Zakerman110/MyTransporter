using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.DAL.Entities;
using Order.DAL.Interfaces;

namespace Order.DAL.Seeding
{
    public class CountrySeeder : ISeeder<Country>
    {
        private static readonly List<Country> Countries = new()
        {
            new Country
            {
                Id = 1,
                Name = "Ukraine"
            },
            new Country
            {
                Id = 2,
                Name = "Poland"
            },
            new Country
            {
                Id = 3,
                Name = "Germany"
            },
            new Country
            {
                Id = 4,
                Name = "France"
            },
            new Country
            {
                Id = 5,
                Name = "Romania"
            }
        };

        public void Seed(EntityTypeBuilder<Country> builder) => builder.HasData(Countries);
    }
}
