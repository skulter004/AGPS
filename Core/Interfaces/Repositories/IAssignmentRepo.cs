using AGPS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGPS.Core.Interfaces.Repositories
{
    public interface IAssignmentRepo
    {
        Task<bool> AddAssignment(Assignment assignment);
    }
}
