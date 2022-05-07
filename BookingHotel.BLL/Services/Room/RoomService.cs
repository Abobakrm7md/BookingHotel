using BookingHotel.BLL.Intrefaces;
using BookingHotel.BLL.Models.Room;
using BookingHotel.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel.BLL.Services.Room
{
    public class RoomService : IRoomService
    {
        private readonly BookingHotelContext _context;

        public RoomService(BookingHotelContext context)
        {
            this._context = context;
        }

        public async Task<List<RoomModel>> GetRooms(int HotelId, int BranchId, int RoomType)
        {
            return await _context.Rooms.Where(x=>x.HotelId == HotelId && x.BranchId == BranchId && x.Type == RoomType)
                .Select(r=> new RoomModel { Id = r.Id}).ToListAsync();
        }

        public async Task<List<RoomTypeModel>> GetRoomTypes()
        {
            return await _context.LookUps.Select(x => new RoomTypeModel { Id = x.Id, Type = x.Name }).ToListAsync();
        }
    }
}
