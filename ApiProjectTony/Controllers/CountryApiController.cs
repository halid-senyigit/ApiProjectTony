using ApiProjectTony.Models.ViewModels;
using ApiProjectTony.Models.ViewModels.QueryModels;
using ApiProjectTony.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiProjectTony.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryApiController : ControllerBase
    {
        private readonly ICountryApiService countryApiService;

        public CountryApiController(ICountryApiService countryApiService)
        {
            this.countryApiService = countryApiService;
        }

        [HttpGet("GetCountryByRegion")]
        public async Task<IActionResult> GetCountryByRegion([FromQuery] GetCountryByRegionQM input)
        {
            var result = await countryApiService.getCountryNamesAsync(input.Region);
            
            return Ok(new ResponseModel<object>() { 
                Data = result,
                Status = true,
                Message = ""
            });
        }
    }
}
