using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.EmailReminder.Application.Exceptions
{
    public class FirstValidationException : Exception
    {
        public List<string> Errors { get; }

        public FirstValidationException(IEnumerable<string> errors)
        {
            Errors = errors.ToList();
        }

        public FirstValidationException(string message, IEnumerable<string> errors)
            : base(message)
        {
            //Errors = errors?.ToList() ?? new List<string>();
            Errors = errors.ToList();
        }
    }
}