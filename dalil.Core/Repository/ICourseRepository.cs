using dalil.Core.Repository;
using ApiCe.Core.Entites;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.Metrics;
using ApiCe.Core.courses;

public interface ICourseRepository
    {
        
        Task< List<CourseResposDto>>GetAllAsnyc();
        Task<Course?> GetByIDAsnyc(int id);
        Task<Course> CreateAsnyc (Course course);
        Task<bool>UpdateAsnyc(Course course);
        
        Task <bool>DeleteAsnyc(int id);
    }
