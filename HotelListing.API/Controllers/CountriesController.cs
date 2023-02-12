using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Data;
using AutoMapper;
using HotelListing.API.Model.Country;
using HotelListing.API.Contracts;
using HotelListing.API.Repositories;

namespace HotelListing.API.ControllersW
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countryContext;
        private readonly IMapper _mapper;

        public CountriesController(ICountryRepository context, IMapper mapper)
        {
            _countryContext = context;
            _mapper  = mapper;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
        {
            var country = await _countryContext.GetAllAsync();

            var getCountryDto = _mapper.Map<IEnumerable<GetCountryDto>>(country);   
            
            return Ok(getCountryDto);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        {
            var country = await _countryContext.GetCountryDetails(id);
            //await _context.Countries.Include(x => x.Hotel).FirstOrDefaultAsync(x => x.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            var CountryDto = _mapper.Map<CountryDto>(country);

            return Ok(CountryDto);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDto updateCountryDto)
        {
            if (id != updateCountryDto.Id)
            {
                return BadRequest();
            }

            var country = await _countryContext.GetAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCountryDto, country);

            try
            {
                await _countryContext.UpdateAsync(id, country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await CountryExists(id))
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

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryDto createCountryDto)
        {
            var country = _mapper.Map<Country>(createCountryDto);

            //_context.Countries.Add(country);
            //await _context.SaveChangesAsync();

            await _countryContext.AddAsync(country);

            return CreatedAtAction("GetCountry", new { Id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _countryContext.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            await _countryContext.Delete(id,country);

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            var country = await _countryContext.GetAsync(id);

            return country != null ? true : false;
        }
    }
}
