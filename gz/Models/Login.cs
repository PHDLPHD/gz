using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gz.Models
{
    public class Login
    {

        [DisplayName("账号")]
        [Required(ErrorMessage = "账号不能为空！")]
        public string MemberAccount { get; set; }
        [DisplayName("密码")]
        [Required(ErrorMessage = "密码不能为空！")]
        public string MemberPassWord { get; set; }
    }
}