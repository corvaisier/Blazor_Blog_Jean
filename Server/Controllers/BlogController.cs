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
            var posts = _dataContext.BlogPosts;

            if (posts == null)
            {
                return NotFound("Ces post ne sont pas accessibles pour le moment.");
            }
            else
            {
                return Ok(_dataContext.BlogPosts);
            }
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

        [HttpDelete("{url}")]
        public ActionResult<Article> DeleteBlogPostByUrl(string url)
        {
            var post = _dataContext.BlogPosts.FirstOrDefault(p => p.Url.ToLower().Equals(url.ToLower()));

            if (post == null)
            {
                return NotFound("Ce post n'existe pas.");
            }
            else
            {
                _dataContext.Remove(post);
                _dataContext.SaveChanges();
                Console.WriteLine("controller ok!");
                return Ok(post);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Article>> CreateNewBlogPost(Article request)
        {
            try
            {
                _dataContext.Add(request);
                await _dataContext.SaveChangesAsync();

                return request;

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Article>> UpdateBlogPost(Article request)
        {
            try
            {
                _dataContext.Update(request);
                await _dataContext.SaveChangesAsync();

                return Ok(request);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
