using CityInfo.Api.Model;
using CityInfo.Api.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Api.Controllers
{
    [Route("api/cities/{cityid}/PointOfInterest")]
    [ApiController]
    public class PointOfInterestController : ControllerBase
    {
        private readonly IMailService _mailService;
        private readonly CitiesDataStore citiesDataStore;

        public PointOfInterestController(IMailService mailService ,CitiesDataStore citiesDataStore)
        {
            _mailService = mailService;
            this.citiesDataStore = citiesDataStore;
        }
        [HttpGet]
      public ActionResult<IEnumerable<PointOfInterestDto>> getpoints(int cityid)
        {
            var result = citiesDataStore.cities.FirstOrDefault(c => c.Id == cityid);
            if (result == null)
            {
              return  NotFound();
            }
       

                  return  Ok(result.PointOfIntrest);
            
        }
        [HttpGet("{pointid}",Name = "getpoints")]
        public ActionResult<PointOfInterestDto> getpoints(int cityid,int pointid)
        {
            var result = citiesDataStore.cities.FirstOrDefault(c => c.Id == cityid);
            if (result==null)
            {
                return NotFound();
            }
           var result1 = result.PointOfIntrest.FirstOrDefault(c => c.Id == pointid);
            if (result1==null)
            {
                NotFound();
            }
            return Ok(result1);
        }


        [HttpPost]
        public ActionResult<PointOfInterestDto> Creation(int cityid
           ,PointOfInterestCreationDto pointOfInterest
            )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var city=citiesDataStore.cities.FirstOrDefault(c=> c.Id == cityid);
            if (city ==null)
            {
               return NotFound();
            }
            var maxpointofinterest = citiesDataStore.cities.SelectMany(c => c.PointOfIntrest).Max
                (p => p.Id);
            var creatpoint = new PointOfInterestDto()
            {
                Id = ++maxpointofinterest,
                Name = pointOfInterest.Name,
                Descreption = pointOfInterest.Descreption

            };
            city.PointOfIntrest.Add(creatpoint);
            return CreatedAtAction("getpoints", new { cityid = cityid, pointid = creatpoint.Id }, creatpoint);

        }

        #region edit with put
        [HttpPut("{pointofinterestid}")]
        public ActionResult updatepointofintrest(int cityid, int pointofinterestid,
         PoinOfInterestForUpdateDto poinOfInterest)
        {
            var city = citiesDataStore.cities.FirstOrDefault(c => c.Id == cityid);
            if (city == null)
            {
                return NotFound();
            }
            var point = city.PointOfIntrest.FirstOrDefault(p => p.Id == pointofinterestid);
            if (point == null)
                return NotFound();
            point.Name = poinOfInterest.Name;
            point.Descreption = poinOfInterest.Descreption;
            return NoContent();
        }
        #endregion

        #region edit with patch
        [HttpPatch("{pointofintrestid}")]
        public ActionResult PartiallyUpdatePointOfIntrest(
            int cityid ,int pointofintrestid , JsonPatchDocument<PoinOfInterestForUpdateDto> patchDocument)
        {
            var city = citiesDataStore.cities.FirstOrDefault(c => c.Id == cityid);
            if (city==null)
            {
                return NotFound();
            }
            var pointofintrestfromstore = city.PointOfIntrest.FirstOrDefault(p => p.Id == pointofintrestid);
            if (pointofintrestid == null)
                return NotFound();

            var pointofintresttopatch = new PoinOfInterestForUpdateDto()
            {
                Name = pointofintrestfromstore.Name,
                Descreption = pointofintrestfromstore.Descreption
            };
            patchDocument.ApplyTo(pointofintresttopatch, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (! TryValidateModel(pointofintresttopatch))
            {
                return BadRequest(modelState: ModelState);
            }
            pointofintrestfromstore.Name = pointofintresttopatch.Name;
            pointofintresttopatch.Descreption = pointofintresttopatch.Descreption;
            return NoContent();

        }
        #endregion

        #region Delet With HttpDelete
        [HttpDelete("{pointid}")]
        public ActionResult deletepointofintrest(int cityid , int pointid)
        {
            //find a city
            var city = citiesDataStore.cities.FirstOrDefault(c => c.Id == cityid);
            if (city ==null)
            {
                return NotFound();
            }
            var pointofintrest = city.PointOfIntrest.FirstOrDefault(p=> p.Id==pointid);
            if (pointofintrest == null)
                return NotFound();
            city.PointOfIntrest.Remove(pointofintrest);
            _mailService.send("poiunt of intrest deleted", "" +
                $"point of intrest is: {pointofintrest.Name} with {pointofintrest.Id}");
            //_mailService.Email("poiunt of intrest deleted",
            //     $"point of intrest is: {pointofintrest.Name} with {pointofintrest.Id}",
            //     "maedeh.shahcheraghi1384@gmail.com");
            return NoContent();
        }
        #endregion



    }
}
