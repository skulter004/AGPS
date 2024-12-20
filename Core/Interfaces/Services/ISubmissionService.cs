using AGPS.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGPS.Core.Interfaces.Services
{
    public interface ISubmissionService
    {
        Task<SubmissionResult> SubmitAssignment(SubmissionRequest request);
        Task<string> LoginUser(LoginRequest resuest);
    }
}
