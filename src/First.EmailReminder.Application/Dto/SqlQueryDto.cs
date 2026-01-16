using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.EmailReminder.Application.Dto
{
    public class SqlQueryDto
    {
        public List<Dictionary<string, object?>> Rows { get; set; } = new List<Dictionary<string, object?>>();
        public List<string> Columns { get; set; } = new List<string>();
        public int RowCount => Rows.Count;
    }
}