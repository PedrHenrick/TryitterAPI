using Microsoft.EntityFrameworkCore;
using TryitterWebAPI.Models;

namespace TryitterWebAPI.Repository
{
    public interface ITryitterContext
    {
        DbSet<Post> Posts { get; set; }
        DbSet<Student> Students { get; set; }
    }
}
