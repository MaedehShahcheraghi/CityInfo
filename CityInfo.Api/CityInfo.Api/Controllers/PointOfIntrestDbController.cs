using AutoMapper;
using CityInfo.Api.Context;
using CityInfo.Api.Entities;
using CityInfo.Api.Model;
using CityInfo.Api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CityInfo.Api.Controllers
{
    [Route("api/cities/{cityId}/PointOfIntrestDb")]
    [ApiController]
    public class PointOfIntrestDbController:ControllerBase
    {
        private readonly CityInfoContext context;
        private readonly ICityInfoRepository repository;
        private readonly IMapper mapper;

        public PointOfIntrestDbController(CityInfoContext context,ICityInfoRepository repository,IMapper mapper)
        {
            this.context = context;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PointOfInterestDto>>> GetPointsOfIntrestForCity(int cityId)
        {
            if (!await repository.ExistCity(cityId))
            {
              return  NotFound();
            }
            var pointofintrests=await repository.GetPoinstOfIntrestForCityAsync(cityId);
            return Ok(
                mapper.Map<IEnumerable<PointOfInterestDto>>(pointofintrests)
                );


        }
        [HttpGet("{pointId}",Name = "GetPointOfIntrestForcity")]
        public async Task<ActionResult<PointOfInterestDto>> GetPointOfIntrestForcity(int cityId , int pointId)
        {
            if (! await repository.ExistCity(cityId))
            {
                return
                     NotFound();
            }
            var pointofinterst = await repository.GetPointOfIntrestForCityAsync(cityId, pointId);
            if (pointofinterst==null)
            {
                return NotFound();
            }
            return Ok(
                mapper.Map<PointOfInterestDto>(pointofinterst));

        }

        [HttpPost]
        public async Task<ActionResult<PointOfInterestDto>> CreatPointOfIntrest(int cityId , PointOfInterestCreationDto
            pointOfInterest)
        {
            if (! await repository.ExistCity(cityId))
            {
                return NotFound();
            }
            var FinalPointOfIntrest = mapper.Map<PointOfIntrest>(pointOfInterest);
            await repository.CreatPointOfIntrestForCityAsync(cityId, FinalPointOfIntrest);
            await repository.SaveChangesAsync();
            var PointDto = mapper.Map<PointOfInterestDto>(FinalPointOfIntrest);
            return CreatedAtRoute("GetPointOfIntrestForcity", new
            {
                cityId = cityId,
                pointId = PointDto.Id

            }, PointDto);
        }
        [HttpPut("{pointId}")]
        public async Task<ActionResult> CreatePointOfInterestForUpdate(
            int cityId,
            int pointId,
            PoinOfInterestForUpdateDto poinOfInterestForUpdate)
        {
            if (! await repository.ExistCity(cityId))
            {
                return NotFound();
            }
            var pointofintrest = await repository.GetPointOfIntrestForCityAsync(cityId, pointId);
            if (pointofintrest==null)
            {
                return NotFound();
            }
            mapper.Map(poinOfInterestForUpdate, pointofintrest);
             await repository.SaveChangesAsync();
            return NoContent();

        }
        //[HttpPatch("{pontiOfInterestid}")]
        //public async Task<ActionResult> PartiallyUpdatePointOfOnterest(
        //      int cityId,
        //      int pontiOfInterestid,
        //      JsonPatchDocument<PoinOfInterestForUpdateDto> patchDocument
        //      )
        //{
        //    if (!await repository.ExistCity(cityId))
        //    {
        //        return NotFound();
        //    }

        //    var pointEntity = await repository
        //         .GetPointOfIntrestForCityAsync(cityId, pontiOfInterestid);
        //    if (pointEntity == null)
        //    {
        //        return NotFound();
        //    }

        //    var pointToPatch = mapper.Map<PoinOfInterestForUpdateDto>
        //        (pointEntity);

        //    patchDocument.ApplyTo(pointToPatch, ModelState);

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (!TryValidateModel(pointToPatch))
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    mapper.Map(pointToPatch, pointEntity);
        //    await repository.SaveChangesAsync();

        //    return NoContent();
        //}
        [HttpPatch("{pointId}")]
        public async Task<ActionResult> updetpoint(int cityId,int pointId, JsonPatchDocument<PoinOfInterestForUpdateDto> patchDocument)
        {
            if (! await repository.ExistCity(cityId))
            {
                return NotFound();
            }
            var pointentity=await repository.GetPointOfIntrestForCityAsync(cityId,pointId);
            if (pointentity==null)
            {
                return NotFound();
            }
            var pointtopatch=mapper.Map<PoinOfInterestForUpdateDto>(pointentity);
            patchDocument.ApplyTo(pointtopatch, ModelState);
            if (! ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!TryValidateModel(pointtopatch))
            {
                return BadRequest();
            }
            mapper.Map(pointtopatch, pointentity);
            await repository.SaveChangesAsync();
            return NoContent();

        }
        [HttpDelete("{poinOfIntresId}")]
        public async Task<ActionResult> DeletePointOfIntrest(int cityId, int poinOfIntresId)
        {
            if (! await repository.ExistCity(cityId))
            {
                return NotFound();
            }
            var city = await repository.GetPointOfIntrestForCityAsync(cityId, poinOfIntresId);
            if (city == null)
                return NotFound();
            repository.DeletPointOfIntrestAsync(city);
            await repository.SaveChangesAsync();
            return NoContent();
        }
    }
}
