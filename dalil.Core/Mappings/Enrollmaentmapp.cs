using ApiCe.Core.Entites;
using ApiCe.Core.Enrollments;

namespace Dalil.Core.Mappings
{
    public static class EnrollmentMapping
    {
        public static EnrollmentResponseDto ToDto(this Enrollment enrollment)
        {
            return new EnrollmentResponseDto(
                enrollment.Id,
                enrollment.StudentId,
                enrollment.CourseId,
                enrollment.Course?.Title ?? string.Empty
            );
        }

        public static Enrollment ToEntity(this CreateEnrollmentDto dto)
        {
            return new Enrollment
            {
                StudentId = dto.StudentId,
                CourseId = dto.CourseId
            };
        }
    }
}