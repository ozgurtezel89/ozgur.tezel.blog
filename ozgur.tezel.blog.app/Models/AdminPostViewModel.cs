using ozgur.tezel.blog.businessLogic.Models;

namespace ozgur.tezel.blog.app.Models
{
    public class AdminPostViewModel
    {
        public AdminPostViewModel(ViewPost post)
        {
            Id = post.Id;
            Author = post.Author;
            Title = post.Title;
            ShortContent = post.ShortContent;
            Active = post.Active;
        }

        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string ShortContent { get; set; }
        public bool Active { get; set; }
    }
}
