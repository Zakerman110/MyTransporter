using Microsoft.AspNetCore.Mvc;
using Transport.BLL.DTO.Request;
using Transport.BLL.DTO.Response;
using Transport.BLL.Interfaces.Services;

namespace Transport.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<IEnumerable<VehicleResponse>> Get()
        {
            return await _vehicleService.GetAsync();
        }

        [Route("detail")]
        [HttpGet]
        public async Task<IEnumerable<VehicleModelResponse>> GetDetail()
        {
            return await _vehicleService.GetDetailAsync();
        }

        [Route("{Id}")]
        [HttpGet]
        public async Task<VehicleResponse> GetById(int Id)
        {
            return await _vehicleService.GetByIdAsync(Id);
        }

        [Route("detail/{Id}")]
        [HttpGet]
        public async Task<VehicleModelResponse> GetByIdDetail(int Id)
        {
            return await _vehicleService.GetByIdDetailAsync(Id);
        }

        [HttpPost]
        public async Task Post([FromBody] VehicleRequest model)
        {
            await _vehicleService.AddAsync(model);
        }

        [Route("{id?}")]
        [HttpPut]
        public async Task Put([FromBody] VehicleRequest model)
        {
            await _vehicleService.UpdateAsync(model);
        }

        [Route("{id?}")]
        [HttpDelete]
        public async Task Delete([FromBody] int Id)
        {
            await _vehicleService.DeleteAsync(Id);
        }
    }
}
