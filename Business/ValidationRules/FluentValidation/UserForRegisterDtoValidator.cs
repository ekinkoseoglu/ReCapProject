using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserForRegisterDtoValidator:AbstractValidator<UserForRegisterDto>
    {
        public UserForRegisterDtoValidator()
        {
            RuleFor(u => u.Password)
                .Cascade(CascadeMode.Continue)
                .NotEmpty()
                .Matches(@"[A-Z]+").WithMessage("Your Password must contain at least one uppercase letter. (A-Z)")
                .Matches(@"[0-9]+").WithMessage("Your Password must contain at least one number. (1-9)")
                .Matches(@"[@\!\?\*\.]+").WithMessage("Your Password must contain at least one special character. (@, !, ?, *, .)");
        }
       
    }
}
