using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Application.Dto;
using MediatR;

namespace First.EmailReminder.Application.Features.ReminderRule.Commands
{
    public class ExecuteSqlQueryCommand : IRequest<SqlQueryDto>
    {
        public string Query { get; set; } = string.Empty;
    }
}