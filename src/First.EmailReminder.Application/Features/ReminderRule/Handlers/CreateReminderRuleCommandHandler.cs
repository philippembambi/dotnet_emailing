using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using First.EmailReminder.Application.Dto;
using First.EmailReminder.Application.Interfaces;
using MediatR;
using First.EmailReminder.Application.Features.ReminderRule.Commands;
using First.EmailReminder.Domain.Common;
using System.Text.Json;

namespace First.EmailReminder.Application.Features.ReminderRule.Handlers
{
    public class CreateReminderRuleCommandHandler : IRequestHandler<CreateReminderRuleCommand, ReminderRuleDto>
    {
        public readonly IReminderRuleRepository _reminderRuleRepository;
        public readonly IMapper _mapper;
        public readonly ISqlQueryService _sqlQueryService;

        public CreateReminderRuleCommandHandler(IReminderRuleRepository reminderRuleRepository, IMapper mapper, ISqlQueryService sqlQueryService)
        {
            _reminderRuleRepository = reminderRuleRepository;
            _mapper = mapper;
            _sqlQueryService = sqlQueryService;
        }

        public async Task<ReminderRuleDto> Handle(CreateReminderRuleCommand request, CancellationToken cancellationToken)
        {
            var reminderRule = _mapper.Map<Domain.Entities.ReminderRule>(request);
            var data = await _sqlQueryService.ExecuteAsync(request.SqlQuery, cancellationToken);

            var recipients = new RecipientModel
            {
                Recipients = data.Select(row => new Dictionary<string, object?>(row))
                         .ToList(),
                Fields = data.FirstOrDefault()?.Keys.ToList() ?? new List<string>(),
            };

            reminderRule.CreatedAt = DateTime.UtcNow;
            reminderRule.RecipientTemplate = JsonSerializer.Serialize(recipients);
            reminderRule.Activate();
            reminderRule.ScheduleNextRun();

            await _reminderRuleRepository.CreateAsync(reminderRule);
            return _mapper.Map<ReminderRuleDto>(reminderRule);
        }
    }
}