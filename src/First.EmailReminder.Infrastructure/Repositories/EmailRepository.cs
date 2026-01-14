using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Application.Interfaces;
using First.EmailReminder.Domain.Entities;
using First.EmailReminder.Infrastructure.Persistence;

namespace First.EmailReminder.Infrastructure.Repositories
{
    public class EmailRepository : GenericRepository<Email>, IEmailRepository
    {
        public EmailRepository(FirstDbContext context) : base(context)
        {
        }
    }
}