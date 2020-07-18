using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetails.Model.Model
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }

        public int DivisionId { get; set; }
        public Division Division { get; set; }
        public List<Thana> Thanas { get; set; }
        public City()
        {
            Thanas = new List<Thana>();
        }
    }
}
