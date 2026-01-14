using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Application.Interfaces;
using First.EmailReminder.Infrastructure.Service;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace First.EmailReminder.Infrastructure.Worker
{
    public class ScheduleWorker : BackgroundService
    {
        //private readonly ISchedulerService _schedulerService;
        private readonly ILogger<ScheduleWorker> _logger;

        public ScheduleWorker(ILogger<ScheduleWorker> logger)
        {
            //_schedulerService = schedulerService;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Schedule Worker started at: {time}", DateTimeOffset.Now);

            while(!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Hello at {time}", DateTimeOffset.Now);
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
            _logger.LogInformation("Schedule Worker stopping at: {time}", DateTimeOffset.Now);
            

            // while (!stoppingToken.IsCancellationRequested)
            // {
            //     try
            //     {
            //         var currentTime = DateTime.UtcNow;
            //         _logger.LogInformation("Checking for due jobs at: {time}", currentTime);
            //         await _schedulerService.TriggerDueJobsAsync(currentTime, stoppingToken);
            //     }
            //     catch (Exception ex)
            //     {
            //         _logger.LogError("Error occurred while triggering due jobs => {ErrorMessage}", ex.Message);
            //     }
            //     await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken); // Check every minute
            // }
        }
        // return Task.Run(async () =>
        // {
        //     while (!stoppingToken.IsCancellationRequested)
        //     {
        //         try
        //         {
        //             var currentTime = DateTime.UtcNow;
        //             _logger.LogInformation("Checking for due jobs at: {time}", currentTime);
        //             await _schedulerService.TriggerDueJobsAsync(currentTime, stoppingToken);
        //         }
        //         catch (Exception ex)
        //         {
        //             _logger.LogError(ex, "Error occurred while triggering due jobs.");
        //         }

        //         await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken); // Check every minute
        //     }
        // }, stoppingToken);
    }
}