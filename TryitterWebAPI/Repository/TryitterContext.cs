using Microsoft.EntityFrameworkCore;
using TryitterWebAPI.Interfaces;
using TryitterWebAPI.Models;

namespace TryitterWebAPI.Repository
{
    public class TryitterContext : DbContext, ITryitterContext
    {
        public TryitterContext() { }
        public TryitterContext(DbContextOptions<TryitterContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(x => x.Student)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.PostId);
        }
    }
}
