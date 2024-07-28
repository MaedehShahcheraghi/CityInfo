using AutoMapper;

namespace CityInfo.Api.Profiles
{
    public class CityProfile:Profile
    {
        public CityProfile()
        {
            CreateMap<Entities.City,Model.CityWithoutPointOfIntrestDto>();
            CreateMap<Entities.City, Model.CitiyDto>();
        }
    }
}
