using TryitterAPI.Models;

namespace TryitterWebAPI.Repository
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPosts();
        Task<Post> GetPostById(int id);
        Task<string> CreatePost(Post post);
        string UpdatePost(Post post, int postId);
        void DeletePost(int id);
    }
}
