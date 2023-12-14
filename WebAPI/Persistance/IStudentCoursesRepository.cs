using WebAPI.Models;

namespace WebAPI.Persistance
{
    public interface IStudentCoursesRepository
    {
        StudentCourses Get(string emplid, string courseId);
        IEnumerable<StudentCourses> GetAll();
        StudentCourses Add(StudentCourses studentCourses);
        void Delete(string emplid, string courseId);
        bool Update(StudentCourses studentCourses);
    }
}
