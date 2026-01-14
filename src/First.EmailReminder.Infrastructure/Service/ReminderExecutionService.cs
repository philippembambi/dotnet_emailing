using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Application.Interfaces;
using First.EmailReminder.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata;

namespace First.EmailReminder.Infrastructure.Service
{
    public class ReminderExecutionService : IReminderExecutionService
    {

        // private readonly ISqlQueryExecutor _sqlExecutor;
        // private readonly IMailRepository _mailRepository;
        // private readonly IMailTemplateRenderer _templateRenderer;
        // private readonly ILogger<ReminderExecutionService> _logger;

        // public ReminderExecutionService(
        //     ISqlQueryExecutor sqlExecutor,
        //     IMailRepository mailRepository,
        //     IMailTemplateRenderer templateRenderer,
        //     ILogger<ReminderExecutionService> logger)
        // {
        //     _sqlExecutor = sqlExecutor;
        //     _mailRepository = mailRepository;
        //     _templateRenderer = templateRenderer;
        //     _logger = logger;
        // }

        // public async Task ExecuteAsync(
        //     ReminderRule rule,
        //     CancellationToken cancellationToken)
        // {
        //     _logger.LogInformation(
        //         "Executing reminder rule {RuleId}", rule.Id);

        //     var records = await _sqlExecutor
        //         .ExecuteAsync(rule.RequeteSql, cancellationToken);

        //     foreach (var record in records)
        //     {
        //         var mail = BuildMail(rule, record);

        //         await _mailRepository
        //             .AddAsync(mail, cancellationToken);
        //     }
        // }

        // private Mail BuildMail(ReminderRule rule, IDictionary<string, object> record)
        // {
        //     var subject = _templateRenderer.Render(
        //         rule.SujetTemplate, record);

        //     var body = _templateRenderer.Render(
        //         rule.CorpsTemplate, record);

        //     var recipients = _templateRenderer
        //         .ResolveRecipients(rule, record);

        //     return Mail.Create(
        //         rule.Id,
        //         subject,
        //         body,
        //         recipients);
        // }

        public Task ExecuteDueRemindersAsync(ReminderRule reminderRule, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}