using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Application.Dto;
using First.EmailReminder.Application.Features.ReminderRule.Queries;
using First.EmailReminder.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace First.EmailReminder.Application.Features.ReminderRule.Handlers
{
    public class GetActiveReminderRulesHandler : IRequestHandler<GetActiveReminderRulesQuery, List<ReminderRuleDto>>
    {
        public readonly IReminderRuleRepository _reminderRuleRepository;
        public readonly IMapper _mapper;

        public GetActiveReminderRulesHandler(IReminderRuleRepository reminderRuleRepository, IMapper mapper)
        {
            _reminderRuleRepository = reminderRuleRepository;
            _mapper = mapper;
        }

        public async Task<List<ReminderRuleDto>> Handle(GetActiveReminderRulesQuery request, CancellationToken cancellationToken)
        {
            var activeReminderRules = await _reminderRuleRepository.GetActiveRulesAllAsync();
            return _mapper.Map<List<ReminderRuleDto>>(activeReminderRules);
        }
    }
}