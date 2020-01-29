using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodesTable.Data;
using CodesTable.Data.POCO;

namespace CodesTable.Models
{
    public class CodeView
    {
        public Code Code { get; set; }
        public ICollection<CodeCategory> CodeCategories { get; set; }
    }
}
