using ApiCe.Core.Entites;
using ApiCe.Core.Interfaces;
using ApiCe.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiCe.Infra.Repositories
{
    public class StudentRepository(AppDbContext db) : IStudentRepository
    {
        // private readonly AppContext _context; // استبدلي AppDbContext باسم الـ DbContext لديكِ

         public Task< List<Student>>GetAllAsnyc()
        {
            return db.Students.Include(s => s.Enrollments).ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await db.Students.ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            
            return await db.Students
                .Include(s => s.Enrollments)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Student> CreateAsync(Student student)
        {
            await db.Students.AddAsync(student);
            await db.SaveChangesAsync();
            return student;
        }

        public async Task<bool> UpdateAsync(Student student)
        {
            db.Students.Update(student);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = await GetByIdAsync(id);
            if (student == null) return false;

            db.Students.Remove(student);
            return await db.SaveChangesAsync() > 0;
        }
    }
}