using AGPS.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGPS.Core.Entities
{
    public class Submission
    {
        public Guid Id { get; set; }
        public Guid AssignmentId { get; set; }
        public Guid StudentId { get; set; }
        public string SourceCodePath {  get; set; }
        public string Grade {  get; set; }
        public bool IsPlagarized {  get; set; }
        public int TestCasesPassed { get; set; }
        public int LanguageId { get; set; }
        public User User {  get; set; }
        public AssignmentDTO Assignment { get; set; }  
    }
}
