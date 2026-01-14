using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Domain.Entities;

namespace First.EmailReminder.Application.Interfaces
{
    public interface IEmailRepository : IGenericRepository<Email>
    {
        
    }
}