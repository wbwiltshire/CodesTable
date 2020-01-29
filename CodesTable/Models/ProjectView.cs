using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodesTable.Data;
using CodesTable.Data.POCO;

namespace CodesTable.Models
{
    public class ProjectView
    {
        public Project Project { get; set; }
        public ICollection<Code> ProjectTypes { get; set; }
        public ICollection<Code> StatusTypes { get; set; }
    }
}
