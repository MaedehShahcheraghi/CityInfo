using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityInfo.Api.Entities
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Descreption { get; set; }
        public City(string name)
        {
            this.Name=name;
        }

        public ICollection<PointOfIntrest> PointOfIntrest { get; set; } = new List<PointOfIntrest>();

    }
}
