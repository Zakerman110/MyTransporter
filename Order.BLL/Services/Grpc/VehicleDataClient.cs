using AutoMapper;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Order.DAL.Entities;
using Order.Proto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.Services.Grpc
{
    public class VehicleDataClient : IVehicleDataClient
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public VehicleDataClient(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Vehicle>> ReturnAllVehicles()
        {
            var channel = GrpcChannel.ForAddress(_configuration["GrpcVehicle"]);
            var client = new GrpcVehicle.GrpcVehicleClient(channel);
            var request = new GetAllRequest();

            try
            {
                var reply = await client.GetAllVehiclesAsync(request);
                return _mapper.Map<IEnumerable<Vehicle>>(reply.Vehicle);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
