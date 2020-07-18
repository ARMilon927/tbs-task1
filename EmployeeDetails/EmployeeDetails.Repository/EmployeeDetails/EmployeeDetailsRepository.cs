using EmployeeDetails.DatabaseContext.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeDetails.Model.Model;
using System.Data.Entity;

namespace EmployeeDetails.Repository.EmployeeDetails
{
    public class EmployeeDetailsRepository
    {
        EmployeeDbContext _EmployeeDbContext = new EmployeeDbContext();
        public bool Add(Employee employee)
        {
            try
            {
                _EmployeeDbContext.Employees.Add(employee);
                return _EmployeeDbContext.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            
        }

        public bool Update(Employee employee)
        {
            Employee aEmployee = _EmployeeDbContext.Employees.FirstOrDefault(c => c.Id == employee.Id);
            if (aEmployee != null)
            {
                aEmployee.Name = employee.Name;
                aEmployee.Educations = employee.Educations;
                aEmployee.ImagePath = employee.ImagePath;
                aEmployee.DOB = employee.DOB;
                aEmployee.Gender = employee.Gender;
                aEmployee.DivisionId = employee.DivisionId;
                aEmployee.Age = employee.Age;
                aEmployee.CityId = employee.CityId;
                aEmployee.ThanaId = employee.ThanaId;
            }

            return _EmployeeDbContext.SaveChanges()>0;
        }

        public bool Delete(string id)
        {
            Employee employee = _EmployeeDbContext.Employees.FirstOrDefault(c => c.Id == id);
            if (employee != null)
            {
                _EmployeeDbContext.Employees.Remove(employee);
            }

            return _EmployeeDbContext.SaveChanges() > 0;
        }
        public List<Employee> GetAll()
        {
            List < Employee > employees = new List<Employee>();
            if (_EmployeeDbContext.Employees != null)
            {
                 employees = _EmployeeDbContext.Employees.ToList();
                 return employees;
            }
            return employees;   
        }

        public Employee GetById(string id)
        {
          var anEmployee =  _EmployeeDbContext.Employees.FirstOrDefault(c => c.Id == id);
          return anEmployee;
        }
        public Division GetDivision(int id)
        {
            return _EmployeeDbContext.Divisions.FirstOrDefault(c => c.Id == id);
        }
        public City GetCity(int id)
        {
            return _EmployeeDbContext.Cities.FirstOrDefault(c => c.Id == id);

        }
        public Thana GetThana(int id)
        {
            return _EmployeeDbContext.Thanas.FirstOrDefault(c => c.Id == id);
        }
        public List<Division> GetDivisions()
        {
            return _EmployeeDbContext.Divisions.ToList();
        }
        public List<City> GetCities(int id)
        {
            return _EmployeeDbContext.Cities.Where(c => c.DivisionId == id).ToList();

        }
        public List<Thana> GetThanas(int id)
        {
            return _EmployeeDbContext.Thanas.Where(c => c.CityId == id).ToList();
        }
        public string AutoId()
        {
            string id = null;
            int count = _EmployeeDbContext.Employees.Count();
            if(count == 0)
            {
                return id = "TBS#001";
            }
            else
            {
             return   id = "TBS#" + (count + 1).ToString("000");
            }
        }
    }
}
