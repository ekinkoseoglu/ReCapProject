using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).NotEmpty().WithMessage("Car Name Cannot Be Empty");
            RuleFor(c => c.CarName).MinimumLength(2).WithMessage("Car Name must be at least 2 character");
            RuleFor(c => c.DailyPrice).NotEmpty().WithMessage("Daily Price Cannot Be Empty");
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(10).WithMessage("Car Price Must be greater than 10 $");
            RuleFor(c => c.ModelYear).NotEmpty().WithMessage("Model Year Cannot Be Empty");
            RuleFor(c => c.ColorId).NotEmpty().WithMessage("Color ID Cannot Be Empty");
            RuleFor(c => c.BrandId).NotEmpty().WithMessage("Brand ID Cannot Be Empty");
            RuleFor(c => c.Description).NotEmpty().WithMessage("Car Descriptionu Cannot Be Empty");
            RuleFor(c => c.Description).MinimumLength(5).WithMessage("Car Description must be at least 5 character");
        }
    }
}
