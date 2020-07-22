using ozgur.tezel.blog.businessLogic.Models;
using System.Collections.Generic;

namespace ozgur.tezel.blog.app.Models
{
    public class AdminAllPostsViewModel
    {
        public AdminAllPostsViewModel(
            IEnumerable<ViewPost> postViewModels,
            int totalPosts)
        {
            var adminAllPosts = new List<AdminPostViewModel>();
            foreach (var post in postViewModels)
            {
                adminAllPosts.Add(new AdminPostViewModel(post));
            }
            AdminAllPosts = adminAllPosts;
            TotalPosts = totalPosts;
        }
        public IEnumerable<AdminPostViewModel> AdminAllPosts { get; set; }
        public int TotalPosts { get; set; }
    }
}
