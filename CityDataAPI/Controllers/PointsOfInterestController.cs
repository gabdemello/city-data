using AutoMapper;
using CityDataAPI.Models;
using CityDataAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityDataAPI.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        private readonly ILogger<PointsOfInterestController> _logger;
        private readonly IMailService _mailService;
        private readonly ICityDataRepository _cityDataRepository;
        private readonly IMapper _mapper;
        private readonly CitiesDataStore _citiesDataStore;

        public PointsOfInterestController(ILogger<PointsOfInterestController> logger,
            IMailService mailService,
            ICityDataRepository cityDataRepository,
            IMapper mapper)
        {
            _logger = logger 
                ?? throw new ArgumentNullException(nameof(logger));

            _mailService = mailService 
                ?? throw new ArgumentNullException(nameof(mailService));

            _cityDataRepository = cityDataRepository
                ?? throw new ArgumentException(nameof(cityDataRepository));

            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PointOfInterestDto>>> GetPointsOfInterest(int cityId)
        {   
            if(!await _cityDataRepository.CityExistsAsync(cityId))
            {
                _logger.LogInformation(
                    $"City with id {cityId} wasn't found when accessing points of interest."
                    );
                return NotFound();
            }

            var pointsOfInterestForCity = await _cityDataRepository
                .GetPointsOfInterestsForCityAsync(cityId);

            return Ok(_mapper.Map<IEnumerable<PointOfInterestDto>>(pointsOfInterestForCity));
        }

        [HttpGet("{pointofinterestid}", Name = "GetPointOfInterest")]
        public async Task<ActionResult<PointOfInterestDto>> GetPointOfInterest(int cityId, int pointOfInterestId)
        {
            if(!await _cityDataRepository.CityExistsAsync(cityId))
            {
                return NotFound();
            }

            var pointOfInterest = await _cityDataRepository
                .GetPointOfInterestForCityAsync(cityId, pointOfInterestId);

            if(pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PointOfInterestDto>(pointOfInterest));

        }
        [HttpPost]
        public async Task<ActionResult<PointOfInterestDto>> CreatePointOfInterest(
            int cityId,
            PointOfInterestForCreationDto pointOfInterest)
        {
            
            if(!await _cityDataRepository.CityExistsAsync(cityId))
            {
                return NotFound();
            }

            var finalPointOfInterest = _mapper.Map<Entities.PointOfInterest>(pointOfInterest);

            await _cityDataRepository.AddPointOfInterestForCityAsync(
                cityId,
                finalPointOfInterest
                );

            await _cityDataRepository.SaveChangesAsync();

            var createdPointOfInterestToReturn =
                _mapper.Map<Models.PointOfInterestDto>(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest",
                new
                {
                    cityId = cityId,
                    pointOfinterestId = finalPointOfInterest.Id
                },
                createdPointOfInterestToReturn);

        }

        [HttpPut("{pointofinterestid}")]

        public async Task<ActionResult> UpdatePointOfInterest(int cityId, int pointOfInterestId, 
            PointOfInterestForUpdateDto pointOfInterest)
        {
            if (!await _cityDataRepository.CityExistsAsync(cityId))
            {
                return NotFound();
            }

            var pointOfInterestEntity = await _cityDataRepository
                 .GetPointOfInterestForCityAsync(cityId, pointOfInterestId);

            if (pointOfInterestEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(pointOfInterest, pointOfInterestEntity);

            await _cityDataRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{pointofinterestid}")]
        public async Task<ActionResult>PartiallyUpdatePointOfInterest(
            int cityId, int pointOfInterestId,
            JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument)
        {
            if (!await _cityDataRepository.CityExistsAsync(cityId))
            {
                return NotFound();
            }

            var pointOfInterestEntity = await _cityDataRepository
                .GetPointOfInterestForCityAsync(cityId, pointOfInterestId);

            if (pointOfInterestEntity == null)
            {
                return NotFound();
            }

            var pointOfInterestToPatch = _mapper.Map<PointOfInterestForUpdateDto>(
                pointOfInterestEntity);

            patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(!TryValidateModel(pointOfInterestToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(pointOfInterestToPatch, pointOfInterestEntity);

            await _cityDataRepository.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{pointOfInterestId}")]
        public async Task<ActionResult> DeletePointOfInterest(int cityId, int pointOfInterestId)
        {
            
            if(!await _cityDataRepository.CityExistsAsync(cityId))
            {
                return NotFound();
            }

            var pointOfinterestEntity = await _cityDataRepository
                .GetPointOfInterestForCityAsync(cityId, pointOfInterestId);

            if (pointOfinterestEntity == null)
            {
                return NotFound(); 
            }

            _cityDataRepository.DeletePointOfInterest(pointOfinterestEntity);

            _mailService.Send(
                "Point of interest deleted",
                $"Point of interest {pointOfinterestEntity.Name} with id {pointOfinterestEntity.Id} was deleted."
                );

            return NoContent();
        }

    }
}
