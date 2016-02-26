using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace gz.Models
{
    [Table("NewsTitle")]
    public class NewsTitle
    {
        [Key]
        public string NewsTitleID { get; set; }
        public string NewsTitleName { get; set; }
    }
    public class NewsTitleDbcontext : DbContext
    {
        public DbSet<NewsTitle> NewsTitle { get; set; }
        public NewsTitleDbcontext()
            : base("ConnectionString")
        {
            Database.SetInitializer<NewsTitleDbcontext>(null);
        }
    }
}