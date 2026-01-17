using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.EmailReminder.Application.Dto
{
    public class RecipientDto
    {
        public List<Dictionary<string, object?>> Recipients { get; set; } = new List<Dictionary<string, object?>>();
        public List<string> Fields { get; set; } = new List<string>();
        public int RowCount => Recipients.Count;
    }
}