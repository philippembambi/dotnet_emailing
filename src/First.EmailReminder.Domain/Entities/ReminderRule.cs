using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Domain.Enums;
using First.EmailReminder.Domain.Common;

namespace First.EmailReminder.Domain.Entities
{
    public class ReminderRule : BaseEntity
    {
        public string SqlQuery { get; set; } = string.Empty;
        public Periodicity Periodicity { get; set; }
        public int PeriodicityValue { get; set; }
        public string SubjectTemplate { get; set; } = string.Empty;
        public string BodyTemplate { get; set; } = string.Empty;
        public string RecipientTemplate { get; set; } = string.Empty; // Clob type
        public ReminderRuleStatus Status { get; set; }
        public DateTime NextRunAt { get; set; }
        public int UserId { get; set; }
        public User? User{ get; set; }
        public ICollection<Email> Emails { get; set; } = [];

        public void ScheduleNextRun()
        {
            NextRunAt = Periodicity switch
            {
                Periodicity.Minute => NextRunAt.AddMinutes(PeriodicityValue),
                Periodicity.Hour => NextRunAt.AddHours(PeriodicityValue),
                Periodicity.Day => NextRunAt.AddDays(PeriodicityValue),
                Periodicity.Week => NextRunAt.AddDays(7 * PeriodicityValue),
                Periodicity.Month => NextRunAt.AddMonths(PeriodicityValue),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        public void Activate()
        {
            Status = ReminderRuleStatus.Active;
        }
        public void Deactivate()
        {
            Status = ReminderRuleStatus.Inactive;
        }
        public bool IsActive()
        {
            return Status == ReminderRuleStatus.Active;
        }
        public bool IsDue(DateTime currentTime)
        {
            return IsActive() && NextRunAt <= currentTime;
        }
        public bool IsInactive()
        {
            return Status == ReminderRuleStatus.Inactive;
        }
        public bool IsReadOnlyQuery()
        {
            var trimmedQuery = SqlQuery.Trim().ToUpperInvariant();
            return trimmedQuery.StartsWith("SELECT");
        }
        public void UpdateNextRunAt(DateTime fromTime)
        {
            NextRunAt = fromTime;
            ScheduleNextRun();
        }
        public bool IsDeterministic()
        {
            var nonDeterministicFunctions = new List<string>
            {
                "RAND(",
                "NEWID(",
                "GETDATE(",
                "SYSDATETIME(",
                "CURRENT_TIMESTAMP"
            };
            var upperQuery = SqlQuery.ToUpperInvariant();
            return !nonDeterministicFunctions.Any(func => upperQuery.Contains(func));
        }
        public bool ContainsForbiddenKeywords()
        {
            var forbiddenKeywords = new List<string>
            {
                "INSERT",
                "UPDATE",
                "DELETE",
                "DROP",
                "ALTER",
                "TRUNCATE",
                "CREATE",
                "--",
                "/* */"
            };

            var upperQuery = SqlQuery.ToUpperInvariant();
            return forbiddenKeywords.Any(keyword => upperQuery.Contains(keyword));
        }
        public void ValidateQuery()
        {
            if (!IsReadOnlyQuery())
            {
                throw new InvalidOperationException("The SQL query must be read-only (SELECT statement).");
            }

            if (!IsDeterministic())
            {
                throw new InvalidOperationException("The SQL query must be deterministic and not use non-deterministic functions.");
            }

            if (ContainsForbiddenKeywords())
            {
                throw new InvalidOperationException("The SQL query contains forbidden keywords that may modify the database.");
            }
        }
        public bool HasValidTemplates()
        {
            return !string.IsNullOrWhiteSpace(SubjectTemplate) &&
                   !string.IsNullOrWhiteSpace(BodyTemplate) &&
                   !string.IsNullOrWhiteSpace(RecipientTemplate);
        }
        public bool HasValidPlaceholders()
        {
            var requiredPlaceholders = new List<string> { "{{Recipient}}", "{{Subject}}", "{{Body}}" };

            return requiredPlaceholders.All(placeholder =>
                SubjectTemplate.Contains(placeholder) ||
                BodyTemplate.Contains(placeholder) ||
                RecipientTemplate.Contains(placeholder));
        }
        public bool IsSafeContent()
        {
            var unsafePatterns = new List<string>
            {
                "<script",
                "javascript:",
                "onerror=",
                "onload="
            };

            var combinedTemplates = SubjectTemplate + BodyTemplate + RecipientTemplate;
            var upperContent = combinedTemplates.ToUpperInvariant();

            return !unsafePatterns.Any(pattern => upperContent.Contains(pattern.ToUpperInvariant()));
        }

        public void ValidateTemplates()
        {
            if (!HasValidTemplates())
            {
                throw new InvalidOperationException("One or more templates are invalid or empty.");
            }

            if (!HasValidPlaceholders())
            {
                throw new InvalidOperationException("One or more templates are missing required placeholders.");
            }

            if (!IsSafeContent())
            {
                throw new InvalidOperationException("One or more templates contain unsafe content.");
            }
        }
    }
}