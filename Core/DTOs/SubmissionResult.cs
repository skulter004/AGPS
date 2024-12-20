using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGPS.Core.DTOs
{
    public class SubmissionResult
    {
        public Double Grade { get; set; }
        public List<FailedTest> FailedTestCases { get; set; }
    }
    public class FailedTest
    {
        public string Input { get; set; }
        public string ExpectedOutput { get; set; }
        public string YourOutput { get; set; }
    }
}
