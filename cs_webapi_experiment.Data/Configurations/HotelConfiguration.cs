using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cs_webapi_experiment.Data.Configurations
{
	public class HotelConfiguration: IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                            new Hotel
                            {
                                Id = 1,
                                Name = "Hotel 1 ",
                                CountryId = 1,
                                Address = "Hotem 1 Address",
                                Rating = 2
                            },
                            new Hotel
                            {
                                Id = 2,
                                Name = "Hotel 2 ",
                                CountryId = 2,
                                Address = "Hotem 2 Address",
                                Rating = 3
                            },
                            new Hotel
                            {
                                Id = 3,
                                Name = "Hotel 3 ",
                                CountryId = 2,
                                Address = "Hotem 3 Address",
                                Rating = 3
                            },
                                            new Hotel
                                            {
                                                Id = 4,
                                                Name = "Hotel 4 ",
                                                CountryId = 3,
                                                Address = "Hotem 4 Address",
                                                Rating = 3
                                            }
                            );
        }
    }
}

