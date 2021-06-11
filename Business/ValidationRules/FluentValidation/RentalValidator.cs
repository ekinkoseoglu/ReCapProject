using Entities.Concrete;
using FluentValidation;
using System;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotEmpty();
            RuleFor(r => r.CustomerId).NotEmpty();
            RuleFor(r => r.RentDate)
                .Cascade(CascadeMode.Continue)
                .Must(BeValidDate).WithMessage("Invalid Date Of Rent")
                .NotEmpty();
        }

        protected bool BeValidDate(DateTime date)
        {
            int CurrentYear = DateTime.Now.Year;
            int DateOfRentYear = date.Year;

            if (DateOfRentYear <= CurrentYear && DateOfRentYear > (CurrentYear - 120))
            {
                return true;
            }

            return false;
        }

    }
}
