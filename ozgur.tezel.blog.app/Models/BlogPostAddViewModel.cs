using System.ComponentModel.DataAnnotations;

namespace ozgur.tezel.blog.app.Models
{
    public class BlogPostAddViewModel
    {
        [Display(Name = "Author")]
        [MaxLength(50)]
        [Required]
        public string Author { get; set; }

        [Display(Name = "Title")]
        [MaxLength(50)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Content")]
        public string Content { get; set; }

        [Display(Name = "Active")]
        public bool Active { get; set; }
    }
}
