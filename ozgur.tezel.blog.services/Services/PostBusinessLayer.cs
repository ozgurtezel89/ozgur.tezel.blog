using ozgur.tezel.blog.businessLogic.Interfaces;
using ozgur.tezel.blog.businessLogic.Models;
using ozgur.tezel.blog.dataAccess.Interfaces;
using System.Collections.Generic;

namespace ozgur.tezel.blog.businessLogic.Services
{
    public class PostBusinessLayer : IPostBusinessLayer
    {
        #region Private Variables

        private readonly IPostRepository postRepository;

        #endregion

        #region Constructors

        public PostBusinessLayer(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        #endregion

        #region Main Calls

        public IEnumerable<ViewPost> List()
        {
            var posts = postRepository.GetAllActivePosts();

            foreach (var post in posts)
            {
                yield return new ViewPost(post);

            }
        }

        public ViewPost GetPostById(int id)
        {
            return new ViewPost(postRepository.GetById(id));
        }

        #endregion
    }
}