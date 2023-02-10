using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Model
{
    public class Country
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public virtual IList<Hotel> Hotel { get; set; }
    }
}
