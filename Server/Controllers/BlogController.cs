using Blazor_Blog_Jean.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor_Blog_Jean.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        public List<Article> Posts { get; set; } = new List<Article>
        {
           new Article { Title = "Title", Url = "First", Description = "Description", Content = "Content", Author = "Author" },
           new Article { Title = "Title1", Url = "Second", Description = "Description1", Content = "Content1", Author = "Author1" },
        };

        [HttpGet]
        public ActionResult<List<Article>> GetAllBlogPosts()
        {
            return Ok(Posts);
        }

        [HttpGet("{url}")]
        public ActionResult<Article> GetSingleBlogPostByUrl(string url)
        {
            var post = Posts.FirstOrDefault(p => p.Url.ToLower().Equals(url.ToLower()));
            if (post == null) 
            {
                return NotFound("Ce post n'existe pas.");
            };
            return Ok(post);
        }
    }
}
