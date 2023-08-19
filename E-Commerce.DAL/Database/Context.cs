using E_Commerce.DAL.Entity;
using E_Commerce.DAL.Extend;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.Database
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public Context() : base()
        {

        }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Customer_Oreders> Customer_Oreders { get; set; }
        public DbSet<Customer_Oreders_Products> Customer_Oreders_Products { get; set; }


<<<<<<< HEAD
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("host=ep-sweet-voice-764690.eu-central-1.aws.neon.tech ;port=5432; database=neondb; username = d3bes; sslmode = require;password=eQ8ku1DWBHYK;TrustServerCertificate=true;MultipleActiveResultSets=true");
            //optionsBuilder.UseSqlServer("workstation id=EcommerceMVC.mssql.somee.com;packet size=4096;user id=d3bes_SQLLogin_1;pwd=rod8qah6gi;data source=EcommerceMVC.mssql.somee.com;persist security info=False;initial catalog=EcommerceMVC;TrustServerCertificate=true;MultipleActiveResultSets=true");
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-V38UNGC\\SQLEXPRESS;Initial Catalog=E-Commerce_New;Integrated Security=True;Encrypt=False;MultipleActiveResultSets=true");

            base.OnConfiguring(optionsBuilder);
        }
=======
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("host=ep-sweet-voice-764690.eu-central-1.aws.neon.tech ;port=5432; database=neondb; username = d3bes; sslmode = require;password=eQ8ku1DWBHYK;TrustServerCertificate=true;");
        //    base.OnConfiguring(optionsBuilder);
        //}
>>>>>>> d403ac127da79efd0db40c8947847da2b92e29dd

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer_Oreders_Products>()
                .HasKey(cr => new { cr.Customer_OredersId, cr.ProductsId });
            base.OnModelCreating(modelBuilder);
        }

    }
}
