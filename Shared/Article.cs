namespace Blazor_Blog_Jean.Shared
{
    public class Article
    {
        public int Id { get; set; }
        public string Url { get; set; }   
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
