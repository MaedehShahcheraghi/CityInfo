using CityInfo.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.Api.Context
{
    public class CityInfoContext : DbContext
    {
        public CityInfoContext(DbContextOptions<CityInfoContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<PointOfIntrest> pointOfIntrests { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region SeedData City
            modelBuilder.Entity<City>().HasData(
              new City("tehran")
              {
                  Id = 1,
                  Descreption = "this is tehran"
              },
               new City("shiraz")
               {
                   Id = 2,
                   Descreption = "this is shiraz"
               },
                new City("gheshm")
                {
                    Id = 3,
                    Descreption = "this is gheshm"
                }
              );
            #endregion
            #region SeedData PointOfIntrest
            modelBuilder.Entity<PointOfIntrest>().HasData(
               new PointOfIntrest("tange washi")
               {
                   Id = 1,
                   CityId = 1,
                   Descreption = "this is tange washi"
               },
                 new PointOfIntrest("kakh sad abad")
                 {
                     Id = 2,
                     CityId = 1,
                     Descreption = "this is tange washi"
                 },
                  new PointOfIntrest("masged nasir")
                  {
                      Id = 3,
                      CityId = 2,
                      Descreption = "this is tange masged nasir "
                  },
                 new PointOfIntrest("aramgah saddi")
                 {
                     Id = 4,
                     CityId = 2,
                     Descreption = "this is aramgah sadi"
                 },
                  new PointOfIntrest("gheshm abad")
                  {
                      Id = 5,
                      CityId = 3,
                      Descreption = "this gheshm abad "
                  },
                 new PointOfIntrest("geshmak")
                 {
                     Id = 6,
                     CityId = 3,
                     Descreption = "this is gheshmak"
                 }


                );
            #endregion
            base.OnModelCreating(modelBuilder);

        }

    }
}
