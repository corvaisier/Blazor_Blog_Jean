using Blazor_Blog_Jean.Shared;
using Microsoft.EntityFrameworkCore;

namespace Blazor_Blog_Jean.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Article> BlogPosts { get; set; }
    }
}
