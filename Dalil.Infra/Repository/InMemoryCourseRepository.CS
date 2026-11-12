using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ApiCe.Core.Entites;
using ApiCe.Infra.Data;
using dalil.Core.Repository;
using dalil.Core.Exptions;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using ApiCe.Core.courses;
using System.Data.Common;
using ApiCe.Core.PagResult;
namespace Dalil.Infra.Repository
{
    public class InMemoryCourseRepository(AppDbContext db) : ICourseRepository
    {
        // private static readonly List<Course> _courses = [];

        public async Task< List<CourseResposDto>>GetAllAsnyc()
        {
            var count =await db.Courses.CountAsync();
            return await db.Courses.Select(c => new CourseResposDto(c.Id, c.Title, c.Price,c.Instructor!.FullName))
            .ToListAsync();
        }
        //  public async Task< PagResult<CourseResposDto>>GetPagAsnyc(int Pag , int PagSize)
        // {
        //     var count =await db.Courses.CountAsync();
        //     var Items = await db.Courses
        //     .OrderBy(c => c.Id)
        //     .Skip((Pag - 1) * PagSize)
        //     .Select(c => new CourseResposDto(c.Id, c.Title, c.Price,c.Instructor!.FullName))
        //     .ToListAsync();
        //     return new PagResult<CourseResposDto>(Items , Pag ,PagSize ,count);
        // }

        public async Task<Course?> GetByIDAsnyc(int id)
        {
            // var course = _courses.FirstOrDefault(c => c.Id == id);
            return await db.Courses.Include(c => c.Instructor).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Course> CreateAsnyc (Course course)
        {
          
            // course.Id = _courses.Count == 0
            //     ? 1
            //     : _courses.Max(c => c.Id) + 1;
            try
            {
                  db.Courses.Add(course);
            await db.SaveChangesAsync();
            await db.Entry(course).Reference(c => c.Instructor).LoadAsync();
            return course ;
                
                    }
catch(DbUpdateConcurrencyException ex ) when (ex.InnerException is PostgresException { SqlState : PostgresErrorCodes.UniqueViolation})
            {
                throw new ConflictExtpion("A course with this title alredy exists");
            }
        }
        

        public async Task<bool> UpdateAsnyc(Course course)
        {
            
         db.Courses.Update(course);
        await db.SaveChangesAsync();
        return true;
        }

        public  async Task<bool> DeleteAsnyc(int id)
        {
            {
            var delete =await db.Courses.FindAsync( id);

            if (delete is null)  return false;
            

            db.Courses.Remove(delete);
                await db.SaveChangesAsync();
                return true;        }
    }
     }
}