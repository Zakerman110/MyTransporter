using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.DAL.Entities;
using Transport.DAL.Interfaces;
using Transport.DAL.Interfaces.IRepositories;

namespace Transport.DAL.Repositories
{
    public class VehicleRepository : GenericRepository<Vehicle, int>, IVehicleRepository
    {
        public VehicleRepository(IConnectionFactory connectionFactory, IConfiguration config) : base(connectionFactory, "Vehicle")
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            connectionFactory.SetConnection(connectionString);
        }

        public async Task<IEnumerable<Vehicle>> GetAllDetailAsync()
        {
            var query = @"SELECT v.Id, Plate, Type, IsAvailable, AutobaseId, ModelId, m.Id, Name, MakeId
                FROM Vehicle AS v 
                INNER JOIN model AS m 
                ON ModelId = m.Id";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                return await db.QueryAsync<Vehicle, Model, Vehicle>(query, (vehicle, model) => {
                    vehicle.Model = model;
                    return vehicle;
                },
                splitOn: "Id");
            }
        }

        public async Task<Vehicle> GetDetailAsync(int Id)
        {
            var query = @"SELECT v.Id, Plate, Type, IsAvailable, AutobaseId, ModelId, m.Id, Name, MakeId
                FROM Vehicle AS v 
                INNER JOIN model AS m 
                ON ModelId = m.Id
                WHERE v.Id = @id";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                var result = await db.QueryAsync<Vehicle, Model, Vehicle>(query, (vehicle, model) => {
                    vehicle.Model = model;
                    return vehicle;
                }, new { id = Id },
                splitOn: "Id");

                return result.FirstOrDefault();
            }
        }
    }
}
