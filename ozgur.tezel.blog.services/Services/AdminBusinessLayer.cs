using ozgur.tezel.blog.businessLogic.Interfaces;
using ozgur.tezel.blog.businessLogic.Models;
using ozgur.tezel.blog.dataAccess.Interfaces;
using ozgur.tezel.blog.dataAccess.Models;
using System.Collections.Generic;

namespace ozgur.tezel.blog.businessLogic.Services
{
    public class AdminBusinessLayer : IAdminBusinessLayer
    {
        #region Private Variables

        private readonly IPostRepository postRepository;

        #endregion

        #region Constructors
        public AdminBusinessLayer(
            IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }
        #endregion

        #region Main Calls

        public void AddPost(AddPost post)
        {
            var postTable = new PostTable {
                Author = post.Author,
                Title = post.Title,
                Content = post.Content,
                Active = post.Active
            };

            postRepository.AddPost(postTable);
        }

        public void SetPostStatus(bool isActive, int id)
        {
            postRepository.SetPostStatus(isActive, id);
        }

        public IEnumerable<ViewPost> List()
        {
            var posts = postRepository.GetAllPosts();

            foreach (var post in posts)
            {
                yield return new ViewPost(post);
            }
        }

        public int TotalPosts()
        {
            return postRepository.TotalPosts();
        }

        #endregion
    }
}