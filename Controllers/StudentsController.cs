using ApiCe.Core.Entites;
using ApiCe.Core.Services;
using ApiCe.Core.Students;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace ApiCe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController(IStudentService studentService) : ControllerBase
    {
        // GET: api/students
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<STDResposDto>>> GetALL()
        {
            return Ok(await studentService.GetAllAsync());
        }

        // GET:
        [HttpGet("{id:int}")]
        public async Task<ActionResult<STDResposDto>> GetByID(int id)
        {
            var student = await studentService.GetByIdAsync(id);

            if (student is null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // POST:
        [HttpPost]
        public async Task<ActionResult<STDResposDto>> Create(CreateSTDDto dto)
        {
            try
            {
                var created = await studentService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetByID),
                    new { id = created.Id },
                    created
                );
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/students/1
        [HttpPut("{id:int}")]
        public async Task<ActionResult<STDResposDto>> Update(int id,  UpdateSTSDto dto)
        {
            try{
    await studentService.UpdateAsync(id,dto) ;
   return NoContent ();
     }
     catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
                
            }
        }

        // DELETE: api/students/1
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            
        await studentService.DeleteAsync(id);              
            return NotFound(); 
        }
    }
}