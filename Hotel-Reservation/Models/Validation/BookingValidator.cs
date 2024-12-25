using System;
using FluentValidation;

namespace Hotel_Reservation.Models.Validation;

public class BookingValidator : AbstractValidator<Booking>
{
    public BookingValidator()
    {
        RuleFor(p => p.CheckIn)
            .NotEmpty().WithMessage("Check In Date can't be empty")
            .Must((checkIn) => checkIn > DateOnly.FromDateTime(DateTime.UtcNow)).WithMessage("Check In Date must be in the future");

        RuleFor(p => p.CheckOut)
            .NotEmpty().WithMessage("Check Out Date can't be empty")
            .Must((booking, checkOut) => checkOut > booking.CheckIn).WithMessage("Check Out Date must be after Check In Date");

        RuleFor(p => p.RoomId)
            .Must((roomId) => roomId > 0).WithMessage("Room can't be empty");

        RuleFor(p => p.GuestId)
            .NotEmpty().WithMessage("Guest can't be empty");

        ClassLevelCascadeMode = CascadeMode.Stop;
    }
}
