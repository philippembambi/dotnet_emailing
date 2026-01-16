using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.EmailReminder.Application.Interfaces
{
    public interface ISqlQueryService
    {
        Task<List<IDictionary<string, object>>> ExecuteAsync(string sqlQuery, CancellationToken cancellationToken = default);
        Task<object> ExecuteScalarAsync(string sqlQuery, CancellationToken cancellationToken = default);
    }
}