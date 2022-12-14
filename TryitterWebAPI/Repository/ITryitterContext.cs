using Microsoft.EntityFrameworkCore;
using TryitterAPI.Models;

namespace TryitterAPI.Repository
{
    public interface ITryitterContext
    {
        DbSet<Post> Posts { get; set; }
        DbSet<Student> Students { get; set; }
    }
}
