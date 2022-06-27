using System.ComponentModel.DataAnnotations;

namespace Blazor_Blog_Jean.Shared
{
    public class Article
    {
        public int Id { get; set; }
        [Required, StringLength(20), RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string Url { get; set; }
        [Required, StringLength(25)]
        public string Title { get; set; }
        [Required, StringLength(25)]
        public string Description { get; set; }
        public string Content { get; set; } = String.Empty;
        public string Image { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
