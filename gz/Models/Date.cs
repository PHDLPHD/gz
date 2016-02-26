using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace gz.Models
{
    [Table("Date")]
    public class Date
    {
        [Key]
        public int DayID { get; set; }
        public string Day { get; set; }
    }
    public class  DateDbcontext:DbContext
    {
        public DbSet<Date> date { get; set; }
        public DateDbcontext()
            : base("ConnectionString")
        {
            Database.SetInitializer<DateDbcontext>(null);
        }
    }
}
