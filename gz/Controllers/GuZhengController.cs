using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gz.Models;
using System.Net;




namespace gz.Controllers
{
    public class GuZhengController : Controller
    {
        // GET: GuZheng
        public ActionResult Index()
        {

            GuZhengDBcontext gz = new GuZhengDBcontext();
            var GZList = gz.GetGuZheng.Where(p=>p.GZprice>0).ToList();
            return View(GZList);
        }

        public ActionResult Buy(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                GuZhengDBcontext gzdb = new GuZhengDBcontext();
                GuZheng gzh = gzdb.GetGuZheng.Where(p => p.GZNumber.Equals(id)).ToList().First();
                ViewBag.src = gzh.GZPhotoAddress;
                return View(gzh);
            }
            
        }
           [HttpPost]
        public ActionResult Buy(string id, int number)
        {
            if (id == null||number==0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
               if(Request.IsAuthenticated)
               {
                   return Content("<script >alert('购买成功！');</script >", "text/html");
               }else
               {
                   return RedirectToAction("Login", "Home");
               }
            }
            //if(Request.IsAuthenticated)
            //{
            //    string s=HttpContext.User.Identity.Name;

            //    return Content("<script >alert('购买成功！');</script >", "text/html");
            //}
            //else
            //{
            //    string url = Request.Url.ToString();
            //    return RedirectToAction("Login", "Home");
            //}
        }
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }else
            {
                GuZhengDBcontext gzdb = new GuZhengDBcontext();
                GuZheng gzh  = gzdb.GetGuZheng.Where(p => p.GZNumber.Equals(id)).ToList().First();
                ViewBag.src = gzh.GZPhotoAddress;
                return View(gzh);
            }
            
           
        }
    }
}