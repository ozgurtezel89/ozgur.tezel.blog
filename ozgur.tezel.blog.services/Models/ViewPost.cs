using ozgur.tezel.blog.dataAccess.Models;
using System;

namespace ozgur.tezel.blog.businessLogic.Models
{
    public class ViewPost
    {
        public ViewPost(PostTable postTable)
        {
            if (postTable is null)
            {
                throw new ArgumentNullException(nameof(postTable));
            }

            Id = postTable.Id;
            Author = postTable.Author;
            Title = postTable.Title;
            if (postTable.Content?.Length > 150)
            {
                ShortContent = postTable.Content?.Substring(0, 150);
            }
            else
            {
                ShortContent = postTable.Content;
            }
            
            Content = postTable.Content;
            Active = postTable.Active;
        }

        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }

        // Added short and full content to demonstrate different user requirements, values will be generated them from PostTable.Content
        public string ShortContent { get; set; }
        public string Content { get; set; }
        public bool Active { get; set; }
    }
}
