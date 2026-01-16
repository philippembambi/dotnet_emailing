using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace First.EmailReminder.Application.Features.ReminderRule.Commands
{
    public class ExecuteSqlQueryCommandValidator : AbstractValidator<ExecuteSqlQueryCommand>
    {
        public ExecuteSqlQueryCommandValidator()
        {
            RuleFor(x => x.Query)
                .NotEmpty().WithMessage("SQL query is required.").WithMessage("SQL query cannot be empty.")

                .Must(query => query.TrimEnd().EndsWith(';')).WithMessage("SQL query must end with a semicolon.")

                .Must(query => query.TrimStart().ToLower().StartsWith("select"))
                    .WithMessage("Only SELECT queries are allowed.")

                .Must(query => !query.ToLower().Contains("drop") && !query.ToLower().Contains("delete"))
                    .WithMessage("SQL query cannot contain DROP or DELETE statements.")

                .Must(query => !query.ToLower().Contains("--") && !query.ToLower().Contains("/*"))
                    .WithMessage("SQL query cannot contain comments.")

                .Must(query => !query.ToLower().Contains("insert") && !query.ToLower().Contains("update"))
                    .WithMessage("SQL query cannot contain INSERT or UPDATE statements.")

                .Must(query => !query.ToLower().Contains("exec") && !query.ToLower().Contains("execute"))
                    .WithMessage("SQL query cannot contain EXEC or EXECUTE statements.")

                .Must(query => !query.ToLower().Contains("alter") && !query.ToLower().Contains("truncate"))
                    .WithMessage("SQL query cannot contain ALTER or TRUNCATE statements.")

                .Must(query => !query.ToLower().Contains("create") && !query.ToLower().Contains("rename"))
                    .WithMessage("SQL query cannot contain CREATE or RENAME statements.")

                .Must(query => !query.ToLower().Contains("shutdown") && !query.ToLower().Contains("kill"))
                    .WithMessage("SQL query cannot contain SHUTDOWN or KILL statements.")

                .Must(query => !query.ToLower().Contains("grant") && !query.ToLower().Contains("revoke"))
                    .WithMessage("SQL query cannot contain GRANT or REVOKE statements.")

                .Must(query => !query.ToLower().Contains("set") && !query.ToLower().Contains("declare"))
                    .WithMessage("SQL query cannot contain SET or DECLARE statements.")

                .Must(query => !query.ToLower().Contains("xp_") && !query.ToLower().Contains("sp_"))
                    .WithMessage("SQL query cannot contain extended or stored procedures.")

                .Must(query => !query.ToLower().Contains("load_file") && !query.ToLower().Contains("into outfile"))
                    .WithMessage("SQL query cannot contain file operations.")

                .Must(query => !query.ToLower().Contains("information_schema") && !query.ToLower().Contains("pg_catalog"))
                    .WithMessage("SQL query cannot access system catalogs or information schema.")
                ;
        }
    }
}