using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetails.Model.Model
{
    public class Division
    {
        public int Id { get; set; }
        public string DivisionName { get; set; }
        public List<City> Cities { get; set; }
        public Division()
        {
            Cities = new List<City>();
        }
    }
}
