using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gz.Models
{
    public class Register
    {

        [DisplayName("账号")]
        [Required(ErrorMessage = "账号不能为空！")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "账号必须为10位数字字母组合")]
        [RegularExpression("^[A-Za-z0-9]+$", ErrorMessage = "账号必须为10位数字字母组合")]
        public String MemberAccount { get; set; }

        [DisplayName("密码")]
        [Required(ErrorMessage = "密码不能为空！")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "密码必须为6--10位")]
        [RegularExpression("^[a-zA-Z]\\w+$", ErrorMessage = "密码以字母开头只能包含字符、数字和下划线")]
        public String MemberPassWord { get; set; }

        [DisplayName("重复密码")]
        [Required(ErrorMessage = "重复密码不能为空！")]
        [Compare("MemberPassWord",ErrorMessage = "重复密码不一致")]
        public String RptMemberPassWord { get; set; }

        [DisplayName("真实姓名")]
        [Required(ErrorMessage = "真实姓名不能为空！")]
        public String MemberName { get; set; }

        [DisplayName("收货地址")]
        [Required(ErrorMessage = "收货地址不能为空！")]
      
        public String MemberAddress { get; set; }

        [DisplayName("邮政编码")]
        [Required(ErrorMessage = "邮政编码不能为空！")]
        [RegularExpression("^\\d{6}$", ErrorMessage = "编号必须为6位数字")]
        public String MemberPostcode { get; set; }
    }
}