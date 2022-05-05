using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel.DAL.Entities
{
    public class BookingHotelContext : DbContext
    {
        public BookingHotelContext()
        {
        }

        public BookingHotelContext(DbContextOptions<BookingHotelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Hotel> Hotels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-GQ7HU3D\SQLEXPRESS; Database=BookingHotel; " +
                    "Persist Security Info=True;User ID=sa;Password=abobakr");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.ToTable("hotel");

                entity.Property(e => e.Id).HasColumnName("h_d");

                entity.Property(e => e.Name).HasColumnName("h_name");
                entity.HasKey(x => x.Id);
            });
        }
        }
    }
