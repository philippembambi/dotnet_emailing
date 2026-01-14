using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace First.EmailReminder.Application.Features.Email.Commands
{
    public class CreateEmailCommandValidator : AbstractValidator<CreateEmailCommand>
    {
        public CreateEmailCommandValidator()
        {
            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Subject is required.")
                .MaximumLength(200).WithMessage("Subject cannot exceed 200 characters.");

            RuleFor(x => x.Body)
                .NotEmpty().WithMessage("Body is required.")
                .MaximumLength(2000).WithMessage("Body cannot exceed 2000 characters.");

            RuleFor(x => x.Recipient)
                .NotEmpty().WithMessage("Recipient is required.")
                .EmailAddress().WithMessage("Recipient must be a valid email address.")
                .MaximumLength(500).WithMessage("Recipient cannot exceed 500 characters.");

            RuleFor(x => x.RecipientType)
                .IsInEnum().WithMessage("RecipientType must be a valid enum value.");

            RuleFor(x => x.ReminderRuleId)
                .GreaterThan(0).WithMessage("ReminderRuleId must be a valid positive integer.");
        }
    }
}