using BookingHotel.api.Application.Request;
using BookingHotel.BLL.Intrefaces.Booking;
using BookingHotel.BLL.Models.Book;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BookingHotel.api.Application.CommandHandler
{
    public class BookingReqeustCommandHandler : IRequestHandler<BookingRequest, BookingModel>
    {
        private readonly IBookingService _bookingService;

        public BookingReqeustCommandHandler(IBookingService bookingService)
        {
            this._bookingService = bookingService;
        }
        public async Task<BookingModel> Handle(BookingRequest request, CancellationToken cancellationToken)
        {
            var bookingData = await _bookingService.Book(request);
            return bookingData;
        }
    }
}
