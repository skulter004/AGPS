using AGPS.Core.DTOs;
using AGPS.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AGPS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;
        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        } 
        [HttpPost("assignment")]
        public async Task<IActionResult> Assignment(AssignmentDTO assignment)
        {
            if (await _assignmentService.AddAssignment(assignment))
            {
                return Ok(new
                {
                    msg = "Assignment Added Succesfully"
                });
            }
            else
            {
                return BadRequest(new { msg = "Error Adding Assignment" });
            }
        }
    }
}
