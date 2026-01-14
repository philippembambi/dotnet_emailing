using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Domain.Entities;
using First.EmailReminder.Domain.Enums;

namespace First.EmailReminder.Application.Dto
{
    public class ReminderRuleDto
    {
        public int Id { get; set; }
        public string SqlQuery { get; set; } = string.Empty;
        public Periodicity Periodicity { get; set; }
        public int PeriodicityValue { get; set; }
        public string SubjectTemplate { get; set; } = string.Empty;
        public string BodyTemplate { get; set; } = string.Empty;
        public string RecipientTemplate { get; set; } = string.Empty;
        public ReminderRuleStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime NextRunAt { get; set; }
        public User? User { get; set; }
    }
}