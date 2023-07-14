using Microsoft.AspNetCore.Mvc;

namespace CityDataAPI.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController: ControllerBase
    {
        [HttpGet]
        public JsonResult GetCities()
        {
            return new JsonResult(
                new List<object>
                {
                    new {id = 1, Name = "São Paulo"},
                    new {id = 2, Name = "Salvador"}
                }
            );
        }
    }
}
