using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.EmailReminder.Application.Interfaces
{
    public interface IPasswordHasher
    {
        string CryptPassword(string password);
        bool Verify(string hash, string password);
    }
}