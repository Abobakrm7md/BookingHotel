using BookingHotel.BLL.Models.Book;
using MediatR;
using System.Collections.Generic;

namespace BookingHotel.api.Application.Request
{
    public class BookingRequest : BookingArguments,IRequest<BookingModel>
    {
       
    }
}
