using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using First.EmailReminder.Application.Dto;
using First.EmailReminder.Application.Features.ReminderRule.Queries;
using First.EmailReminder.Application.Interfaces;
using MediatR;

namespace First.EmailReminder.Application.Features.ReminderRule.Handlers
{
    public class GetReminderRulesHandler : IRequestHandler<GetReminderRulesQuery, List<ReminderRuleDto>>
    {
        public readonly IReminderRuleRepository _reminderRuleRepository;
        public readonly IMapper _mapper;

        public GetReminderRulesHandler(IReminderRuleRepository reminderRuleRepository, IMapper mapper)
        {
            _reminderRuleRepository = reminderRuleRepository;
            _mapper = mapper;
        }
        public async Task<List<ReminderRuleDto>> Handle(GetReminderRulesQuery request, CancellationToken cancellationToken)
        {
            var reminderRules = await _reminderRuleRepository.GetAllAsync();
            return _mapper.Map<List<ReminderRuleDto>>(reminderRules);
        }
    }
}