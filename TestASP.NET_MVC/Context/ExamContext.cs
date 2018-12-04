using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestMVC.Models;

namespace TestASP.NET_MVC.Context
{
    public class ExamContext : DbContext
    {
        public DbSet<Exam> Exams { get; set; }
    }
}