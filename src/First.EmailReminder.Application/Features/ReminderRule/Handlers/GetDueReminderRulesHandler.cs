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
    public class GetDueReminderRulesHandler : IRequestHandler<GetDueReminderRulesQuery, List<ReminderRuleDto>>
    {
        public readonly IReminderRuleRepository _reminderRuleRepository;
        public readonly IMapper _mapper;

        public GetDueReminderRulesHandler(IReminderRuleRepository reminderRuleRepository, IMapper mapper)
        {
            _reminderRuleRepository = reminderRuleRepository;
            _mapper = mapper;
        }

        public async Task<List<ReminderRuleDto>> Handle(GetDueReminderRulesQuery request, CancellationToken cancellationToken)
        {
            var dueReminderRules = await _reminderRuleRepository.GetDueRulesAllAsync(DateTime.UtcNow, cancellationToken);
            return _mapper.Map<List<ReminderRuleDto>>(dueReminderRules);
        }
    }
}