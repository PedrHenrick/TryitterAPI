using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Threading.Channels;
using TryitterAPI.Models;

namespace TryitterAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        protected readonly TryitterContext _tryitterContext;
        public StudentRepository(TryitterContext tryitterContext)
        {
            _tryitterContext = tryitterContext;
        }

        public async Task<IEnumerable<Student>> GetStudents() => await _tryitterContext.Students.ToListAsync();

        public async Task<Student> GetStudentById(int id) => await _tryitterContext.Students.FindAsync(id);

        public async Task<IEnumerable<Student>> GetStudentsWithPosts() => await _tryitterContext.Students.Select(
            student => new Student
            {
                StudentId = student.StudentId,
                Name = student.Name,
                Email = student.Email,
                CurrentModule = student.CurrentModule,
                Status = student.Status,
                Posts = student.Posts.Select(post => new Post
                {
                    PostId = post.PostId,
                    Description = post.Description,
                    UrlImage = post.UrlImage,
                }).ToList()
            }
        ).ToListAsync();

        public async Task<string> CreateStudent(Student student)
        {
            await _tryitterContext.Students.AddAsync(student);
            _tryitterContext.SaveChanges();
            return "Usuário adicionado com sucesso";
        }

        //public async Task<string> UpdateStudent(Student studentNewInformation, int id)
        //{
        //    await _tryitterContext.Students.Update(studentNewInformation);
        //    _tryitterContext.SaveChanges();
        //    return "Usuário atualizado com sucesso";
        //}

        public async void DeleteStudent(int id)
        {
            var student = await GetStudentById(id);
            if (student is null) throw new Exception("Student not found");
            _tryitterContext.Students.Remove(student);
            _tryitterContext.SaveChanges();
        }
    }
}
