using AutoMapper;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.DAL.Interfaces;
using Transport.Proto;

namespace Transport.BLL.Services.Grpc
{
    public class GrpcVehicleService : GrpcVehicle.GrpcVehicleBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GrpcVehicleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public override async Task<VehicleResponse> GetAllVehicles(GetAllRequest request, ServerCallContext context)
        {
            var response = new VehicleResponse();
            var vehicles = await _unitOfWork.VehicleRepository.GetAll();
            foreach (var vehicle in vehicles)
            {
                var model = await _unitOfWork.ModelRepository.GetAsync(vehicle.ModelId);
                var make = await _unitOfWork.MakeRepository.Get(model.MakeId);

                model.Make = make;
                vehicle.Model = model;

                response.Vehicle.Add(_mapper.Map<GrpcVehicleModel>(vehicle));
            }
            return response;
        }
    }
}
