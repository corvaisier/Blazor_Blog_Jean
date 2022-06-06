using Blazor_Blog_Jean.Shared;

namespace Blazor_Blog_Jean.Client.Services
{
    public interface IBlogService
    {
        Task<List<Article>> GetBlogPosts();
        Task<Article> GetBlogPostByUrl(string Url);  
        Task<Article> CreateNewBlogPost(Article request);
    }
}
