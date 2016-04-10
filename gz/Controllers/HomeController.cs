using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gz.Models;
using System.Web.Security;

namespace gz.Controllers
{
    /// <summary>
    /// 主页
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public ActionResult SingOut()
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Index"); 
            if (Request.IsAuthenticated)//登录检测
            {
                return null;
            }
            else
                return View("Index");
        }
        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns></returns>
           public ActionResult Login()
        {
         //   string url = Request.Url.ToString();
            return View("Login");
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
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
                    //返回登录前页面
                  
                    if (TempData["url"] != null )
                    {
                        string url = TempData["url"].ToString();
                        Response.Redirect(url); 
                        return Redirect(url);
                    }
                    else
                    {
                        Response.Redirect("Index"); 
                        return View("Index");
                    }
                   
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
        /// <summary>
        /// s首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 关于
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        /// <summary>
        /// 联系方式
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
          
        
    }
}