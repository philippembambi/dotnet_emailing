using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using First.EmailReminder.Domain.Common;

namespace First.EmailReminder.Infrastructure.Persistence
{
    public class FirstDbContext : DbContext
    {
        public FirstDbContext(DbContextOptions<FirstDbContext> options) : base(options)
        {
        }
        public DbSet<ReminderRule> ReminderRules { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<User> Users { get; set; }
    }
}