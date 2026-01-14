using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Domain.Enums;

namespace First.EmailReminder.Application.Dto
{
    public class UpdateEmailStatusDto
    {
        public int Id { get; set; }
        public EmailStatus Status { get; set; }
    }
}