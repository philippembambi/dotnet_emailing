using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using First.EmailReminder.Application.Dto;
using First.EmailReminder.Application.Features.ReminderRule.Commands;
using First.EmailReminder.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace First.EmailReminder.Application.Features.ReminderRule.Handlers
{
    public class ExecuteSqlQueryCommandHandler : IRequestHandler<ExecuteSqlQueryCommand, SqlQueryDto>
    {
        public readonly ISqlQueryService _sqlQueryService;
        public readonly IMapper _mapper;
        public readonly ILogger<ExecuteSqlQueryCommandHandler> _logger;

        public ExecuteSqlQueryCommandHandler(ISqlQueryService sqlQueryService, IMapper mapper, ILogger<ExecuteSqlQueryCommandHandler> logger)
        {
            _sqlQueryService = sqlQueryService;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<SqlQueryDto> Handle(ExecuteSqlQueryCommand request, CancellationToken cancellationToken)
        {
            var data = await _sqlQueryService.ExecuteAsync(request.Query, cancellationToken);

            return new SqlQueryDto
            {
                Rows = data.Select(row => new Dictionary<string, object?>(row))
                         .ToList(),
                Columns = data.FirstOrDefault()?.Keys.ToList() ?? new List<string>(),
            };
        }
    }
}