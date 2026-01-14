using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace First.EmailReminder.Application.Features.User.Commands
{
    public class AuthUserCommandValidator : AbstractValidator<AuthUserCommand>
    {
        public AuthUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email is required.");

            RuleFor(x => x.PasswordHash)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}