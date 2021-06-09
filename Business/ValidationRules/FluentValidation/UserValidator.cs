using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).Must(Contain).WithMessage("Your Mail address must Contain '@' character");
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.UserPassword).NotEmpty();
            RuleFor(u => u.UserPassword).Matches(@"[A-Z]+")
                .WithMessage("Your Password must contain at least one uppercase letter. (A-Z)");
            RuleFor(u => u.UserPassword).Matches(@"[0-9]+")
                .WithMessage("Your Password must contain at least one number. (1-9)");
            RuleFor(u => u.UserPassword).Matches(@"[@\!\?\*\.]+")
                .WithMessage("Your Password must contain at least one special character. (@, !, ?, *, .)");

        }

        private bool Contain(string arg)
        {
            if (arg.Contains("@"))
            {
                return true;
            }

            return false;
        }
    }
}
