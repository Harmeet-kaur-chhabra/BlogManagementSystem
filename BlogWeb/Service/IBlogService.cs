using BlogModels;
using System.Reflection;

namespace BlogWeb.Service
{
    public interface IBlogService
    {
        Task<IEnumerable<Blog>> GetblogsAsync();
        Task<Blog> GetBlogByIdAsync(int id);
        Task<Blog> CreateBlogAsync(Blog blog);
        Task<Blog> UpdateBlogAsync(int id, Blog updatedblog);
        Task DeleteBlogAsync(int id);

    }
}
