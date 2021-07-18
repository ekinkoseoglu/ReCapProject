using Backbone.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MinimumLength(2);


            RuleFor(u => u.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MinimumLength(2);


            RuleFor(u => u.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Must(Contain).WithMessage("Your Mail address must Contain '@' character")
                .EmailAddress();


            //RuleFor(u => u.UserPassword)
            //    .Cascade(CascadeMode.Continue)
            //    .NotEmpty()
            //    .Matches(@"[A-Z]+").WithMessage("Your Password must contain at least one uppercase letter. (A-Z)")
            //    .Matches(@"[0-9]+").WithMessage("Your Password must contain at least one number. (1-9)")
            //    .Matches(@"[@\!\?\*\.]+").WithMessage("Your Password must contain at least one special character. (@, !, ?, *, .)");

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
