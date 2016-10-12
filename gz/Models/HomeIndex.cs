using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace gz.Models
{
    public class HomeIndex
    {
        public List<GuZheng> GuZheng { get; set; }
        public List<GuZheng> GuZheng2 { get; set; }
        public NewsTitle NewTitle {get;set;}
        public NewsParagraph NewParagraph { get; set; }
        public GZClasssView GZCliass { get; set; }
        }
    public class HomeIndexDbContext : DbContext
    {
        public DbSet<GuZheng> GetGuZheng { get; set; }
        public DbSet<NewsTitle> NewsTitle { get; set; }
        public DbSet<NewsParagraph> NewsParagraph { get; set; }
        public DbSet<GZClasssView> GZClasssView { get; set; }
        public  HomeIndexDbContext()
            :base("ConnectionString")
    {
        Database.SetInitializer<HomeIndexDbContext>(null);
    }
    }
}