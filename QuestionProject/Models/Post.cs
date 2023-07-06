namespace QuestionProject.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int ViewCount { get; set; }
        public bool IsNewPost { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
