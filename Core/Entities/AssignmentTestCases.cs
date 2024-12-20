using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGPS.Core.Entities
{
    public class AssignmentTestCases
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Assignment")]
        public Guid AssignmentId { get; set; }
        public string Input { get; set; }
        public string ExpectedOutput { get; set; }
        public Assignment Assignment { get; set; }
    }
}
