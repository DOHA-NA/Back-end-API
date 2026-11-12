using ApiCe.Core.Entites;
using ApiCe.Core.Enrollments;
using ApiCe.Core.Services;
using ApiCe.Infra.Repositories; // تأكدي أن مسار الـ Repository صحيح
using Dalil.Core.Mappings;

namespace ApiCe.Infra.Services
{
    public class EnrollmentService(IEnrollmentRepository enrollmentRepository) : IEnrollmentService
    {
        public async Task<IEnumerable<EnrollmentResponseDto>> GetByUserIdAsync(string userId)
        {
            // جلب كل التسجيلات من قاعدة البيانات
            var enrollments = await enrollmentRepository.GetAllAsync();
            
            // فلترة التسجيلات بحيث نأخذ فقط الخاصة بالطالب الذي يملك هذا الـ UserId
            var userEnrollments = enrollments.Where(e => e.Student?.UserId == userId);

            // تحويلها إلى DTO وإرجاعها
            return userEnrollments.Select(e => e.ToDto());
        }

        public async Task<EnrollmentResponseDto> CreateAsync(CreateEnrollmentDto dto)
        {
            var enrollment = dto.ToEntity();
            var created = await enrollmentRepository.CreateAsync(enrollment);
            return created.ToDto();
        }

        public async Task DeleteAsync(int id)
        {
            await enrollmentRepository.DeleteAsync(id);
        }
    }
}