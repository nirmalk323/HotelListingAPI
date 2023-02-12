using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.API.Model.Hotel
{
    public abstract class BaseHotelDto
    {

        [Required]
        public string Name { get; set; }
        [ForeignKey(nameof(CountryId))]
        [Required]
        [Range(0, int.MaxValue)]
        public int CountryId { get; set; }
        public double? Rating { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
