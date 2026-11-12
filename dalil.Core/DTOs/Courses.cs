using System;
using System.Collections.Generic;
using System.Text;
using ApiCe.Core.Entites;

namespace ApiCe.Core.courses
{
        public record CreateCourseDto (string Title ,decimal Price ,int InstructorId);
        public record DeleteCourseDto (string Title ,decimal Price );
        public record CourseResposDto (int Id,string Title ,decimal Price ,string? InstructorName);

    //     public string Title { get; init; } 

    //     public decimal Price { get; init; }

    //     public int InstructorId { get; init; }
    }
