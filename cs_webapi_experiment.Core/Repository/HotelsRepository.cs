using System;
using AutoMapper;
using cs_webapi_experiment.Core.Contracts;
using cs_webapi_experiment.Core.Repository;
using cs_webapi_experiment.Data;
using Microsoft.EntityFrameworkCore;

namespace cs_webapi_experiment.Repository
{
    public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
    {
        private readonly HotelListingDbContext _context;

        public HotelsRepository(HotelListingDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }


        public async Task<Hotel> GetDetails(int id)
        {
            return await _context.Hotels
                .Include(hotel => hotel.Country)
                .FirstOrDefaultAsync(hotel => hotel.Id == id);
        }

    }
}

