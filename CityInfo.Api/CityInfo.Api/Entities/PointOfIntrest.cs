using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityInfo.Api.Entities
{
    public class PointOfIntrest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required]
        [MinLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Descreption { get; set; }

        [ForeignKey("CityId")]
        public City city { get; set; }


        public PointOfIntrest(string name)
        {
            this.Name = name;
        }

    }
}
