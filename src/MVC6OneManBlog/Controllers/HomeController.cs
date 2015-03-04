using System;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC6OneManBlog.Controllers
{
    public static class Data
    {
        private static Dictionary<string, PostModel> _posts = new Dictionary<string, PostModel>();

        internal static void Add(PostModel post)
        {
            _posts.Add(post.Slug, post);
        }

        internal static PostModel Get(string id)
        {
            return _posts[id];
        }
    }

    public class PostModel
    {
        public string Slug { get; set; }
        public string Content { get; set; }
    }

    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(PostModel post)
        {
            Data.Add(post);
            return RedirectToAction("Index", "Post", new { id = post.Slug });
        }
    }

    public class PostController : Controller
    {
        public IActionResult Index(string id)
        {
            return View(Data.Get(id));
        }
    }
}
