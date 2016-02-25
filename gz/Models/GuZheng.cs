using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace gz.Models
{
  
    [Table("GuZheng")]
    public class GuZheng
    {
        [Key]
        public string GZNumber { get; set; }
        public string MaterialCname { get; set; }
        public string GZPhotoAddress { get; set; }
        public string GZCname { get; set; }
        public string TechnologyCname { get; set; }
        public double GZprice { get; set; }
      

    }
    public class GuZhengDBcontext: DbContext
    {
        public DbSet<GuZheng> GetGuZheng { get; set; }
        public GuZhengDBcontext()
            : base("ConnectionString")
    {
        Database.SetInitializer<GuZhengDBcontext>(null);
        }
    
    }
}