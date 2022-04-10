using Microsoft.AspNetCore.Mvc;
using Order.BLL.DTO.Responses;
using Order.BLL.Interfaces.Services;

namespace Order.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CountryResponse>>> Get()
        {
            try
            {
                var models = await _countryService.GetAsync();
                return Ok(models);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }
    }
}
