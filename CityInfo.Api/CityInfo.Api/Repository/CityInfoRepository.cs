using CityInfo.Api.Context;
using CityInfo.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.Api.Repository
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly CityInfoContext context;

        public CityInfoRepository(CityInfoContext context)
        {
            this.context = context;
        }

        public async Task CreatPointOfIntrestForCityAsync(int cityId, PointOfIntrest pointOfIntrest)
        {
            var city = await GetCityAsync(cityId, false);
            if (city != null)
            {
                city.PointOfIntrest.Add(pointOfIntrest);
            }
        }

        public  void DeletPointOfIntrestAsync(PointOfIntrest pointOfIntrest)
        {
            context.pointOfIntrests.Remove(pointOfIntrest);
        }

        public async Task<bool> ExistCity(int cityId)
        {
            return await context.Cities.AnyAsync(c => c.Id == cityId);
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await context.Cities.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<City?> GetCityAsync(int cityId, bool includePointOfIntrest)
        {
            if (includePointOfIntrest)
            {
                return await context.Cities.Include(c => c.PointOfIntrest).Where
                    (c => c.Id == cityId).FirstOrDefaultAsync();
            }
            return
               await context.Cities.Where(c => c.Id == cityId).FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<PointOfIntrest>> GetPoinstOfIntrestForCityAsync(int cityId)
        {
            return await context.pointOfIntrests.Where(c => c.CityId == cityId).ToListAsync();
        }

        public async Task<PointOfIntrest?> GetPointOfIntrestForCityAsync(int cityId, int PointOfIntrestId)
        {
            return await context.pointOfIntrests.Where(c => c.CityId == cityId && c.Id == PointOfIntrestId).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await context.SaveChangesAsync() > 0);
        }
    }
}
