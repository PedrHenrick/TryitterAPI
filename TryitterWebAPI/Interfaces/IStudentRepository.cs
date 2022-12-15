using TryitterWebAPI.Models;

namespace TryitterWebAPI.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudentById(int id);
        Task<IEnumerable<Student>> GetStudentsWithPosts();
        string UpdateStudent(Student student, int studentId);
        void DeleteStudent(int id);
    }
}
