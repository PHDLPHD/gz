using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gz.Models
{
    [Table("Member")]
    public class Member
    {
        [Key]
        public int MemberID { get;set;}
        public String MemberAccount{get;set;}
public String MemberPassWord{get;set;}
public String MemberName{get;set;}
public String MemberAddress{get;set;}
public String MemberPostcode{get;set;}

    }

    public class MemberContext:DbContext
    { 
        public MemberContext():base("ConnectionString")
    {
         Database.SetInitializer<MemberContext>(null);
        }
    
    }
}