using BookingHotel.BLL.Intrefaces;
using BookingHotel.BLL.Intrefaces.Booking;
using BookingHotel.BLL.Models.Book;
using BookingHotel.DAL.Data;
using BookingHotel.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel.BLL.Services.Booking
{
    public class BookingService : IBookingService
    {
        private readonly BookingHotelContext _context;

        public BookingService(BookingHotelContext context)
        {
            this._context = context;
        }
        public async Task<BookingModel> Book(BookingArguments arguments)
        {
            var userData = new User
            {
                Email = arguments.Email,
                PhoneNumber = arguments.PhoneNumber,
                NationalId = arguments.NationalId,
                PasswordHash = arguments.Password
            };
            _context.Users.Add(userData);

            var newBooking = new BookingHotel.DAL.Entities.Booking
            {
                UserId = userData.Id,
                CheckInDate = arguments.CheckIn,
                CheckOutDate = arguments.CheckOut
            };
            _context.Bookings.Add(newBooking);
            await _context.SaveChangesAsync();

            var rooms = _context.Rooms.Where(x => arguments.RoomsId.Any(c => c == x.Id)).ToList();
            rooms.ForEach(room => room.BookingId = newBooking.Id);
            _context.UpdateRange(rooms);
           await _context.SaveChangesAsync();

            var hotel = _context.Hotels.FirstOrDefault(x=>x.Id == arguments.HotelId);
            var roomcost = _context.LookUps.Where(x => x.Id == rooms.Select(x => x.Id).First()).Select(x => x.Cost).FirstOrDefault();
            return new  BookingModel()
            {
                Email = userData.Email,
                Hotel = new Models.Hotel.HotelModel { Id = hotel.Id,Name = hotel.Name},
                Token =  GetToken(new TokenModel { UserId = userData.Id }),
                Rooms = rooms.Select(x=>x.Id).ToList(),
                Cost = rooms.Count * roomcost
            };
        }
        public string GetToken(TokenModel tokenModel)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("my-32-character-ultra-secure-and-ultra-long-secret");

            SecurityTokenDescriptor tokenDescriptor = CreateTokenDescrptor(tokenModel, key);
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            string finalToken = tokenHandler.WriteToken(token);
            return finalToken;
        }
        private static SecurityTokenDescriptor CreateTokenDescrptor(TokenModel tokenModel, byte[] key)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, tokenModel.UserId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenDescriptor;
        }
    }
}
