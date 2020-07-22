using ozgur.tezel.blog.businessLogic.Models;
using System.Collections.Generic;

namespace ozgur.tezel.blog.businessLogic.Interfaces
{
    public interface IPostBusinessLayer
    {
        IEnumerable<ViewPost> List();
        ViewPost GetPostById(int id);
    }
}