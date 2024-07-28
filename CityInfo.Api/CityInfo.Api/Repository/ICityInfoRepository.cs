using CityInfo.Api.Entities;

namespace CityInfo.Api.Repository
{
    public interface ICityInfoRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        Task<City?> GetCityAsync(int cityId, bool includePointOfIntrest);
        Task<IEnumerable<PointOfIntrest>> GetPoinstOfIntrestForCityAsync(int cityId);
        Task<PointOfIntrest?> GetPointOfIntrestForCityAsync(int cityId, int PointOfIntrestId);
        Task<bool> ExistCity(int cityId);
        Task CreatPointOfIntrestForCityAsync(int cityId,PointOfIntrest pointOfIntrest);
        Task<bool> SaveChangesAsync();
        void DeletPointOfIntrestAsync(PointOfIntrest pointOfIntrest);

    }
}
