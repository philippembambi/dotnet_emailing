using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Application.Interfaces;
using First.EmailReminder.Domain.Entities;
using First.EmailReminder.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace First.EmailReminder.Infrastructure.Repositories
{
    public class ReminderRuleRepository : GenericRepository<ReminderRule>, IReminderRuleRepository
    {
        public ReminderRuleRepository(FirstDbContext context) : base(context)
        {
        }

        public async Task<List<ReminderRule>> GetActiveRulesAllAsync()
        {
            return await _context.ReminderRules.Where(r => r.IsActive()).ToListAsync();
        }

        public async Task<List<ReminderRule>> GetDueRulesAllAsync(DateTime currentTime, CancellationToken cancellationToken)
        {
            return await _context.ReminderRules
                .Where(r => r.NextRunAt <= currentTime && r.IsActive())
                .ToListAsync(cancellationToken);
        }
    }
}