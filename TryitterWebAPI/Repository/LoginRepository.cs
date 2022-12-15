using Microsoft.EntityFrameworkCore;
using TryitterWebAPI.Interfaces;
using TryitterWebAPI.Models;
using TryitterWebAPI.Token;

namespace TryitterWebAPI.Repository
{
    public class LoginRepository : ILoginRepository
    {
        protected readonly TryitterContext _tryitterContext;

        public LoginRepository(TryitterContext tryitterContext) => _tryitterContext = tryitterContext;

        public async Task<string> TokenGenerate(string email, string password)
        {
            var student = await _tryitterContext.Students.Where(
                s => s.Email == email
                && s.Password == password
                ).FirstOrDefaultAsync();

            if (student is null)
            {
                return "Student not found";
            }
            return new Generator().Generate(student.StudentId);
        }

        public async Task<string> CreateStudent(Student student)
        {
            await _tryitterContext.Students.AddAsync(student);
            _tryitterContext.SaveChanges();
            return "Usuário adicionado com sucesso";
        }
    }
}