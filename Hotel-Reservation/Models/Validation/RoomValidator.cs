using System;
using FluentValidation;

namespace Hotel_Reservation.Models.Validation;

public class RoomValidator : AbstractValidator<Room>
{
    public RoomValidator()
    {
        RuleFor(p => p.RoomNumber)
            .NotEmpty().WithMessage("Room Number can't be empty")
            .Length(2, 10).WithMessage("Room Number Length({TotalLength}) must be between 2 and 10")
            .Matches("^[a-zA-Z0-9]*$").WithMessage("Room Number can only contain letters and digits");

        RuleFor(p => p.RoomTypeId)
            .Must(p => p > 0).WithMessage("Room Type can't be empty");
        
        RuleFor(p => p.PricePerNight)
            .NotEmpty().WithMessage("Price can't be empty")
            .Must(p => p > 0).WithMessage("Price must be greater than 0");
        
        RuleFor(p => p.Capacity)
            .NotEmpty().WithMessage("Capacity can't be empty")
            .Must(p => p > 0).WithMessage("Capacity must be greater than 0");
        
        RuleFor(p => p.Location)
            .NotEmpty().WithMessage("Location can't be empty")
            .Length(3, 50).WithMessage("Location Length({TotalLength}) must be between 3 and 50");
        
        RuleFor(p => p.Description)
            .MaximumLength(999).WithMessage("Description Length({TotalLength}) must be less than 1000");
        
        RuleFor(p => p.Availability)
            .Must(p => p == true || p == false).WithMessage("Availability must be true or false");

    }
}

