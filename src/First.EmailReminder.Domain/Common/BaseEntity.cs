using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.EmailReminder.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}