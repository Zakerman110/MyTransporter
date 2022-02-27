using Microsoft.AspNetCore.Mvc;
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
    }
}
