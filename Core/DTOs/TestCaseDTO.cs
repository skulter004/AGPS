using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGPS.Core.DTOs
{
    public class TestCaseDTO
    {
        public string Input { get; set; }
        public string ExpectedOutput { get; set; }
    }
}
