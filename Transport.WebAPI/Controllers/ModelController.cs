using Microsoft.AspNetCore.Mvc;
using Transport.BLL.DTO.Request;
using Transport.BLL.DTO.Response;
using Transport.BLL.Interfaces.Services;

namespace Transport.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ModelController : ControllerBase
    {
        IModelService _modelService;

        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        public async Task<IEnumerable<ModelResponse>> Get()
        {
            return await _modelService.GetAsync();
        }

        [Route("detail")]
        [HttpGet]
        public async Task<IEnumerable<ModelMakeResponse>> GetDetail()
        {
            return await _modelService.GetDetailAsync();
        }

        [Route("{Id}")]
        [HttpGet]
        public async Task<ModelResponse> GetById(int Id)
        {
            return await _modelService.GetByIdAsync(Id);
        }

        [Route("detail/{Id}")]
        [HttpGet]
        public async Task<ModelMakeResponse> GetByIdDetail(int Id)
        {
            return await _modelService.GetByIdDetailAsync(Id);
        }

        [HttpPost]
        public async Task Post([FromBody] ModelRequest model)
        {
            await _modelService.AddAsync(model);
        }

        [Route("{id?}")]
        [HttpPut]
        public async Task Put([FromBody] ModelRequest model)
        {
            await _modelService.UpdateAsync(model);
        }

        [Route("{id?}")]
        [HttpDelete]
        public async Task Delete([FromBody] int Id)
        {
            await _modelService.DeleteAsync(Id);
        }
    }
}
