using Microsoft.AspNetCore.Mvc;
using Order.BLL.DTO.Requests;
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
                var countries = await _countryService.GetAsync();
                return Ok(countries);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpGet("{id}", Name = nameof(GetCountryById))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CountryResponse>> GetCountryById(int Id)
        {
            return Ok(await _countryService.GetByIdAsync(Id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post([FromBody] CountryRequest country)
        {
            try
            {
                var countryResponse = await _countryService.AddAsync(country);
                return CreatedAtRoute(nameof(GetCountryById), new { Id = countryResponse.Id }, countryResponse);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [Route("{id?}")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put([FromBody] CountryRequest country)
        {
            try
            {
                await _countryService.UpdateAsync(country);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [Route("{id?}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete([FromRoute] int Id)
        {
            try
            {
                await _countryService.DeleteAsync(Id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }
    }
}
