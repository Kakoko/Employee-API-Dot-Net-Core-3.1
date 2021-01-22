using Employee.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.DBContext
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
          : base(options)
        {
        }

        //Exposing the Database Tables
        public DbSet<Entities.Employee> Authors { get; set; }
        public DbSet<Department> Departments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<Entities.Employee>().HasData(
                new Entities.Employee()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    FirstName = "Simuzeche",
                    LastName = "Kaluwa",
                    DateOfBirth = new DateTime(1650, 7, 23),
                    DepartmentId = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b")
                },
                new Entities.Employee()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    FirstName = "Andrew",
                    LastName = "Khonje",
                    DateOfBirth = new DateTime(1650, 7, 23),
                    DepartmentId = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b")
                },
                new Entities.Employee()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    FirstName = "Qina",
                    LastName = "Jere",
                    DateOfBirth = new DateTime(1650, 7, 23),
                    DepartmentId = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97")
                },
                new Entities.Employee()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    FirstName = "Lusayo",
                    LastName = "Mwainsimba",
                    DateOfBirth = new DateTime(1650, 7, 23),
                    DepartmentId = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97")
                }
                );

            modelBuilder.Entity<Department>().HasData(
               new Department
               {
                   Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                   DepartmentName = "ADD"
               },
               new Department
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                   DepartmentName = "Networks"
               },
               new Department
               {
                   Id = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                   DepartmentName = "BDD"
               },
               new Department
               {
                   Id = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                   DepartmentName = "SysAdmin"
               }
               );

            base.OnModelCreating(modelBuilder);
        }
    }
}
