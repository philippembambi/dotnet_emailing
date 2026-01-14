using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Application.Dto;
using MediatR;

namespace First.EmailReminder.Application.Features.User.Queries
{
    public record GetUsersQuery : IRequest<List<UserDto>>;
}