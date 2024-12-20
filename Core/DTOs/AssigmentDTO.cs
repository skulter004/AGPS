using AGPS.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGPS.Core.DTOs
{
    public class AssignmentDTO
    {
        public string Problem { get; set; }
        public List<TestCaseDTO> TestCases {  get; set; }
    }
}
