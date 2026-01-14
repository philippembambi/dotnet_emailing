using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Application.Interfaces;
using First.EmailReminder.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace First.EmailReminder.Infrastructure.Service
{
    public class SchedulerService : ISchedulerService
    {
        //private readonly IReminderExecutionService _reminderExecutionService;
        //private readonly IReminderRuleRepository _reminderRuleRepository;
        private readonly ILogger<SchedulerService> _logger;

        public SchedulerService(ILogger<SchedulerService> logger)
        {
            //_reminderExecutionService = reminderExecutionService;
            //_reminderRuleRepository = reminderRuleRepository;
            _logger = logger;
        }

        public Task ScheduleJobAsync(ReminderRule reminderRule)
        {
            // Implementation here
            return Task.CompletedTask;
        }

        public Task RescheduleJobAsync(ReminderRule reminderRule)
        {
            // Implementation here
            return Task.CompletedTask;
        }

        public Task UnscheduleJobAsync(ReminderRule reminderRule)
        {
            // Implementation here
            return Task.CompletedTask;
        }

        public async Task TriggerDueJobsAsync(DateTime currentTime, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Triggering due jobs at {CurrentTime}", currentTime);

            // var dueRulesTask = await _reminderRuleRepository.GetDueRulesAllAsync(currentTime, cancellationToken);
            // foreach (var reminderRule in dueRulesTask)
            // {
            //     try
            //     {
            //         if (reminderRule.IsDue(currentTime))
            //         {
            //             _logger.LogInformation("Executing reminder rule {ReminderRuleId}", reminderRule.Id);
            //             //await _reminderExecutionService.ExecuteDueRemindersAsync(reminderRule, cancellationToken);
            //
            //             reminderRule.ScheduleNextRun();
            //             reminderRule.UpdateNextRunAt(currentTime);
            //             _logger.LogInformation("Reminder rule {ReminderRuleId} executed", reminderRule.Id);
            //         }
            //     }
            //     catch (Exception ex)
            //     {
            //         _logger.LogError("Error executing reminder rule {ReminderRuleId} => {Exception}", reminderRule.Id, ex.Message);
            //     }
            // }
            // Implementation here
        }
    }
}