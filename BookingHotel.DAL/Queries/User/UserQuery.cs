using BookingHotel.DAL.Data;
using BookingHotel.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel.DAL.Queries
{
    public class UserQuery : IUserQuery
    {
        private readonly BookingHotelContext _context;
        public UserQuery(BookingHotelContext context)
        {
            _context= context;
        }
        public async Task<User> GetUserByEmail(string Email , long NationalId)
        {
           return await _context.Users.FirstOrDefaultAsync(x => x.Email == Email && x.NationalId == NationalId);
        }
    }
}
