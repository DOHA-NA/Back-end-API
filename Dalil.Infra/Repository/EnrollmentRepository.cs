using ApiCe.Core.Entites;
using ApiCe.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiCe.Infra.Repositories
{
    public interface IEnrollmentRepository
    {
        Task<List<Enrollment>> GetAllAsync();
        Task<Enrollment> CreateAsync(Enrollment enrollment);
        Task<bool> DeleteAsync(int id);
    }

    public class EnrollmentRepository(AppDbContext db) : IEnrollmentRepository
    {
        public async Task<List<Enrollment>> GetAllAsync() =>
            await db.Set<Enrollment>().Include(e => e.Student).Include(e => e.Course).ToListAsync();

        public async Task<Enrollment> CreateAsync(Enrollment enrollment)
        {
            db.Set<Enrollment>().Add(enrollment);
            await db.SaveChangesAsync();
            return enrollment;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await db.Set<Enrollment>().FindAsync(id);
            if (item is null) return false;
            db.Set<Enrollment>().Remove(item);
            await db.SaveChangesAsync();
            return true;
        }
    }
}