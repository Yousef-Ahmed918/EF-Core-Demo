using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EF_Core_Demo.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_Demo.Data
{
    internal class CompanyDBContext : DbContext //Base Class For Every Context
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-L9C5J8O;Database=Company;Integrated Security =True;TrustServerCertificate=True"); //New Syntax
       optionsBuilder.UseLazyLoadingProxies(true); 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Work RelationShip
            modelBuilder.Entity<Department>()
                .HasMany(d=>d.Employees)
                .WithOne(e=>e.Department)
                .HasForeignKey(e=>e.DepartmentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            //modelBuilder.Entity<Employee>()
            //    .HasOne(d=>d.Department)
            //    .WithMany(e=>e.Employees)
            //    .HasForeignKey(e=>e.DepartmentId)
            //    .IsRequired(false)
            //    .OnDelete(DeleteBehavior.Cascade);

            //One To One
            modelBuilder.Entity<Employee>()
                .HasOne(d=>d.ManagedDepartment)
                .WithOne(e=>e.Manager)
                .HasForeignKey<Department>(e=>e.ManagerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<EmployeesDepartments>().ToView("EmployeeDepartmentView").HasNoKey();
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeesDepartments> EmployeesDepartmentsView { get; set; }
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Project> Projects { get; set; }
    }
}
