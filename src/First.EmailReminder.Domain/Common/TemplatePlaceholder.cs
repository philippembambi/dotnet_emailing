using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.EmailReminder.Domain.Common
{
    public static class TemplatePlaceholder
    {
        public const string Name = "{name}";
        public const string Email = "{email}";
        public const string Date = "{date}";
        public static readonly IReadOnlyList<string> All = new[] {Name, Email, Date};
    }
}