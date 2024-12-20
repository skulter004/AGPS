using AGPS.Core.DTOs;
using AGPS.Core.Entities;
using AGPS.Core.Interfaces.Repositories;
using AGPS.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGPS.Infrastructure.Repositories
{
    public class AssignmentRepo:IAssignmentRepo
    {
        private readonly AGPSContext _context;
        public AssignmentRepo(AGPSContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAssignment(Assignment assignment)
        {
            try
            {
                await _context.Assignments.AddAsync(assignment);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
