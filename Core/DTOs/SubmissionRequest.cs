using AGPS.Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGPS.Core.DTOs
{
    public class SubmissionRequest
    {
        public Guid StudentId { get; set; }
        public Guid AssignmentId { get; set; }
        public IFormFile SourceCode { get; set; }
        public ProgrammingLanguage Language { get; set; }
    }
}
