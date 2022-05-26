using Blazor_Blog_Jean.Shared;
using System.Net.Http.Json;

namespace Blazor_Blog_Jean.Client.Services
{
    public class BlogService : IBlogService
    {
        private readonly HttpClient _http;

        public BlogService(HttpClient http)
        {
            _http = http;
        }

        public async Task<Article> GetBlogPostByUrl(string url)
        {
            var post = await _http.GetFromJsonAsync<Article>($"api/Blog/{url}");
            return post;
        }

        public async Task<List<Article>> GetBlogPosts()
        {
            return await _http.GetFromJsonAsync<List<Article>>($"api/Blog");
        }
    }
}
