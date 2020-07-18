using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using EmployeeDetails.Model.Model;


namespace EmployeeDetails.DatabaseContext.DatabaseContext
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext()
        {

        }
        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Division> Divisions{ get; set; }
        public DbSet<Thana> Thanas { get; set; }
        public DbSet<City>   Cities { get; set; }
        public DbSet<Education> Educations { get; set; }
    }
}
