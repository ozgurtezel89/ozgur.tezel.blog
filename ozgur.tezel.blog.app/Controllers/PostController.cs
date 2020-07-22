using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ozgur.tezel.blog.app.Models;
using ozgur.tezel.blog.businessLogic.Interfaces;

namespace ozgur.tezel.blog.app.Controllers
{
    public class PostController : Controller
    {
        #region Private Variables

        private readonly IPostBusinessLayer postBusinessLayer;

        #endregion

        #region Constructors

        public PostController(
            IPostBusinessLayer postBusinessLayer)
        {
            this.postBusinessLayer = postBusinessLayer;
        }

        #endregion

        #region Main Calls

        public IActionResult Index()
        {
            var posts = postBusinessLayer.List();
            var viewModel = new List<PostGeneralDisplayViewModel>();
            
            foreach (var post in posts)
            {
                viewModel.Add(new PostGeneralDisplayViewModel(post));
            }
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var post = postBusinessLayer.GetPostById(id);
            if (post is null)
            {
                return Content("Post does not exist!");
            }
            return View(new PostDetailsViewModel(post));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion
    }
}
