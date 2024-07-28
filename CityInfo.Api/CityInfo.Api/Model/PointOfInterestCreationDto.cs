using System.ComponentModel.DataAnnotations;

namespace CityInfo.Api.Model
{
    public class PointOfInterestCreationDto
    {
        [Required(ErrorMessage ="name is requierd ....")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(200)]
        public string? Descreption { get; set; }
    }
}
