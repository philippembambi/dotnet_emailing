using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Domain.Enums;
using First.EmailReminder.Domain.Entities;

namespace First.EmailReminder.Application.Dto
{
    public class EmailDto
    {
        public int Id { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Recipient { get; set; } = string.Empty;
        public RecipientType RecipientType { get; set; }
        public EmailStatus Status { get; set; }
        public int AttemptCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? SentAt { get; set; }
        public ReminderRule? ReminderRule { get; set; }
    }
}