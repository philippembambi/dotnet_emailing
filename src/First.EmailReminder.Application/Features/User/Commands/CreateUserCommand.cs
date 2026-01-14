using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Application.Dto;
using First.EmailReminder.Domain.Enums;
using MediatR;

namespace First.EmailReminder.Application.Features.User.Commands
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public Role Role { get; set; }
    }
}