using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Domain.Enums;

namespace First.EmailReminder.Application.Dto
{
    public class CreateEmailDto
    {
        public int Id { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Recipient { get; set; } = string.Empty;
        public RecipientType RecipientType { get; set; }
        public int ReminderRuleId { get; set; }
    }
}