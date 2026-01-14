using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Domain.Enums;
using First.EmailReminder.Domain.Common;

namespace First.EmailReminder.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public Role Role { get; set; }
        public ICollection<ReminderRule> ReminderRules { get; set; } = [];
    }
}