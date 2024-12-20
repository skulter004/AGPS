using AGPS.Core.DTOs;
using AGPS.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AGPS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionService _submissionService;

        public SubmissionController(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
        }
        [HttpPost("submit")]
        public async Task<IActionResult> SubmitAssignment([FromForm] SubmissionRequest request)
        {
            try
            {
                SubmissionResult result = await _submissionService.SubmitAssignment(request);
                return Ok(new
                {
                    message = "Assignment Submitted Succesfully you result is:",
                    res = result
                });
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> UserLogin(LoginRequest loginRequest)
        {
            try
            {
                return Ok(new
                {
                    token = await _submissionService.LoginUser(loginRequest)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
