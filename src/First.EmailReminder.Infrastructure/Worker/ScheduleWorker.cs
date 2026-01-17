using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Application.Interfaces;
using First.EmailReminder.Infrastructure.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace First.EmailReminder.Infrastructure.Worker
{
    public class ScheduleWorker : BackgroundService
    {
        //private readonly ISchedulerService _schedulerService;
        private readonly ILogger<ScheduleWorker> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ScheduleWorker(ILogger<ScheduleWorker> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Schedule Worker started at: {time}", DateTimeOffset.Now);

            while(!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _serviceScopeFactory.CreateScope();
                    var schedulerService = scope.ServiceProvider.GetRequiredService<ISchedulerService>();
                    await schedulerService.TriggerDueJobsAsync(DateTime.UtcNow, stoppingToken);
                    //  _logger.LogInformation("Hello at {time}", DateTimeOffset.Now);     
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occured while executing scheduler worker");
                }
               await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
            _logger.LogInformation("Schedule Worker stopping at: {time}", DateTimeOffset.Now);
        }
    }
}