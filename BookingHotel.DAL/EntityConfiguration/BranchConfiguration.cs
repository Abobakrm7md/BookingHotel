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
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ToTable("branch");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnName("b_name").HasColumnType("nvarchar(250)");
            builder.Property(x => x.Id).HasColumnName("b_id");
            builder.Property(x => x.HotelId).HasColumnName("b_h_id");
            builder.HasOne(x => x.Hotel).WithMany().HasForeignKey(x => x.HotelId);
        }
    }
}
