using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Application.Dto;
using MediatR;

namespace First.EmailReminder.Application.Features.ReminderRule.Queries
{
    public record GetReminderRuleByIdQuery(int Id) : IRequest<ReminderRuleDto>;
}