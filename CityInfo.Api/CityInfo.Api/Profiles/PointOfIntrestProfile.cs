using AutoMapper;

namespace CityInfo.Api.Profiles
{
    public class PointOfIntrestProfile:Profile
    {
        public PointOfIntrestProfile()
        {
            CreateMap<Entities.PointOfIntrest,Model.PointOfInterestDto>();
            CreateMap<Model.PointOfInterestCreationDto, Entities.PointOfIntrest>();
            CreateMap<Model.PoinOfInterestForUpdateDto, Entities.PointOfIntrest>();
            CreateMap<Entities.PointOfIntrest,Model.PoinOfInterestForUpdateDto >();
        }
    }
}
