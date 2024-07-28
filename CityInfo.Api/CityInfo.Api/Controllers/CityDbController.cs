using AutoMapper;
using CityInfo.Api.Entities;
using CityInfo.Api.Model;
using CityInfo.Api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CityInfo.Api.Controllers
{
    [Route("api/CityDbController")]
 
    [ApiController]
    public class CityDbController : ControllerBase
    {
        private readonly ICityInfoRepository city;
        private readonly IMapper _mapper;
        public CityDbController(ICityInfoRepository city,IMapper mapper)
        {
            this.city = city;
            _mapper=mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithoutPointOfIntrestDto>>> GetCities()
        {
            var cities = await city.GetCitiesAsync();
            //var result = new List<CityWithoutPointOfIntrestDto>();
            //foreach (var c in cities)
            //{
            //    result.Add(new CityWithoutPointOfIntrestDto()
            //    {
            //        Id = c.Id,
            //        Name = c.Name,
            //        Descreption = c.Descreption
            //    });

            //}
            
            return Ok(
                _mapper.Map<IEnumerable<City>>(cities));

        }
        [HttpGet("{cityid}")]
        public async Task<IActionResult> GetCity(int cityid,bool IncludePointOfIntrest=false)
        {
            var mycity = await city.GetCityAsync(cityid, IncludePointOfIntrest);
            if (mycity==null)
            {
                return NotFound();
            }
            if (IncludePointOfIntrest)
            {
                return Ok(
                    _mapper.Map<CitiyDto>(mycity));
            }
            return Ok(
                _mapper.Map<CityWithoutPointOfIntrestDto>(mycity));
        }
    }
}
