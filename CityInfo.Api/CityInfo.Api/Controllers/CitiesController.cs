using CityInfo.Api.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Api.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController:ControllerBase
    { 
        private readonly ILogger<CitiesController> _logger;
        private readonly CitiesDataStore citiesDataStore;

        public CitiesController(ILogger<CitiesController> logger,CitiesDataStore citiesDataStore)
        {
            _logger = logger;
            this.citiesDataStore = citiesDataStore;
        }
        
        [HttpGet]
      
        public ActionResult<IEnumerable<CitiyDto>> GetCities()
        {
            return Ok(citiesDataStore.cities);
            
        }
        [HttpGet("{id}",Name = "getcitybyid")]
        public ActionResult<CitiyDto> getcitybyid(int id)
        {
            try
            {
                //throw new Exception("this is khatAAAAA");
                var result = citiesDataStore.cities.FirstOrDefault(c => c.Id == id);
                if (result == null)
                {
                    _logger.LogInformation($"city with id {id} wasnt found");
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("youhve a new exeption" + ex);
               return StatusCode(500, "intenal server error");
               
            }
        }


        #region creat city
        [HttpPost]
        public ActionResult<CitiyDto> creatcity(CityForCreationDto cityForCreation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            int maxcityid = citiesDataStore.cities.Max(c => c.Id);
            var city = new CitiyDto()
            {
                Id = ++maxcityid,
                Name = cityForCreation.Name,
                Descreption = cityForCreation.Descreption

            };
            citiesDataStore.cities.Add(city);
            return CreatedAtAction("getcitybyid", new { id = city.Id }, city);
        }
        #endregion

        #region edit city with patch
        [HttpPatch("{id}")]
        public ActionResult editcity(int id,JsonPatchDocument<CityForCreationDto> cityForCreation)
        {
            var city = citiesDataStore.cities.FirstOrDefault(c => c.Id == id);
            if (city==null)
            {
                return NotFound();
            }
            var cityforpatch = new CityForCreationDto()
            {
                Name=city.Name,
                Descreption=city.Descreption
            };
            cityForCreation.ApplyTo(cityforpatch, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (!TryValidateModel(cityforpatch))
            {
                return BadRequest();
            }
            city.Name = cityforpatch.Name;
            city.Descreption = cityforpatch.Descreption;
            return NoContent();
        }
        #endregion
        #region delete city
        [HttpDelete("id")]
        public ActionResult deletecity(int id)
        {
            var city=citiesDataStore.cities.FirstOrDefault(city => city.Id == id);
            if (city==null)
            {
                return NotFound();
            }
            citiesDataStore.cities.Remove(city);
            return NoContent();
        }

        #endregion
    }
}
