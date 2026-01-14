using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Application.Dto;
using First.EmailReminder.Domain.Enums;
using MediatR;

namespace First.EmailReminder.Application.Features.Email.Commands
{
    public class CreateEmailCommand : IRequest<EmailDto>
    {
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Recipient { get; set; } = string.Empty;
        public RecipientType RecipientType { get; set; }
        public EmailStatus Status { get; set; }
        public int ReminderRuleId { get; set; }
    }
}