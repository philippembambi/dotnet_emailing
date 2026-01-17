using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Application.Dto;
using First.EmailReminder.Domain.Enums;
using MediatR;

namespace First.EmailReminder.Application.Features.ReminderRule.Commands
{
    public class CreateReminderRuleCommand : IRequest<ReminderRuleDto>
    {
        public string SqlQuery { get; set; } = string.Empty;
        public Periodicity Periodicity { get; set; }
        public int PeriodicityValue { get; set; }
        public string SubjectTemplate { get; set; } = string.Empty;
        public string BodyTemplate { get; set; } = string.Empty;
        public ReminderRuleStatus Status { get; set; }
        public int UserId { get; set; }
    }
}