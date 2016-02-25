using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace gz.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public string OrderID { get; set; }
        public string GZNumber { get; set; }
        public int MemberID { get; set; }
        public int OrderNum { get; set; }
    }
    public class OrderBDContext : DbContext
    {

        public DbSet<Order> Order { get; set; }
        public OrderBDContext()
            : base("ConnectionString")
    {
        Database.SetInitializer<OrderBDContext>(null);
        }
    }
    
}