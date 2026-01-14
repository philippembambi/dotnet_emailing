using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.EmailReminder.Application.Dto
{
    public class AuthDtoResponseDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}