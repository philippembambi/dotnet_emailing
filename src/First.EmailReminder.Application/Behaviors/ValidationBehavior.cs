using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Application.Interfaces;
using First.EmailReminder.Application.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace First.EmailReminder.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly ILogger<TRequest> _logger;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, ILogger<TRequest> logger)
        {
            _validators = validators;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var failures = _validators
                    .Select(v => v.Validate(context))
                    .SelectMany(request => request.Errors)
                    .Where(f => f != null)
                    .ToList()
                    ;

                if (failures.Count != 0)
                {
                    var errors = failures.Select(f => f.ErrorMessage).ToList();

                    _logger.LogWarning("Validation failed for {RequestType}: {Errors}", typeof(TRequest).Name, string.Join(", ", errors));
                    throw new FirstValidationException(errors);
                }
            }
            return await next();
        }

    }
}