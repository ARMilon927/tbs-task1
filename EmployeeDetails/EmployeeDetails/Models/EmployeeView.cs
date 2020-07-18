using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeDetails.Model.Model;

namespace EmployeeDetails.Models
{
    public class EmployeeView
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Please enter full name")]
        public string Name { get; set; }
        public int Age { get; set; }
        [Required(ErrorMessage = "Please enter Date of Birth")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Please select gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please select division")]
        public int DivisionId { get; set; }
        public Division Division { get; set; }
        [Required(ErrorMessage = "Please select city")]
        [Range(1, Double.MaxValue, ErrorMessage = "Please select city")]

        public int CityId { get; set; }
        public City City { get; set; }
        [Required(ErrorMessage = "Please select thana")]
        [Range(1, Double.MaxValue, ErrorMessage = "Please select thana")]
        public int ThanaId { get; set; }
        public Thana Thana { get; set; }
        public string DivisionName { get; set; }
        public string ThanaName { get; set; }
        public string CityName { get; set; }
        [Required]
        [EnsureOneElement(ErrorMessage = "Please add at least one education level")]
        public List<Education> Educations { get; set; }
        public List<SelectListItem> Divisions { get; set; }
        public List<SelectListItem> Cities { get; set; }
        public List<SelectListItem> Thanas { get; set; }
        public string ImagePath { get; set; }


        public EmployeeView()
        {
            Educations = new List<Education>();
            Divisions = new List<SelectListItem>();
            Cities = new List<SelectListItem>();
            Thanas = new List<SelectListItem>();
        }
        public class EnsureOneElementAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                if (value is IList list)
                {

                    bool valid = list.Count > 0;
                    return valid;
                }
                return false;
            }
        }
        [Range(minimum: 1, maximum: 4, ErrorMessage = "Please add at least one education level")]
        public int ItemCount
        {
            get
            {
                return Educations != null ? Educations.Count : 0;
            }
        }
    }
}