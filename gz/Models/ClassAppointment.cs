using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace gz.Models
{
    [Table("ClassAppointment")]
    public class ClassAppointment
    {
        [Key]
        public string AppointmentID { get; set; }

        public int MemberID { get; set; }
        public int ClassID { get; set; }
        public int DayID { get; set; }
        public int TimeID { set; get; }
    }
    public class ClassAppointmentDbcontext : DbContext
    {
        public DbSet<ClassAppointment> ClassAppointment { get; set; }
        public ClassAppointmentDbcontext()
            : base("ConnectionString")
        {
            Database.SetInitializer<ClassAppointmentDbcontext>(null);
        }
    }
}