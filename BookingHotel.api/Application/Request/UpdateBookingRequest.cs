using MediatR;
using System;
using System.Collections.Generic;

namespace BookingHotel.api.Application.Request
{
    public class UpdateBookingRequest:IRequest
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int BranchId { get; set; }
        public List<int> RoomsId { get; set; }
        public DateTime  CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
