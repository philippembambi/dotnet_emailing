using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using First.EmailReminder.Application.Dto;
using First.EmailReminder.Application.Features.Email.Commands;
using First.EmailReminder.Domain.Entities;

namespace First.EmailReminder.Application.Mapping
{
    public class EmailProfile : Profile
    {
        public EmailProfile()
        {
            CreateMap<CreateEmailDto, Email>();
            CreateMap<CreateEmailCommand, Email>();
            CreateMap<UpdateEmailStatusCommand, Email>();
            CreateMap<Email, EmailDto>();
        }
    }
}