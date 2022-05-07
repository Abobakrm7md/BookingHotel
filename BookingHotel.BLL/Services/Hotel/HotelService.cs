using BookingHotel.BLL.Intrefaces;
using BookingHotel.BLL.Models;
using BookingHotel.BLL.Models.Hotel;
using BookingHotel.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel.BLL.Services.Hotel
{
    public class HotelService : IHotelService
    {
        private readonly BookingHotelContext _context;
        public HotelService(BookingHotelContext context)
        {
            _context = context;
        }

        public async Task<List<BranchModel>> GetBranches(int HotelId)
        {
            var branches = await _context.Branches.Where(x => x.HotelId == HotelId).Select(x => new BranchModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
            return branches;
        }

        public async Task<List<HotelModel>> GetHotels()
        {
            var hotels = await( _context.Hotels.Select(x => 
                new HotelModel
                {
                Id = x.Id,
                Name = x.Name,
            })).ToListAsync();
            return hotels;
        }
    }
}
