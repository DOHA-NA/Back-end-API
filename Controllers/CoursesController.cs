using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Dalil.Infra.Repository;
using dalil.Core.Repository;
using ApiCe.Core.Entites;
using ApiCe.Infra.Data;
using ApiCe.Core.courses;
using FluentValidation;
namespace ApiCe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController (ICourseService courseService) : ControllerBase
    {
        //Inject Service Layer (courseServic )
//         private readonly ICourseService _courseService;
// public CoursesController (ICourseService courseService)
// {
//     _courseService = courseService;


// }



        //****************CRUD********************
    
        // public static readonly List<Course> _courses = [];

        // Get 
[HttpGet]   
        public async Task<ActionResult<List<CourseResposDto>>> GetALL()
        {
            return  Ok(await courseService.GetAllAsnyc());
        }
        
    //GetById
[HttpGet]
      [Route("{id:int}")]

      public async Task<ActionResult<List<CourseResposDto>>> GetByID(int id)
        {   var course = await courseService.GetByIDAsnyc(id);

    if (course is null)
    {
        return NotFound();
    }

    return Ok(course);
    
        }

//create 
  [HttpPost]

      public async Task<ActionResult<CourseResposDto>> Create(CreateCourseDto dto)
        {
            try{
        //    course.Id = _courses.Count ==0 ? 1 : _courses.Max(c => c.Id) +1;
        //    _courses.Add(course);
        var created = await courseService.CreateAsnyc(dto);
          return CreatedAtAction(nameof(GetByID),new {id = created.Id} , created);
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);


        }}

[HttpPut]
[Route("{id:int}")]
public async Task<ActionResult<Course>> Update(int id, Course updatecourse)
{
     try{
    await courseService.UpdateAsnyc(id,updatecourse) ;
   return NoContent ();
     }
     catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
                
            }
}

[HttpDelete]
[Route("{id:int}")]
public async Task< ActionResult> Delete(int id)
{
     
    await courseService.DeleteAsnyc(id);              
return NotFound(); 
}
    }




    



namespace ApiCe.Core.Entites
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}

}