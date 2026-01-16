using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using First.EmailReminder.Application.Dto;
using First.EmailReminder.Application.Features.ReminderRule.Commands;
using First.EmailReminder.Application.Interfaces;
using MediatR;

namespace First.EmailReminder.Application.Features.ReminderRule.Handlers
{
    public class ExecuteSqlQueryCommandHandler : IRequestHandler<ExecuteSqlQueryCommand, SqlQueryDto>
    {
        public readonly ISqlQueryService _sqlQueryService;
        public readonly IMapper _mapper;

        public ExecuteSqlQueryCommandHandler(ISqlQueryService sqlQueryService, IMapper mapper)
        {
            _sqlQueryService = sqlQueryService;
            _mapper = mapper;
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