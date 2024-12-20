using FluentValidation;
using Hotel_Reservation.Data.Interface;
using Microsoft.Extensions.Localization;

namespace Hotel_Reservation.Models.Validation;

public class GuestValidator : AbstractValidator<Guest>
{
    public GuestValidator(IUnitOfWork _unit)
    {
        RuleFor(p => p.Ssn)
            .NotEmpty().WithMessage("SSN can't be empty")
            .Matches("^[0-9]+$").WithMessage("SSN must be digits")
            .MustAsync(async (ssn, cancellation) => !await _unit.GuestRepository.IsExists(ssn)).WithMessage("The SSN has been registered before");

        RuleFor(p => p.FName)
            .NotEmpty().WithMessage("First Name can't be empty")
            .Length(3, 50).WithMessage("First Name Length({TotalLength}) must be between 3 and 50");

        RuleFor(p => p.LName)
            .NotEmpty().WithMessage("Last Name can't be empty")
            .Length(3, 50).WithMessage("Last Name Length({TotalLength}) must be between 3 and 50");

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("Email can't be empty")
            .EmailAddress().WithMessage("{PropertyValue} is not a valid email address")
            .MustAsync(async (email, cancellation) => !await _unit.GuestRepository.IsEmailExists(email)).WithMessage("The email ({PropertyValue}) has been registered");

        RuleFor(p => p.ContactNumber)
            .NotEmpty().WithMessage("Contact Number can't be empty")
            .Must(ValidationUtils.ValidMobile!).WithMessage("Not a valid number");


        ClassLevelCascadeMode = CascadeMode.Stop;
    }
}
