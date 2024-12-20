using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGPS.Core.Entities
{
    public class Assignment
    {
        [Key]
        public Guid Id { get; set; }
        public string Problem {  get; set; }
        public ICollection<AssignmentTestCases> TestCases { get; set; }

    }
}
