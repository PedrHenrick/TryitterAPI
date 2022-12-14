using TryitterAPI.Models;

namespace TryitterAPI.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudentById(int id);
        Task<IEnumerable<Student>> GetStudentsWithPosts();
        Task<string> CreateStudent(Student student);
        string UpdateStudent(Student student, int studentId);
        void DeleteStudent(int id);
    }
}
