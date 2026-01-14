using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using First.EmailReminder.Application.Dto;
using First.EmailReminder.Application.Features.User.Commands;
using First.EmailReminder.Domain.Entities;
using MediatR;

namespace First.EmailReminder.Application.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<CreateUserCommand, User>();
            CreateMap<User, UserDto>();
        }
    }
}