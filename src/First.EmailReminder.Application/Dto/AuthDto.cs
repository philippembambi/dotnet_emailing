using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.EmailReminder.Application.Dto
{
    public class AuthDto
    {
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}