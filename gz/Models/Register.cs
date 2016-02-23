using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gz.Models
{
    public class Register
    {
        
        public String MemberAccount { get; set; }
        public String MemberPassWord { get; set; }
        public String RptMemberPassWord { get; set; }
        public String MemberName { get; set; }
        public String MemberAddress { get; set; }
        public String MemberPostcode { get; set; }
    }
}