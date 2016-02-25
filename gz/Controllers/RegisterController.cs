using gz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gz.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult GetRegisterView()
        {
            Register r = new Register();
            return View(r);
        }
        [HttpPost]
        public ActionResult GetRegisterView(Register reg)
        {
            MemberContext MC = new MemberContext();
            if (ModelState.IsValid) {
                var IfExistence = MC.GetMember.Where(p => p.MemberAccount.Equals(reg.MemberAccount)).ToList();
            if(IfExistence.Count>0)
            {

            }else
            {
                MC.GetMember.Add(new Member
                {
                    MemberAccount = reg.MemberAccount,
                    MemberName = reg.MemberName,
                    MemberAddress = reg.MemberAddress,
                    MemberPassWord = reg.MemberPassWord,
                    MemberPostcode = reg.MemberPostcode
                }
                    );
                MC.SaveChanges();
            }
            return RedirectToAction("Login", "Home"); }
            
        
        else
        return View("GetRegisterView");
            
        }
    }
}