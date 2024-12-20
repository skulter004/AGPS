using AGPS.Core.DTOs;
using AGPS.Core.Entities;
using AGPS.Core.Interfaces.Repositories;
using AGPS.Core.Interfaces.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGPS.Application.Services
{
    public class AssignmentService:IAssignmentService
    {
        private readonly IAssignmentRepo _assignmentRepo;
        private readonly IMapper _mapper;
        public AssignmentService(IAssignmentRepo assignmentRepo, IMapper mapper)
        {
            _assignmentRepo = assignmentRepo;
            _mapper = mapper;
        }
        public async Task<bool> AddAssignment(AssignmentDTO assignment)
        {
            try
            {

                var newAssignment = _mapper.Map<AssignmentDTO,Assignment>(assignment);
                return await _assignmentRepo.AddAssignment(newAssignment);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
