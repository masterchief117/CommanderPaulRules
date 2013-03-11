using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBBlog.Models;

namespace DBBlog.Controllers
{
    public class BlogController : Controller
    {
        //
        // GET: /Blog/

        public ActionResult Index()
        {
            using (var db = new BlogDataEntities())
            {
                return View(db.Blogs.ToList());
            }
        }
        [HttpGet]
        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Blog blog)
        {

            try
            {
                using (var db = new BlogDataEntities())
                {
                    db.Blogs.Add(blog);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

    }
}