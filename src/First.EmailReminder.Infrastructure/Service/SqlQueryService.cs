using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Application.Interfaces;
using First.EmailReminder.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace First.EmailReminder.Infrastructure.Service
{
    public class SqlQueryService : ISqlQueryService
    {
        private readonly FirstDbContext _dbContext;

        public SqlQueryService(FirstDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<IDictionary<string, object>>> ExecuteAsync(string sqlQuery, CancellationToken cancellationToken = default)
        {
            var result = new List<IDictionary<string, object>>();

            using var command = _dbContext.Database.GetDbConnection().CreateCommand();
            command.CommandText = sqlQuery;
            command.CommandType = CommandType.Text;
            command.CommandTimeout = 60;

            await _dbContext.Database.OpenConnectionAsync(cancellationToken);

            using var reader = await command.ExecuteReaderAsync(cancellationToken);

            while(await reader.ReadAsync(cancellationToken))
            {
                var row = new Dictionary<string, object>();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row[reader.GetName(i)] = reader.IsDBNull(i) ? null! : reader.GetValue(i);
                }
                result.Add(row);
            }

            return result;
        }

        public async Task<object> ExecuteScalarAsync(string sqlQuery, CancellationToken cancellationToken = default)
        {
            using var command = _dbContext.Database.GetDbConnection().CreateCommand();
            command.CommandText = sqlQuery;

            await _dbContext.Database.OpenConnectionAsync(cancellationToken);
            return await command.ExecuteScalarAsync(cancellationToken);
        }
    }
}