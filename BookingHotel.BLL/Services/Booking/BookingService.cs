using BookingHotel.BLL.Intrefaces;
using BookingHotel.BLL.Intrefaces.Booking;
using BookingHotel.BLL.Models.Book;
using BookingHotel.DAL.Data;
using BookingHotel.DAL.Entities;
using BookingHotel.DAL.Queries;
using BookingHotel.DAL.Queries.Book;
using BookingHotel.DAL.Queries.Room;
using BookingHotel.DAL.Repository;
using BookingHotel.DAL.Repository.Base;
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
        private readonly IRepositoryBase<User> _userRepository;
        private readonly IRepositoryBase<BookingHotel.DAL.Entities.Hotel> _hotelRepository;
        private readonly IRepositoryBase<BookingHotel.DAL.Entities.Booking> _bookigRepository;
        private readonly IRepositoryBase<BookingHotel.DAL.Entities.Room> _roomRepository;
        private readonly IUserQuery userQuery;
        private readonly IBookingQuery bookingQuery;
        private readonly IRoomQuery roomQuery;
        private readonly BookingHotelContext _context;

        public BookingService(IRepositoryBase<User>  userUepository,
            IRepositoryBase<BookingHotel.DAL.Entities.Booking> bookigRepository ,
            IRepositoryBase<BookingHotel.DAL.Entities.Room> roomRepository , IUserQuery userQuery,
            IBookingQuery bookingQuery , IRoomQuery roomQuery ,
            IRepositoryBase<BookingHotel.DAL.Entities.Hotel> hotelRepository,
            BookingHotelContext context)
        {
            _context = context;
            _userRepository = userUepository;
            _bookigRepository = bookigRepository;
            _roomRepository = roomRepository;
            _hotelRepository = hotelRepository;
            this.userQuery = userQuery;
            this.bookingQuery = bookingQuery;
            this.roomQuery = roomQuery;
        }
        public async Task<BookingModel> Book(BookingArguments arguments)
        {
            User user = await CheckIfUserExistAndIntializeIt(arguments);
            await _userRepository.SaveAsync(user, true);

            var userBookBeforeTime = bookingQuery.GetBookingByUserId(user.Id);
            var newBooking = new BookingHotel.DAL.Entities.Booking
            {
                UserId = user.Id,
                CheckInDate = arguments.CheckIn,
                CheckOutDate = arguments.CheckOut
            };
            await _bookigRepository.SaveAsync(newBooking, true);

            var rooms =await roomQuery.GetRoomsById(arguments.RoomsId , false);
            rooms.ForEach(room => room.BookingId = newBooking.Id);
            await _roomRepository.UpdateRange(rooms);

            var hotel = await _hotelRepository.GetByIdAsync(arguments.HotelId);
            var roomcost = _context.LookUps.Where(x => x.Id == rooms.Select(x => x.Id).First()).Select(x => x.Cost).FirstOrDefault();
            return new BookingModel()
            {
                Email = user.Email,
                Hotel = new Models.Hotel.HotelModel { Id = hotel.Id, Name = hotel.Name },
                Token = GetToken(new TokenModel { UserId = user.Id }),
                Rooms = rooms.Select(x => x.Id).ToList(),
                Cost = userBookBeforeTime != null ? (rooms.Count * roomcost) * .05 : (rooms.Count * roomcost)
            };
        }

        private async Task<User> CheckIfUserExistAndIntializeIt(BookingArguments arguments)
        {
            var user = await userQuery.GetUserByEmail(arguments.Email, arguments.NationalId);
            if (user == null)
            {
                user = new User
                {
                    Email = arguments.Email,
                    PhoneNumber = arguments.PhoneNumber,
                    NationalId = arguments.NationalId,
                    PasswordHash = arguments.Password
                };
            }
            else
            {
                user.PhoneNumber = arguments.PhoneNumber;
                user.PasswordHash = arguments.Password;
            }

            return user;
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

        public async Task CancelBooking(int BookingId)
        {
            var booking = await _bookigRepository.GetByIdAsync(BookingId);
            if (booking == null)
                throw new Exception("booking not found");
            else
            {
                await _bookigRepository.DeleteAsync(booking);
               var rooms = await roomQuery.GetRoomsByBookingId(BookingId ,true);
                rooms.ForEach(room => room.BookingId = null);
                await _roomRepository.UpdateRange(rooms);
            }
        }

        public async Task UpdateBooking(int Id, int HotelId, int BranchId, List<int> RoomsId , DateTime CheckIn , DateTime CheckOut)
        {
            var booking = await _bookigRepository.GetByIdAsync(Id);
            if (booking == null)
                throw new Exception("Not Found");
            booking.CheckInDate = CheckIn;
            booking.CheckOutDate = CheckOut;

            await _bookigRepository.Update(booking);
            var rooms = await roomQuery.GetRoomsByBookingId(Id, true);
            var deltedRooms = from item in rooms
                        where !RoomsId.Contains(item.Id)
                        select item;

            var roomsWillAdd = await roomQuery.GetRoomsById(RoomsId.ToList() , true);
            var updated = roomsWillAdd.Select(e => {
                var ret = e;
                e.HotelId = HotelId;
                e.BranchId = BranchId;
                e.BookingId = Id;
                return e;
            });
            await _roomRepository.UpdateRange(updated);
        }
    }
}
