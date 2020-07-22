using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ozgur.tezel.blog.app.Models;
using ozgur.tezel.blog.businessLogic.Interfaces;
using ozgur.tezel.blog.businessLogic.Models;
using ozgur.tezel.blog.businessLogic.Services;

namespace ozgur.tezel.blog.app.Controllers
{
    public class AdminController : Controller
    {
        #region Private Variables

        private readonly IAdminBusinessLayer adminBusinessLayer;

        #endregion

        #region Constructors

        public AdminController(IAdminBusinessLayer adminBusinessLayer)
        {
            this.adminBusinessLayer = adminBusinessLayer;
        }

        #endregion

        #region Main Calls

        public IActionResult Home()
        {
            var totalPostsCount = adminBusinessLayer.TotalPosts();
            var posts = adminBusinessLayer.List();
                
            return View(
                new AdminAllPostsViewModel(posts, totalPostsCount));
        }

        public IActionResult SetPostStatus(bool isActive, int id)
        {
            adminBusinessLayer.SetPostStatus(isActive, id);

            return RedirectToAction("Home", "Admin");
        }

        [HttpGet]
        public IActionResult AddBlogPost()
        {
            return View(new BlogPostAddViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddBlogPost(BlogPostAddViewModel formData)
        {
            if (ModelState.IsValid)
            {
                adminBusinessLayer.AddPost(new AddPost
                {
                    Active = formData.Active,
                    Author = formData.Author,
                    Content = formData.Content,
                    Title = formData.Title
                });

                return RedirectToAction("Home", "Admin");
            }
            return View(formData);
        }

        #endregion
    }
}
