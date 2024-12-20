using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGPS.Core.Entities
{
    public class PlagarismReport
    {
        public Guid Id { get; set; }
        public Guid SubmissionId { get; set; }
        public string SimilarityPercentage { get; set; }
        public Submission Submission { get; set; }
    }
}
