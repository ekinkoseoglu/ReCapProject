using Backbone.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            

            //RuleFor(u => u.UserPassword)
            //    .Cascade(CascadeMode.Continue)
            //    .NotEmpty()
            //    .Matches(@"[A-Z]+").WithMessage("Your Password must contain at least one uppercase letter. (A-Z)")
            //    .Matches(@"[0-9]+").WithMessage("Your Password must contain at least one number. (1-9)")
            //    .Matches(@"[@\!\?\*\.]+").WithMessage("Your Password must contain at least one special character. (@, !, ?, *, .)");

        }

       

    }
}
