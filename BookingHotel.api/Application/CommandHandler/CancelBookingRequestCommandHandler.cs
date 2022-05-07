using BookingHotel.api.Application.Request;
using BookingHotel.BLL.Intrefaces.Booking;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BookingHotel.api.Application.CommandHandler
{
    public class CancelBookingRequestCommandHandler : IRequestHandler<CancelBookingRequest>
    {
        private readonly IBookingService _bookingService;
        public CancelBookingRequestCommandHandler(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        public Task<Unit> Handle(CancelBookingRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
