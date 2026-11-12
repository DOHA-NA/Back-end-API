using System.Collections.Generic;
using ApiCe.Core.Entites;
using ApiCe.Core.courses;

namespace dalil.Core.Repository
{
    public interface ICourseService
    {
       Task< List<CourseResposDto>>GetAllAsnyc();
        Task<CourseResposDto?> GetByIDAsnyc(int id);
        Task<CourseResposDto> CreateAsnyc (CreateCourseDto course);
        Task UpdateAsnyc( int id ,Course course);
        
        Task DeleteAsnyc(int id);

    }
}