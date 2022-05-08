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
            modelBuilder.Entity<Room>().HasQueryFilter(x=>x.BookingId == null);
            SeedData(modelBuilder);

        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(new Hotel { Id = 1, Name = "Helton" });
            modelBuilder.Entity<Hotel>().HasData(new Hotel { Id = 2, Name = "ElTahrir" });
            modelBuilder.Entity<Branch>().HasData(new Branch { Id = 1, Name = "Prim Branch", HotelId = 1 });
            modelBuilder.Entity<Branch>().HasData(new Branch { Id = 2, Name = "secondary Branch", HotelId = 1 });
            modelBuilder.Entity<Branch>().HasData(new Branch { Id = 3, Name = "Prim Branch", HotelId = 2 });
            modelBuilder.Entity<Branch>().HasData(new Branch { Id = 4, Name = "secondary Branch", HotelId = 2 });
            modelBuilder.Entity<LookUp>().HasData(new LookUp { Id = 1, Name = "Single", Cost = 50 });
            modelBuilder.Entity<LookUp>().HasData(new LookUp { Id = 2, Name = "double", Cost = 30 });
            modelBuilder.Entity<LookUp>().HasData(new LookUp { Id = 3, Name = "Suit", Cost = 150 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 1, HotelId = 1, Type = 1, BranchId = 1 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 2, HotelId = 1, Type = 2, BranchId = 1 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 3, HotelId = 1, Type = 3, BranchId = 1 });

            modelBuilder.Entity<Room>().HasData(new Room { Id = 4, HotelId = 1, Type = 1, BranchId = 2 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 5, HotelId = 1, Type = 2, BranchId = 2 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 6, HotelId = 1, Type = 3, BranchId = 2 });

            modelBuilder.Entity<Room>().HasData(new Room { Id = 7, HotelId = 2, Type = 1, BranchId = 3 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 8, HotelId = 2, Type = 2, BranchId = 3 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 9, HotelId = 2, Type = 3, BranchId = 3 });

            modelBuilder.Entity<Room>().HasData(new Room { Id = 10, HotelId = 2, Type = 1, BranchId = 4 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 11, HotelId = 2, Type = 2, BranchId = 4 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 12, HotelId = 2, Type = 3, BranchId = 4 });

            modelBuilder.Entity<Room>().HasData(new Room { Id = 13, HotelId = 1, Type = 1, BranchId = 1 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 14, HotelId = 1, Type = 2, BranchId = 1 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 15, HotelId = 1, Type = 3, BranchId = 1 });

            modelBuilder.Entity<Room>().HasData(new Room { Id = 16, HotelId = 1, Type = 1, BranchId = 2 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 17, HotelId = 1, Type = 2, BranchId = 2 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 18, HotelId = 1, Type = 3, BranchId = 2 });

            modelBuilder.Entity<Room>().HasData(new Room { Id = 19, HotelId = 2, Type = 1, BranchId = 3 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 20, HotelId = 2, Type = 2, BranchId = 3 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 21, HotelId = 2, Type = 3, BranchId = 3 });

            modelBuilder.Entity<Room>().HasData(new Room { Id = 22, HotelId = 2, Type = 1, BranchId = 4 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 23, HotelId = 2, Type = 2, BranchId = 4 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 24, HotelId = 2, Type = 3, BranchId = 4 });
        }
    }
    }
