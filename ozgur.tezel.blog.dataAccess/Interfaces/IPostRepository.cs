using ozgur.tezel.blog.dataAccess.Models;
using System;
using System.Collections.Generic;

namespace ozgur.tezel.blog.dataAccess.Interfaces
{
    public interface IPostRepository : IDisposable
    {
        IEnumerable<PostTable> GetAllPosts();
        IEnumerable<PostTable> GetAllActivePosts();
        PostTable GetById(int id);
        int TotalPosts();
        void SetPostStatus(bool isActive, int id);
        void AddPost(PostTable post);
    }
}