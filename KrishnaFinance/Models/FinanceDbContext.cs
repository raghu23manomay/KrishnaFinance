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
        public DbSet<GetTransection> GetTransection { get; set; }
        public DbSet<Collectiondata> Collectiondata { get; set; }
        public DbSet<ApplicationList> ApplicationList { get; set; }
        public DbSet<CollectionList> CollectionList { get; set; }
        public DbSet<Application> Application { get; set; }
        public DbSet<ApplicationApproval> ApplicationApproval { get; set; }
        public DbSet<PrintApplication> PrintApplication { get; set; }
        public DbSet<PrintDemandPromissory> PrintDemandPromissory { get; set; }
        public DbSet<Login> LoginDetail { get; set; }
    }
    
}