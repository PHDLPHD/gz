using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gz.Models;
using System.Net;
using System.Runtime.Remoting.Contexts;





namespace gz.Controllers
{
    public class GuZhengController : Controller
    {
      
        // GET: GuZheng
        public ActionResult Index()
        {

            GuZhengDBcontext gz = new GuZhengDBcontext();
           
            return View(gz.GetGuZheng.ToList());
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
                  
                
                   MemberContext m = new MemberContext();
                   string s = HttpContext.User.Identity.Name.ToString();
                   var mem = m.GetMember.Where(p => p.MemberAccount.Equals(s)).ToList().First();
                   OrderBDContext o = new OrderBDContext();
                   o.Order.Add(new Order
                   {
                       OrderID=DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                       MemberID=mem.MemberID,
                       GZNumber=id,
                       OrderNum=number,
                       
                   });
                   o.SaveChanges();
                  
                   return Content("<script >alert('购买成功！');window.location.href =''</script >", "text/html");
                  
                   
               }else
               {
                   TempData["url"] = Request.Url.ToString();
                   return RedirectToAction("Login", "Home");
               }
            }
           
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