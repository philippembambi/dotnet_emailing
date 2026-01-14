using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Domain.Entities;

namespace First.EmailReminder.Application.Interfaces
{
    public interface ISchedulerService
    {
        //Task<IEnumerable<string>> GetSchedulesAsync();
        //Task ScheduleJobAsync(string jobName, string cronExpression);
        Task ScheduleJobAsync(ReminderRule reminderRule); // créer une planification basée sur une règle de rappel
        Task RescheduleJobAsync(ReminderRule reminderRule); // replanifier une tâche existante avec une nouvelle règle de rappel
        Task UnscheduleJobAsync(ReminderRule reminderRule); // supprimer une planification basée sur une règle de rappel
        Task TriggerDueJobsAsync(DateTime currentTime, CancellationToken cancellationToken); // déclencher les tâches qui sont dues à l'heure actuelle
        //Task RemoveJobAsync(string jobName);
        //Task<IEnumerable<string>> GetSchedulesAsync(int userId);
        //Task<IEnumerable<string>> GetSchedulesAsync(string jobName);
    }
}