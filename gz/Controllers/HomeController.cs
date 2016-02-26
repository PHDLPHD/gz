using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gz.Models;
using System.Web.Security;

namespace gz.Controllers
{
    
    public class HomeController : Controller
    {
        
        public ActionResult SingOut()
        {
            FormsAuthentication.SignOut();
            return View("Index");
        }
           public ActionResult Login()
        {
         //   string url = Request.Url.ToString();
            return View("Login");
        }
        [HttpPost]
           public ActionResult Login(Login log)
           {
               ModelState.AddModelError("UserName", "用户名不能为空");
               MemberContext mem = new MemberContext();
               var member = mem.GetMember.Where(p => p.MemberAccount.Equals(log.MemberAccount)).ToList();
            if(member.Count<=0)
            {
                ModelState.AddModelError("MemberAccount", "账号或密码错误！");
            }else
            {
                var login=member.Where(p=>p.MemberPassWord.Equals(log.MemberPassWord)).ToList();
                if (login.Count <= 0)
                {
                    ModelState.AddModelError("MemberAccount", "账号或密码错误！");
                }else
                {
                    
                    Response.Cookies.Remove(log.MemberAccount);
                    //记住登录状态
                    FormsAuthentication.SetAuthCookie(log.MemberAccount,true);
                    string returnUrl = TempData["url"].ToString();
                    if (returnUrl != null || !returnUrl.Equals(""))
                    {
                        return Redirect(returnUrl);
                    }
                    else 
                    return View("Index");
                    //if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")

                    //   && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    //{
                    //    return Redirect(returnUrl);,new { ReturnUrl =ViewBag.url}

                    //}

                    //else
                    //{

                    //    return RedirectToAction("Login", "Home");

                    //}
                }
            }

            return View("Login");
           }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
          
        
    }
}