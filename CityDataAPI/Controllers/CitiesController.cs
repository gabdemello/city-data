using AutoMapper;
using CityDataAPI.Models;
using CityDataAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityDataAPI.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityDataRepository _cityDataRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICityDataRepository cityDataRepository, IMapper mapper)
        {
            _cityDataRepository = cityDataRepository ?? 
                throw new ArgumentNullException(nameof(cityDataRepository));
            
            _mapper = mapper ?? 
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithoutPointOfInterestDto>>> GetCities()
        {   
            var cityEntities = await _cityDataRepository.GetCitiesAsync();

            return Ok(_mapper.Map<IEnumerable<CityWithoutPointOfInterestDto>>(cityEntities));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(int id, bool includePointsOfInterest = false)
        {
            var city = await _cityDataRepository.GetCityAsync(id, includePointsOfInterest);

            if(city == null)
            {
                return NotFound();
            }

            if (includePointsOfInterest)
            {
                return Ok(_mapper.Map<CityDto>(city));
            }

            return Ok(_mapper.Map<CityWithoutPointOfInterestDto>(city));

        }
    }
}
