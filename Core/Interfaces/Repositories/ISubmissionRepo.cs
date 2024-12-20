using AGPS.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGPS.Core.Interfaces.Repositories
{
    public interface ISubmissionRepo
    {
        Task<List<TestCaseDTO>> GetTestCases(Guid assignmentId);
        Task<bool> LoginUser(LoginRequest request);
    }
}
