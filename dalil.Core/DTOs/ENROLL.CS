namespace ApiCe.Core.Enrollments
{
    public record CreateEnrollmentDto(int StudentId, int CourseId);

    public record EnrollmentResponseDto(int Id, int StudentId, int CourseId, string CourseName);
}