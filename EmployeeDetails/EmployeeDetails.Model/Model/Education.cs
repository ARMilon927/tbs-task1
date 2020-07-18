using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetails.Model.Model
{
    public class Education
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Degree { get; set; }
        public string Board { get; set; }
        public double Result { get; set; }
        public string Subject { get; set; }
        public string   EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
