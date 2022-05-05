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
    public class LookUpConfiguration : IEntityTypeConfiguration<LookUp>
    {
        public void Configure(EntityTypeBuilder<LookUp> builder)
        {
            builder.ToTable("lookup");
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.Id).HasColumnName("l_id");
            builder.Property(x => x.Name).HasColumnName("l_name");
            builder.Property(x => x.Cost).HasColumnName("l_cost");
        }
    }
}
