using Microsoft.AspNet.Mvc;
using MVC6OneManBlog.Controllers;
using System;

namespace MVC6OneManBlog.ViewComponents
{
    public class PostListViewComponent : ViewComponent
    {
        private Data _data;

        public PostListViewComponent(Data data)
        {
            _data = data;
        }

        public IViewComponentResult Invoke()
        {
            var items = _data.GetPosts();
            return View(items);
        }
    }
}