using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using First.EmailReminder.Application.Interfaces;
using First.EmailReminder.Infrastructure.Service;
using First.EmailReminder.Infrastructure.Persistence;
using First.EmailReminder.Infrastructure.Repositories;

namespace First.EmailReminder.Infrastructure
{
    public static class InfrastructureRegistrationService
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FirstDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IReminderRuleRepository, ReminderRuleRepository>();
            services.AddScoped<IEmailRepository, EmailRepository>();

            services.AddScoped<ISchedulerService, SchedulerService>();
            services.AddScoped<IReminderExecutionService, ReminderExecutionService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<ISqlQueryService, SqlQueryService>();

            return services;
        }
    }
}