using DependencyInjection.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var countryRepository = new InMemoryRepository();

            var countries = countryRepository.GetAll();

            return Ok(countries);
        }

        [HttpGet("v2")]
        public IActionResult GetV2()
        {
            var countries = _countryRepository.GetAll();

            return Ok(countries);
        }
    }
}
