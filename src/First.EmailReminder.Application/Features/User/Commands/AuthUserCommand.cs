using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Application.Dto;
using MediatR;

namespace First.EmailReminder.Application.Features.User.Commands
{
    public class AuthUserCommand : IRequest<AuthDtoResponseDto>
    {
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}