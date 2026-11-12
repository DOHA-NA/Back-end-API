using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ApiCe.Core.courses;
using ApiCe.Core.Entites;
using dalil.Core.Repository;
using Dalil.Core.Mappings;
namespace Dalil.Core.Mappings
{
    public static class CourseMapping
    {
        public static CourseResposDto ToDto(this Course course)
        {
            return new CourseResposDto(course.Id,course.Title,course.Price,course.Instructor?.FullName);
        }
          public static Course ToEntity(this CreateCourseDto dto)
        {
            return new Course {
                Title=dto.Title,
                Price = dto.Price,
                InstructorId= dto.InstructorId 
                };
        }
    }
}
