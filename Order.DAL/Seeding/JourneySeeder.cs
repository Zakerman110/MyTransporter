using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.DAL.Entities;
using Order.DAL.Interfaces;

namespace Order.DAL.Seeding
{
    public class JourneySeeder : ISeeder<Journey>
    {
        List<Journey> Journeys = new()
        {
            new Journey()
            {
                Id = 1,
                StartDate = new DateTime(2022, 03, 16, 5, 00, 00),
                EndDate = new DateTime(2022, 03, 16, 11, 00, 00)
            },
            new Journey()
            {
                Id = 2,
                StartDate = new DateTime(2022, 03, 17, 6, 00, 00),
                EndDate = new DateTime(2022, 03, 17, 14, 00, 00)
            },
            new Journey()
            {
                Id = 3,
                StartDate = new DateTime(2022, 03, 19, 4, 00, 00),
                EndDate = new DateTime(2022, 03, 19, 16, 00, 00)
            }
        };

        public void Seed(EntityTypeBuilder<Journey> builder) => builder.HasData(Journeys);
    }
}
