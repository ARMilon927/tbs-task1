using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetails.Model.Model
{
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public int DivisionId { get; set; }
        public Division Division { get; set; }

        public int CityId { get; set; }
       
        public int ThanaId { get; set; }
        public string ImagePath { get; set; }
        public List<Education> Educations { get; set; }
        public Employee()
        {
            Educations = new List<Education>();
        }
    }
}
