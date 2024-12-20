using AGPS.Core.DTOs;
using AGPS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGPS.Core.Interfaces.Services
{
    public interface IAssignmentService
    {
        Task<bool> AddAssignment(AssignmentDTO assignment);
    }
}
