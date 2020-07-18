using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeDetails.Model.Model;
using EmployeeDetails.Repository.EmployeeDetails;
namespace EmployeeDetails.Manager.EmployeeDetails
{
    public class EmployeeDetailsManager
    {
        EmployeeDetailsRepository _employeeDetailsRepository = new EmployeeDetailsRepository();
        
        public bool Add(Employee employee)
        {
           return _employeeDetailsRepository.Add(employee);
        }

        public List<Employee> GetAll()
        {
            return _employeeDetailsRepository.GetAll();
        }
        public List<Division> GetDivisions()
        {
            return _employeeDetailsRepository.GetDivisions();

        }
        public List<City> GetCities(int id)
        {
            return _employeeDetailsRepository.GetCities(id);

        }
        public List<Thana> GetThanas(int id)
        {
            return _employeeDetailsRepository.GetThanas(id);
        }
        public string AutoId()
        {
            return _employeeDetailsRepository.AutoId();
        }

        public Employee GetById(string id)
        {
            return _employeeDetailsRepository.GetById(id);
        }
        public Division GetDivision(int id)
        {
            return _employeeDetailsRepository.GetDivision(id);
        }
        public City GetCity(int id)
        {
            return _employeeDetailsRepository.GetCity(id);

        }

        public Thana GetThana(int id)
        {
            return _employeeDetailsRepository.GetThana(id);
        }

        public bool Update(Employee employee)
        {
            return _employeeDetailsRepository.Update(employee);
        }

        public bool Delete(string id)
        {
            return _employeeDetailsRepository.Delete(id);
        }
    }
}
