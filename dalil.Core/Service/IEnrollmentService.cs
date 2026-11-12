using ApiCe.Core.Enrollments;

namespace ApiCe.Core.Services
{
    public interface IEnrollmentService
    {
        Task<IEnumerable<EnrollmentResponseDto>> GetByUserIdAsync(string userId);
        Task<EnrollmentResponseDto> CreateAsync(CreateEnrollmentDto dto);
        Task DeleteAsync(int id);
    }
}