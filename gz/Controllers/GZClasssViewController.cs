using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gz.Models;

namespace gz.Controllers
{
    /// <summary>
    /// 课程预约
    /// </summary>
    public class GZClasssViewController : Controller
    {
        
        // GET: GZClasssView
        public ActionResult Index()
        {
            GZClasssViewDBcontext gz = new GZClasssViewDBcontext();
   
            return View(gz.GZClasssView.ToList());
        }
       
        public ActionResult Details(int id)
        {
            
            GZClasssViewDBcontext g = new GZClasssViewDBcontext();

            var gc = g.GZClasssView.Where(p => p.ClassID == id).First();
            DateDbcontext da = new DateDbcontext();
            ViewData["DateList"] = new SelectList(da.date.ToList(), "DayID", "Day",2);
            TimeDbcontext ti = new TimeDbcontext();
            ViewData["TimeList"] = new SelectList(ti.time.ToList(), "TimeID", "time",2);
            return View(gc);
           
        }
        [HttpPost]
        public ActionResult Details(int id, int TimeList, int DateList)
        {
            if (Request.IsAuthenticated)//登录检测
            {
                MemberContext m = new MemberContext();
                string s = HttpContext.User.Identity.Name.ToString();
                var mem = m.GetMember.Where(p => p.MemberAccount.Equals(s)).ToList().First();
                ClassAppointmentDbcontext cl = new ClassAppointmentDbcontext();
                cl.ClassAppointment.Add(new ClassAppointment
                {
                    AppointmentID = DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                    MemberID=mem.MemberID,
                    ClassID=id,
                    DayID=DateList,
                    TimeID=TimeList
                });
                cl.SaveChanges();

                return Content("<script >alert('预约成功！');window.location.href ='/Home/Index'</script >", "text/html");

            }
            else
            {
                TempData["url"] = Request.Url.ToString();
                return RedirectToAction("Login", "Home");
            }
           
        }
    }
}