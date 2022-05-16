using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.DAL.Entities;
using Order.DAL.Interfaces;

namespace Order.DAL.Seeding
{
    public class RouteSeeder : ISeeder<Route>
    {
        List<Route> Routes = new()
        {
            new Route
            {
                Id = 1,
                StartPointId = 1,
                EndPointId = 2
            },
            new Route
            {
                Id = 2,
                StartPointId = 2,
                EndPointId = 1
            },
            new Route
            {
                Id = 3,
                StartPointId = 1,
                EndPointId = 3
            },
            new Route
            {
                Id = 4,
                StartPointId = 3,
                EndPointId = 1
            },
            new Route
            {
                Id = 5,
                StartPointId = 1,
                EndPointId = 5
            },
            new Route
            {
                Id = 6,
                StartPointId = 5,
                EndPointId = 1
            },
            new Route
            {
                Id = 7,
                StartPointId = 1,
                EndPointId = 12
            },
            new Route
            {
                Id = 8,
                StartPointId = 12,
                EndPointId = 1
            }
        };

        public void Seed(EntityTypeBuilder<Route> builder) => builder.HasData(Routes);
    }
}
