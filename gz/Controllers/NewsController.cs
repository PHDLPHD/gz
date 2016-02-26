using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gz.Models;

namespace gz.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            NewsTitleDbcontext ne = new NewsTitleDbcontext();

            return View(ne.NewsTitle.ToList());
        }
        public ActionResult Edit(string id,string title)
        {
            NewsParagraphDbcontext ne = new NewsParagraphDbcontext();
            ViewBag.message= title;
            return View(ne.NewsParagraph.Where(p => p.NewsTitleID.Equals(id)).ToList());
        }
    }
}