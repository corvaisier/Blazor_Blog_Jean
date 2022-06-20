using Blazor_Blog_Jean.Server.Data;
using Blazor_Blog_Jean.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Blazor_Blog_Jean.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public BlogController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<List<Article>> GetAllBlogPosts()
        {
            return Ok(_dataContext.BlogPosts);
        }

        [HttpGet("{url}")]
        public ActionResult<Article> GetSingleBlogPostByUrl(string url)
        {
            var post = _dataContext.BlogPosts.FirstOrDefault(p => p.Url.ToLower().Equals(url.ToLower()));
            if (post == null) 
            {
                return NotFound("Ce post n'existe pas.");
            };
            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult<Article>> CreateNewBlogPost(Article request)
        {
            _dataContext.Add(request);
            await _dataContext.SaveChangesAsync();

            return request;
        }
    }
}
