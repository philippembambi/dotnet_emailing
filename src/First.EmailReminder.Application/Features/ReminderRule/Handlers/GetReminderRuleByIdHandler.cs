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
    public class GetReminderRuleByIdHandler : IRequestHandler<GetReminderRuleByIdQuery, ReminderRuleDto>
    {
        public readonly IReminderRuleRepository _reminderRuleRepository;
        public readonly IMapper _mapper;

        public GetReminderRuleByIdHandler(IReminderRuleRepository reminderRuleRepository, IMapper mapper)
        {
            _reminderRuleRepository = reminderRuleRepository;
            _mapper = mapper;
        }

        public async Task<ReminderRuleDto> Handle(GetReminderRuleByIdQuery request, CancellationToken cancellationToken)
        {
            var reminderRule = await _reminderRuleRepository.GetByIdAsync(request.Id);
            return _mapper.Map<ReminderRuleDto>(reminderRule);
        }
    }
}