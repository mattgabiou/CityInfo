using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : Controller
    {    
        [HttpGet]     
        public ActionResult<IEnumerable<CityDto>> GetCities() // Choose the model (CityDto)
        {
            return Ok(CitiesDataStore.Current.Cities); // Get an instance of the datastore
        }

        [HttpGet("{id}")]
        public ActionResult<CityDto> GetCity(int id) // Use the CityDto model
        {
            // find specific city
            var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);


            // Return types of http status codes
            // No specific city found
            if (cityToReturn == null)
            {
                return NotFound(); // Return 404
            }
            // else return 200
            return Ok(cityToReturn); // Return 200
        }
    }
}
