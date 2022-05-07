using BookingHotel.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel.DAL.Queries
{
    public interface IUserQuery
    {
        Task<BookingHotel.DAL.Entities.User> GetUserByEmail(string Email , long NationalId);
    }
}
