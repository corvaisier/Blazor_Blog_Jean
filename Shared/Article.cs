using System.ComponentModel.DataAnnotations;

namespace Blazor_Blog_Jean.Shared
{
    public class Article
    {
        public int Id { get; set; }
        [Required, StringLength(20)]
        public string Url { get; set; }
        [Required, StringLength(255)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Content { get; set; }
        public string Image { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
