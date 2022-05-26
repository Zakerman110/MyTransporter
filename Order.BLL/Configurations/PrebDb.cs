using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Order.BLL.Interfaces.Services;
using Order.BLL.Services.Grpc;
using Order.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.Configurations
{
    public static class PrebDb
    {
        public static async Task PrepPopulationAsync(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var grpcClient = serviceScope.ServiceProvider.GetService<IVehicleDataClient>();

                var vehicles = await grpcClient.ReturnAllVehicles();

                await SeedDataAsync(serviceScope.ServiceProvider.GetService<IVehicleService>(), vehicles);
            }
        }

        public static async Task SeedDataAsync(IVehicleService service, IEnumerable<Vehicle> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                if (!await service.VehicleExternalExist(vehicle.ExternalId))
                {
                    await service.AddAsync(vehicle);
                }
            }
        }
    }
}
