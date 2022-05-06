using BookingHotel.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel.DAL.Data
{
    public class BookingHotelContext : IdentityDbContext<User>
    {
        //public BookingHotelContext()
        //{
        //}

        public BookingHotelContext(DbContextOptions<BookingHotelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Branch>  Branches { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Room>  Rooms { get; set; }
        public virtual DbSet<Booking>  Bookings { get; set; }
        public virtual DbSet<LookUp>  LookUps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-GQ7HU3D\SQLEXPRESS; Database=BookingHotel; " +
                //    "Persist Security Info=True;User ID=sa;Password=abobakr");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            //modelBuilder.Entity<Excelproducts>().HasQueryFilter(ep => ep.EpDisablePrInapp != CGlobal.DisableProductInapp.DisableProductInapp.GetHashCode());
            //modelBuilder.Entity<Market>().HasQueryFilter(market => market.MarketDisable != CGlobal.MarketDisabled.Disabled.GetHashCode());

            modelBuilder.Entity<Hotel>().HasData(new Hotel { Id = 1, Name = "Helton" });
            modelBuilder.Entity<Hotel>().HasData(new Hotel { Id = 2, Name = "ElTahrir" });
            modelBuilder.Entity<Branch>().HasData(new Branch { Id = 1, Name = "Prim Branch", HotelId = 1 });
            modelBuilder.Entity<Branch>().HasData(new Branch { Id = 2, Name = "secondary Branch", HotelId = 1 });
            modelBuilder.Entity<Branch>().HasData(new Branch { Id = 3, Name = "Prim Branch", HotelId = 2 });
            modelBuilder.Entity<Branch>().HasData(new Branch { Id = 4, Name = "secondary Branch", HotelId = 2 });

        }

    }
    }
