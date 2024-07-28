using CityInfo.Api.Model;

namespace CityInfo.Api
{
    public class CitiesDataStore
    {
        public List<CitiyDto> cities { get; set; }
        //public static CitiesDataStore  current{ get; } = new CitiesDataStore();
        public CitiesDataStore()
        {
            cities = new List<CitiyDto>()
            {
                new CitiyDto() {
                Id = 1,Name="tehran",Descreption="this is my city",
                    PointOfIntrest =
                    {
                        new PointOfInterestDto() {
                        Id=1,
                        Name="gaye didany 1",
                        Descreption="this is gaye didany 1"
                        }
                    }
                },
                
                new CitiyDto() {
                Id = 2,Name="shiraz",Descreption="this is my city",
                    PointOfIntrest =
                    {
                        new PointOfInterestDto() {
                        Id=2,
                        Name="gaye didany 1",
                        Descreption="this is gaye didany 2"
                        }
                    }},
                 new CitiyDto() {
                Id = 3,Name="ahvaz",Descreption="this is my city"
                 ,
                    PointOfIntrest =
                    {
                        new PointOfInterestDto() {
                        Id=3,
                        Name="gaye didany 1",
                        Descreption="this is gaye didany 1"
                        }
                    }}
            };
        }
    }
}
