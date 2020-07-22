using ozgur.tezel.blog.businessLogic.Models;

namespace ozgur.tezel.blog.app.Models
{
    public class PostGeneralDisplayViewModel
    {
        public PostGeneralDisplayViewModel(ViewPost post)
        {
            Id = post.Id;

            // Demonstrating different display options inside the view model - separate from business logic
            if (string.IsNullOrEmpty(post.Author))
            {
                Author = "Anonymous";
            }
            else
            {
                Author = $"Written by {post.Author}";
            }

            Title = post.Title;
            ShortContent = post.ShortContent + "...";
        }

        // I didn't add [Display(Name = "Id")] in here, as I dont want to display the Id, I will assign it to a hidden html field.
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        // I didn't add the full content here to demonsrate different view models to display different info to the user.
        public string ShortContent { get; set; }
    }
}