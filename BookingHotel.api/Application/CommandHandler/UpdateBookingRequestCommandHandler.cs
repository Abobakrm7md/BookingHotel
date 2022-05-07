using BookingHotel.api.Application.Request;
using BookingHotel.BLL.Intrefaces.Booking;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BookingHotel.api.Application.CommandHandler
{
    public class UpdateBookingRequestCommandHandler : IRequestHandler<UpdateBookingRequest>
    {
        private readonly IBookingService _bookingService;
        public UpdateBookingRequestCommandHandler(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        public async Task<Unit> Handle(UpdateBookingRequest request, CancellationToken cancellationToken)
        {
           await _bookingService.UpdateBooking(request.Id, request.HotelId, request.BranchId, request.RoomsId , request.CheckIn , request.CheckOut);
            return new Unit();
        }
    }
}
