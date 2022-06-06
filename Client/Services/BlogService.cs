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

        public async Task<Article> CreateNewBlogPost(Article request)
        {
            var result = await _http.PostAsJsonAsync("api/Blog", request);
            return await result.Content.ReadFromJsonAsync<Article>();
        }

        public async Task<Article> GetBlogPostByUrl(string url)
        {
            //Problème si le client à une connexion vraiment faible
            //var post = await _http.GetFromJsonAsync<Article>($"api/Blog/{url}");
            //return post;
            var result = await _http.GetAsync($"api/Blog/{url}");
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var message = await result.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                return new Article { Title = message };
            }
            else
            {
                return await result.Content.ReadFromJsonAsync<Article>();
            }
        }

        public async Task<List<Article>> GetBlogPosts()
        {
            return await _http.GetFromJsonAsync<List<Article>>($"api/Blog");
        }
    }
}
