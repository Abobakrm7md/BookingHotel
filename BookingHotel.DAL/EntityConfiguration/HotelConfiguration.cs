using BookingHotel.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel.DAL.EntityConfiguration
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {

                builder.ToTable("hotel");
                builder.Property(e => e.Id).HasColumnName("h_d");
                builder.Property(e => e.Name).HasColumnType("nvarchar(250)").HasColumnName("h_name");
                builder.HasKey(x => x.Id);
        }
    }
}
