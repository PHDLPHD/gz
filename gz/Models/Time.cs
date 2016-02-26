using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace gz.Models
{
    
      [Table("Time")]
  public class Time
  {
          [Key]
          public int TimeID { get; set; }
          public string time { get; set;
          }
  }
    public class TimeDbcontext:DbContext
    {
        public DbSet<Time> time { get; set; }
        public TimeDbcontext()
            : base("ConnectionString")
        {
            Database.SetInitializer<TimeDbcontext>(null);
        }
    }
}