using Microsoft.EntityFrameworkCore;
using TryitterAPI.Models;

namespace TryitterAPI.Repository
{
    public class TryitterContext : DbContext, ITryitterContext
    {
        public TryitterContext() { }
        public TryitterContext(DbContextOptions<TryitterContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
