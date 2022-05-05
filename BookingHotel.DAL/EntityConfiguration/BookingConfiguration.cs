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
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("booking");
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.CheckInDate).HasColumnName("b_checkin_date");
            builder.Property(x => x.CheckOutDate).HasColumnName("b_checkout_date");
            builder.Property(x=>x.UserId).HasColumnName("b_user_id");
            builder.HasOne(c => c.User).WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
