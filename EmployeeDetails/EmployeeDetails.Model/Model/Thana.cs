using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetails.Model.Model
{
    public class Thana
    {
        public int Id { get; set; }
        public string ThanaName { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
