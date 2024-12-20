using System;
using FluentValidation;

namespace Hotel_Reservation.Models.Validation;

public class RoomAmenityValidator : AbstractValidator<RoomAmenity>
{
    public RoomAmenityValidator()
    {
        RuleFor(p => p.RoomId)
            .Must(p => p > 0).WithMessage("Room can't be empty");

        RuleFor(p => p.AmenityId)
            .Must(p => p > 0).WithMessage("Amenity can't be empty");
        
        RuleFor(p => p.Quantity)
            .NotEmpty().WithMessage("Quantity can't be empty")
            .Must(p => p > 0).WithMessage("Quantity must be greater than 0");

    }
}
