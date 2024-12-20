using AGPS.Core.DTOs;
using AGPS.Core.Entities;
using AGPS.Core.Interfaces.Repositories;
using AGPS.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGPS.Infrastructure.Repositories
{
    public class SubmissionRepo:ISubmissionRepo
    {
        public readonly AGPSContext _context;
        public SubmissionRepo(AGPSContext context)
        {
            _context = context;
        }

        public async Task<List<TestCaseDTO>> GetTestCases(Guid assignmentId)
        {
            try
            {
                return await _context.AssignmentTestCases
                    .Where(tc => tc.AssignmentId == assignmentId)
                    .Select(tc => new TestCaseDTO
                    {
                        Input = tc.Input,
                        ExpectedOutput = tc.ExpectedOutput
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<bool> LoginUser(LoginRequest request)
        {
            try
            {
                User user = await _context.Users.Where(u => u.Email == request.Email && u.Password == request.Password).FirstOrDefaultAsync();
                if (user == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
