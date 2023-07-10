using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cs_webapi_experiment.Data;
using cs_webapi_experiment.Core.Model.Country;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using cs_webapi_experiment.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using cs_webapi_experiment.Core.Exception;
using cs_webapi_experiment.Core.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OData.Query;

namespace cs_webapi_experiment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountriesRepository _countriesRepository;
        private readonly IMapper _mapper;

        public ILogger<CountryController> _logger;

        public CountryController(ICountriesRepository countriesRepository, IMapper mapper, ILogger<CountryController> logger)
        {
            _countriesRepository = countriesRepository;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/Country
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
        {
            var countries = await _countriesRepository.GetAllAsync();
            var records = _mapper.Map<List<GetCountryDto>>(countries);

            return Ok(records);
        }


        // GET: api/Country/?StartIndex=0&pagesize=25&PageNumber=1
        [HttpGet("Details")]
        public async Task<ActionResult<PagedResult<GetCountryDto>>> GetPagedCountries([FromQuery] QueryParameters queryParameters)
        {
            var pagedCountriesResult = await _countriesRepository.GetAllAsync<GetCountryDto>(queryParameters);
            return Ok(pagedCountriesResult);
        }

        // GET: api/Country/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        {
            var country = await _countriesRepository.GetDetails(id);

            if (country == null)
            {
                throw new NotFoundException(nameof(GetCountries), id);
            }
            var countryDto = _mapper.Map<CountryDto>(country);


            return countryDto;
        }

        // PUT: api/Country/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDto countryDto)
        {
            if (id != countryDto.Id)
            {
                return BadRequest();
            }

            var country = await _countriesRepository.GetAsync(id);
            if (country == null)
            {
                throw new NotFoundException(nameof(GetCountries), id);
            }
            country = _mapper.Map(countryDto, country);

            try
            {
                await _countriesRepository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
                {
                    throw new NotFoundException(nameof(GetCountries), id);

                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Country
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryDto createCountry)
        {
            var country = _mapper.Map<Country>(createCountry);

            await _countriesRepository.AddAsync(country);

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Country/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Adminstrator")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _countriesRepository.GetAsync(id);
            if (country == null)
            {
                throw new NotFoundException(nameof(GetCountries), id);

            }

            await _countriesRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _countriesRepository.Exists(id);
        }
    }
}



