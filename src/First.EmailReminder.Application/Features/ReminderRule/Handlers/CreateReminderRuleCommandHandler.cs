using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using First.EmailReminder.Application.Dto;
using First.EmailReminder.Application.Interfaces;
using MediatR;
using First.EmailReminder.Application.Features.ReminderRule.Commands;

namespace First.EmailReminder.Application.Features.ReminderRule.Handlers
{
    public class CreateReminderRuleCommandHandler : IRequestHandler<CreateReminderRuleCommand, ReminderRuleDto>
    {
        public readonly IReminderRuleRepository _reminderRuleRepository;
        public readonly IMapper _mapper;

        public CreateReminderRuleCommandHandler(IReminderRuleRepository reminderRuleRepository, IMapper mapper)
        {
            _reminderRuleRepository = reminderRuleRepository;
            _mapper = mapper;
        }

        public async Task<ReminderRuleDto> Handle(CreateReminderRuleCommand request, CancellationToken cancellationToken)
        {
            var reminderRule = _mapper.Map<Domain.Entities.ReminderRule>(request);

            reminderRule.CreatedAt = DateTime.UtcNow;

            await _reminderRuleRepository.CreateAsync(reminderRule);
            return _mapper.Map<ReminderRuleDto>(reminderRule);
        }
    }
}