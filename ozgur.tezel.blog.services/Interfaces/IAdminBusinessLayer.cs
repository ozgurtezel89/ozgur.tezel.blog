using ozgur.tezel.blog.businessLogic.Models;
using System.Collections.Generic;

namespace ozgur.tezel.blog.businessLogic.Interfaces
{
    public interface IAdminBusinessLayer
    {
        IEnumerable<ViewPost> List();
        int TotalPosts();
        void AddPost(AddPost post);
        void SetPostStatus(bool isActive, int id);
    }
}
