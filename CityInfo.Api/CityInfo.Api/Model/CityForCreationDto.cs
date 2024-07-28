using System.ComponentModel.DataAnnotations;

namespace CityInfo.Api.Model
{
    public class CityForCreationDto
    {
        [Required(ErrorMessage ="name is requierd")]
        [MaxLength(100)]
        public string Name { get; set; } = String.Empty;
        [MaxLength(200)]
        public string? Descreption { get; set; }
    }
}
