using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using First.EmailReminder.Domain.Common;
using FluentValidation;

namespace First.EmailReminder.Application.Features.ReminderRule.Commands
{
    public class CreateReminderRuleCommandValidator : AbstractValidator<CreateReminderRuleCommand>
    {
        public CreateReminderRuleCommandValidator()
        {
            RuleFor(x => x.SqlQuery)
                .NotEmpty().WithMessage("Query is required.")
                .MaximumLength(100).WithMessage("Query cannot exceed 100 characters.");

            RuleFor(x => x.SubjectTemplate)
                .MaximumLength(500).WithMessage("Subject template cannot exceed 500 characters.")
                .Must(ContainsOnlyAllowedPlaceholders).WithMessage("Subjet can only contain allowed placeholders.");

            RuleFor(x => x.BodyTemplate)
                .MaximumLength(1000).WithMessage("Body template cannot exceed 1000 characters.")
                .Must(ContainsOnlyAllowedPlaceholders).WithMessage("Body can only contain allowed placeholders.");

            RuleFor(x => x.Periodicity)
                .IsInEnum().WithMessage("Periodicity must be a valid enum value.");

            RuleFor(x => x.PeriodicityValue)
                .GreaterThan(0).WithMessage("Periodicity value must be greater than zero.");

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be a valid positive integer.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Status must be a valid enum value.");
        }

        private bool ContainsOnlyAllowedPlaceholders(string template)
        {
            var matches = Regex.Matches(template, @"\{.*?\}");
            return matches.Select(m => m.Value)
                    .All(p => TemplatePlaceholder.All.Contains(p));
        }
    }
}