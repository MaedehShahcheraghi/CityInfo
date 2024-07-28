namespace CityInfo.Api.Model
{
    public class CitiyDto
    {
        public int Id  { get; set; }
        public string Name { get; set; }=String.Empty;
        public string? Descreption { get; set; }
        public int countpoint
        {
            get
            {
                return PointOfIntrest.Count;
            }
        }

        public ICollection<PointOfInterestDto> PointOfIntrest { get; set;} = new List<PointOfInterestDto>();
    }
}
