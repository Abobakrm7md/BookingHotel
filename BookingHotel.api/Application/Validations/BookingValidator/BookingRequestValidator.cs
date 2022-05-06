using BookingHotel.api.Application.Request;
using FluentValidation;

namespace BookingHotel.api.Application.Validations.BookingValidator
{
    public class BookingRequestValidator : AbstractValidator<BookingRequest>
    {
        public BookingRequestValidator()
        {
            RuleFor(x=>x.Email).NotEmpty().NotNull();
            RuleFor(x => x.PhoneNumber).NotEmpty().NotNull();
            RuleFor(x => x.HotelId).NotEmpty().NotNull();
            RuleFor(x => x.BranchId).NotEmpty().NotNull();
            RuleFor(x => x.RoomsId.Count > 0).NotEmpty().NotNull();
            RuleFor(x => x.Password).MinimumLength(6);
        }
    }
}
