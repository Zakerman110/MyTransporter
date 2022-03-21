using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.BLL.DTO.Request;
using Transport.BLL.DTO.Response;
using Transport.BLL.Interfaces.Services;
using Transport.DAL.Entities;
using Transport.DAL.Interfaces;

namespace Transport.BLL.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehicleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<VehicleResponse>> GetAsync()
        {
            IEnumerable<Vehicle> vehicles = await _unitOfWork.VehicleRepository.GetAll();
            List<VehicleResponse> vehiclesResponse = new List<VehicleResponse>();
            foreach (var vehicle in vehicles)
            {
                VehicleResponse vehicleResponse = new VehicleResponse();
                vehicleResponse.Id = vehicle.Id;
                vehicleResponse.Plate = vehicle.Plate;
                vehicleResponse.Type = vehicle.Type;
                vehicleResponse.IsAvailable = vehicle.IsAvailable;

                vehiclesResponse.Add(vehicleResponse);
            }
            return vehiclesResponse;
        }

        public async Task<IEnumerable<VehicleModelResponse>> GetDetailAsync()
        {
            IEnumerable<Vehicle> vehicles = await _unitOfWork.VehicleRepository.GetAllDetailAsync();
            List<VehicleModelResponse> vehiclesResponse = new List<VehicleModelResponse>();
            foreach (var vehicle in vehicles)
            {
                VehicleModelResponse vehicleResponse = new VehicleModelResponse();
                vehicleResponse.Id = vehicle.Id;
                vehicleResponse.Plate = vehicle.Plate;
                vehicleResponse.Type = vehicle.Type;
                vehicleResponse.IsAvailable = vehicle.IsAvailable;
                vehicleResponse.AutobaseId = vehicle.AutobaseId;

                ModelResponse modelResponse = new ModelResponse();
                modelResponse.Id = vehicle.Model.Id;
                modelResponse.Name = vehicle.Model.Name;

                vehicleResponse.Model = modelResponse;

                vehiclesResponse.Add(vehicleResponse);
            }
            return vehiclesResponse;
        }

        public async Task<VehicleResponse> GetByIdAsync(int id)
        {
            Vehicle vehicle = await _unitOfWork.VehicleRepository.Get(id);
            VehicleResponse vehicleResponse = new VehicleResponse();
            vehicleResponse.Id = vehicle.Id;
            vehicleResponse.Plate = vehicle.Plate;
            vehicleResponse.Type = vehicle.Type;
            vehicleResponse.IsAvailable = vehicle.IsAvailable;
            return vehicleResponse;
        }

        public async Task<VehicleModelResponse> GetByIdDetailAsync(int id)
        {
            Vehicle vehicle = await _unitOfWork.VehicleRepository.GetDetailAsync(id);
            VehicleModelResponse vehicleResponse = new VehicleModelResponse();

            vehicleResponse.Id = vehicle.Id;
            vehicleResponse.Plate = vehicle.Plate;
            vehicleResponse.Type = vehicle.Type;
            vehicleResponse.IsAvailable = vehicle.IsAvailable;
            vehicleResponse.AutobaseId = vehicle.AutobaseId;

            ModelResponse modelResponse = new ModelResponse();
            modelResponse.Id = vehicle.Model.Id;
            modelResponse.Name = vehicle.Model.Name;

            vehicleResponse.Model = modelResponse;

            return vehicleResponse;
        }

        public async Task AddAsync(VehicleRequest request)
        {
            Vehicle vehicle = new Vehicle();
            vehicle.Plate = request.Plate;
            vehicle.Type = request.Type;
            vehicle.IsAvailable = request.IsAvailable;
            vehicle.AutobaseId = request.AutobaseId;
            vehicle.ModelId = request.ModelId;
            await _unitOfWork.VehicleRepository.Add(vehicle);
        }

        public async Task UpdateAsync(VehicleRequest request)
        {
            Vehicle vehicle = new Vehicle();
            vehicle.Id = request.Id;
            vehicle.Plate = request.Plate;
            vehicle.Type = request.Type;
            vehicle.IsAvailable = request.IsAvailable;
            vehicle.AutobaseId = request.AutobaseId;
            vehicle.ModelId = request.ModelId;
            await _unitOfWork.VehicleRepository.Update(vehicle);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.VehicleRepository.Delete(new Vehicle { Id = id });
        }
    }
}
