using System;
using AutoMapper;
using cs_webapi_experiment.Core.Contracts;
using cs_webapi_experiment.Data;
using Microsoft.EntityFrameworkCore;

namespace cs_webapi_experiment.Core.Repository
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly HotelListingDbContext _context;

        public CountriesRepository(HotelListingDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }

        public async Task<Country> GetDetails(int id)
        {
            return await _context.Countries
                .Include(country => country.Hotels)
                .FirstOrDefaultAsync(country => country.Id == id);


        }
    }
}
