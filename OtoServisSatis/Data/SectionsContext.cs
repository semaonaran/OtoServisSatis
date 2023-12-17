using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class SectionsContext : DbContext
    {
     
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SaleInfo> SaleInfos { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Service> Services { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost; DataBase=OtoServisSatis; MultipleActiveResultSets=True;integrated security=True;  TrustServerCertificate=True");
            //optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent Apı
            modelBuilder.Entity<Brand>().Property(b => b.Name).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Role>().Property(b => b.Name).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<SaleInfo>().Property(x => x.SalePrice).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Service>().Property(x => x.ServiceFee).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Vehicle>().Property(x => x.Price).HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                Name = "Admin"
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Firstname = "Admin",
                Lastname = "admin",
                ActiveRatio = true,
                UploadDate = DateTime.Now,
                Email = "admin@otoservissatis.tc",
                UserName = "admin",
                Password = "123456",                
               // Role = new Role() { Id = 1},
                RoleId = 1,
                PhoneNumber = "0850"
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
