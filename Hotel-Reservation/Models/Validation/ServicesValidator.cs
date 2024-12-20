using System;
using FluentValidation;

namespace Hotel_Reservation.Models.Validation;

public class ServicesValidator : AbstractValidator<Service>
{
    public ServicesValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Name can't be empty")
            .Length(3, 50).WithMessage("Name Length({TotalLength}) must be between 3 and 50");

        RuleFor(p => p.Description)
            .MaximumLength(999).WithMessage("Description Length({TotalLength}) must be less than 1000");

        RuleFor(p => p.Price)
            .NotEmpty().WithMessage("Price can't be empty")
            .Must(p => p > 0).WithMessage("Price must be greater than 0");

    }
}
