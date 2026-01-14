using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using First.EmailReminder.Application.Dto;
using First.EmailReminder.Domain.Entities;
using First.EmailReminder.Application.Features.ReminderRule.Commands;

namespace First.EmailReminder.Application.Mapping
{
    public class ReminderRuleProfile : Profile
    {
        public ReminderRuleProfile()
        {
            CreateMap<ReminderRuleDto, ReminderRule>();
            CreateMap<CreateReminderRuleCommand, ReminderRule>();
            CreateMap<ReminderRule, ReminderRuleDto>();
        }
    }
}