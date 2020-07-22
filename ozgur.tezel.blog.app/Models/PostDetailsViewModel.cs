using ozgur.tezel.blog.businessLogic.Models;
using System.ComponentModel.DataAnnotations;

namespace ozgur.tezel.blog.app.Models
{
    public class PostDetailsViewModel
    {

        public PostDetailsViewModel(ViewPost post)
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
            Content = post.Content;
        }

        public int Id { get; set; }
        [Display(Name = "Post Author:")]
        public string Author { get; set; }
        [Display(Name = "Post Title:")]
        public string Title { get; set; }
        [Display(Name = "Post Content:")]
        // I didn't add the short content here to demonsrate read more functionality to the user.
        public string Content { get; set; }
    }
}
