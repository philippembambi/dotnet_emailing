using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using FluentValidation;
using First.EmailReminder.Application.Behaviors;

namespace First.EmailReminder.Application
{
    public static class ApplicationRegistrationService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationRegistrationService).Assembly);
            services.AddValidatorsFromAssembly(typeof(ApplicationRegistrationService).Assembly);
            services.AddMediatR(typeof(ApplicationRegistrationService).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}