using Microsoft.EntityFrameworkCore;
using HotelListing.API.Data;
using HotelListing.API.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HotelListing.API.Model.Hotel;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _context;
        private readonly IMapper _mapper;

        public HotelController(IHotelRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Hotel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDto>>> GetHotels()
        {
            var hotel = await _context.GetAllAsync();

            var hotelDto = _mapper.Map<IEnumerable<HotelDto>>(hotel);

            return Ok(hotelDto);
        }

        // GET: api/Hotel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDto>> GetHotel(int id)
        {
            var hotel = await _context.GetAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            var hotelDto = _mapper.Map<HotelDto>(hotel);

            return Ok(hotelDto);
        }

        // PUT: api/Hotel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, HotelDto hotel)
        {
            if (id != hotel.Id)
            {
                return BadRequest();
            }

            //var hotelEntity = await _context.GetAsync(id);

            //if (hotelEntity == null)
            //{
            //    return NotFound();
            //}

            try
            {
                await _context.UpdateAsync(id, _mapper.Map<Hotel>(hotel));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await HotelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Hotel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CreateHotelDto>> PostHotel(CreateHotelDto hotel)
        {
            var hotelEntity = _mapper.Map<Hotel>(hotel);
            await _context.AddAsync(hotelEntity);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotel", new { id = hotelEntity.Id }, hotel);
        }

        // DELETE: api/Hotel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await _context.GetAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            await _context.Delete(id, hotel);
            //await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> HotelExists(int id)
        {
            var hotel = await _context.GetAsync(id);

            return hotel != null ? true : false;
        }
    }
}
