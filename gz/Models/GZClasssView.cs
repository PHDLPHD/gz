using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace gz.Models
{
    [Table("GZClasssView")]
    public class GZClasssView
    {
        [Key]
        public int ClassID { get; set; }
        public string ClassName{get;set;}
       public string ClassIntroduction {get;set;}
       public string ClassTypeName  { get; set; }
       public double ClassPrice { get; set; }
    }
    public class GZClasssViewDBcontext : DbContext
    {
        public DbSet<GZClasssView> GZClasssView { get; set; }
        public GZClasssViewDBcontext()
            : base("ConnectionString")
        {
            Database.SetInitializer<GZClasssViewDBcontext>(null);
        }

    }
}