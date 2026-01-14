using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using First.EmailReminder.Domain.Entities;
using First.EmailReminder.Application.Dto;

namespace First.EmailReminder.Application.Features.ReminderRule.Queries
{
    public record GetActiveReminderRulesQuery : IRequest<List<ReminderRuleDto>>;
}