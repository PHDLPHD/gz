using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace gz.Models
{
    [Table("NewsParagraph")]
    public class NewsParagraph
    {
        [Key]
        public int NewsParagraphID{get;set;}
public string  NewsTitleID {get;set;}
public string newsparagraph{get;set;}
public string PhotoAddress { get; set; }

    }
    public class NewsParagraphDbcontext : DbContext
    {
        public DbSet<NewsParagraph> NewsParagraph { get; set; }
        public NewsParagraphDbcontext()
            : base("ConnectionString")
        {
            Database.SetInitializer<NewsParagraphDbcontext>(null);
        }
    }
}