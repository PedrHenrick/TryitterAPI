using Microsoft.EntityFrameworkCore;
using TryitterWebAPI.Interfaces;
using TryitterWebAPI.Models;

namespace TryitterWebAPI.Repository
{
    public class PostRepository : IPostRepository
    {
        protected readonly TryitterContext _tryitterContext;

        public PostRepository(TryitterContext tryitterContext)
        {
            _tryitterContext = tryitterContext;
        }

        public async Task<Post> GetPostById(int id) => await _tryitterContext.Posts.Where(s => s.PostId == id).FirstOrDefaultAsync();

        public async Task<string> CreatePost(Post post)
        {
            await _tryitterContext.Posts.AddAsync(post);
            _tryitterContext.SaveChanges();

            return "Usuário adicionado com sucesso";
        }

        public string UpdatePost(Post newPost, int posttId)
        {
            _tryitterContext.Posts.Update(newPost);
            _tryitterContext.SaveChanges();
            return "Usuário atualizado com sucesso";
        }

        public void DeletePost(int posttId)
        {
            var post = _tryitterContext.Posts.Find(posttId);

            if (post is null) throw new Exception("Post not found");

            _tryitterContext.Posts.Remove(post);
            _tryitterContext.SaveChanges();
        }
    }
}