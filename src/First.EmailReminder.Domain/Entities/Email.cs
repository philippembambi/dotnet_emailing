using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Domain.Enums;
using First.EmailReminder.Domain.Common;

namespace First.EmailReminder.Domain.Entities
{
    public class Email : BaseEntity
    {
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Recipient { get; set; } = string.Empty;
        public RecipientType RecipientType { get; set; }
        public EmailStatus Status { get; set; }
        public int AttemptCount { get; set; } = 0;
        public DateTime? SentAt { get; set; }
        public int ReminderRuleId {get; set;}
        public ReminderRule? ReminderRule { get; set; }

        public void MarkAsSent()
        {
            Status = EmailStatus.Sent;
            SentAt = DateTime.UtcNow;
        }
        public void MarkAsDeleted()
        {
            Status = EmailStatus.Failed;
        }
        public void MarkAsPending()
        {
            Status = EmailStatus.Pending;
        }
        public async Task<int> IncrementAttemptAsync()
        {
            return await Task.FromResult(++AttemptCount);
        }
    }
}