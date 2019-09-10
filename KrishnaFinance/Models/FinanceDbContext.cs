using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KrishnaFinance.Models;

namespace KrishnaFinance.Models
{
    public class FinanceDbContext : DbContext
    { 
        static FinanceDbContext()
        {
            Database.SetInitializer<FinanceDbContext>(null);
        }
        public FinanceDbContext()
            : base("Name=FinanceDbContext")
        {
        }
        public DbSet<ApplicationList> ApplicationList { get; set; }
        public DbSet<Application> Application { get; set; }
        public DbSet<ApplicationApproval> ApplicationApproval { get; set; }
        public DbSet<PrintApplication> PrintApplication { get; set; }
        public DbSet<Login> LoginDetail { get; set; }
    }
    
}