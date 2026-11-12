using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ApiCe.Core.Services;
using ApiCe.Core.Enrollments;

namespace ApiCe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController(IEnrollmentService enrollmentService) : ControllerBase
    {
        [HttpGet("me")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetMyEnrollments()
        {
           var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value 
             ?? User.FindFirst("sub")?.Value 
             ?? User.FindFirst("id")?.Value;

            var enrollments = await enrollmentService.GetByUserIdAsync(userId);
            return Ok(enrollments);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateEnrollmentDto dto)
        {
            var created = await enrollmentService.CreateAsync(dto);
            return Ok(created);
        }
    }
}