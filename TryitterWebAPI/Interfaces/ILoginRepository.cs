using TryitterWebAPI.Models;

namespace TryitterWebAPI.Interfaces
{
    public interface ILoginRepository
    {
        Task<string> TokenGenerate(string email, string password);
        Task<string> CreateStudent(Student student);
    }
}
