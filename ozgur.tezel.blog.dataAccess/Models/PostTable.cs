namespace ozgur.tezel.blog.dataAccess.Models
{
    public class PostTable
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Active { get; set; }
    }
}