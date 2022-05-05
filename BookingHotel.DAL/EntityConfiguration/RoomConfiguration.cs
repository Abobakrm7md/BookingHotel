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
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("room");
            builder.Property("Id").HasColumnName("r_id");
            builder.Property(x => x.HotelId).HasColumnName("r_h_id");
            builder.Property(x => x.BranchId).HasColumnName("r_b_id");
            builder.Property(x => x.Type).HasColumnName("r_type");
            builder.Property(x => x.BookingId).HasColumnName("r_booking_id");
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.Hotel).WithMany().HasForeignKey(x=> x.HotelId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Branch).WithMany().HasForeignKey(x => x.BranchId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.LookUp).WithMany().HasForeignKey(x => x.Type).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Booking).WithMany().HasForeignKey(x => x.BookingId).OnDelete(DeleteBehavior.NoAction);
            builder.HasIndex(x=> new {x.Id, x.BranchId ,x.HotelId}).IsUnique();
        }
    }
}
