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
    public class MakeRepository : GenericRepository<Make, int>, IMakeRepository
    {
        public MakeRepository(IConnectionFactory connectionFactory, IConfiguration config) : base(connectionFactory, "Make")
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            connectionFactory.SetConnection(connectionString);
        }
    }
}
