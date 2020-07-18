using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeDetails.Manager.EmployeeDetails;
using EmployeeDetails.Model.Model;
using EmployeeDetails.Models;

namespace EmployeeDetails.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeDetailsManager _EmployeeDetailsManager = new EmployeeDetailsManager();
        private EmployeeView employee = new EmployeeView();
        // GET: Employee
       [HttpGet]
        public ActionResult Details()
        {

            EmployeeInitialize();
            ViewBag.Message = null;
            ViewBag.Operation = "0";
            ViewBag.ImgError = null;
            ViewBag.EduError = null;

            return View(employee);
        }
        [HttpPost]
        public ActionResult Details(EmployeeView employeeView, HttpPostedFileBase file)
            {
               
            if (file != null && file.ContentLength > 0)
            {
                string imgName = Path.GetFileName(file.FileName);
                string imgExt = Path.GetExtension(imgName);
                if (imgExt == ".jpg" || imgExt ==  ".png")
                {
                    string imgPath = Path.Combine(Server.MapPath("~/Image/EmployeeImage"), imgName);
                    file.SaveAs(imgPath);
                    ViewBag.ImgError = null;
                    employeeView.ImagePath = imgPath;

                }
               
            }

          
            Employee anEmployee = new Employee()
            {
                Id = employeeView.Id,
                Name = employeeView.Name,
                Age = AgeInYears(employeeView.DOB),
                DOB = employeeView.DOB,
                DivisionId = employeeView.DivisionId,
                Educations = employeeView.Educations,
                Gender = employeeView.Gender,
                CityId = employeeView.CityId,
                ThanaId = employeeView.ThanaId,
                ImagePath = employeeView.ImagePath
            };
            if (_EmployeeDetailsManager.Add(anEmployee))
            {
                ViewBag.Message = "Employee added successfully";
                ViewBag.Operation = "1";
            }
            else
            {
                ViewBag.Message = "Employee couldn't add";
                ViewBag.Operation = "-1";
            }

            ModelState.Clear();
            EmployeeInitialize();

            return View(employee);
        }

        [HttpGet]
        public ActionResult Show()
        {
            List<EmployeeView> employeeViews = new List<EmployeeView>();
            List<Employee> employees =  _EmployeeDetailsManager.GetAll();
           foreach (var employee in employees)
           {
               EmployeeView employeeView = new EmployeeView
               {
                   Id = employee.Id,
                   Name = employee.Name,
                   Age = employee.Age,
                   DOB = employee.DOB,
                   Division = employee.Division,
                   Educations = employee.Educations
               };
               employeeViews.Add(employeeView);
           }
            return View(employeeViews);
        }
        private void EmployeeInitialize()
        {
            employee = new EmployeeView
            {
                Name = string.Empty,
                Age =  0,
                DivisionId = 0,
                CityId = 0,
                ThanaId = 0,
                Gender = string.Empty,
                Divisions = _EmployeeDetailsManager.GetDivisions().Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.DivisionName
                }).ToList(),
                Id = _EmployeeDetailsManager.AutoId(),
                DOB = DateTime.Today
            };
           // GetCities(2);
            // GetThanas(4);
        }

        [HttpPost]
        public JsonResult AjaxMethod(string type, int value, string ip)
        {
           switch(type) 
            {
                case "Division_Id":
                    GetCities(value);
                    break;
                case "CityId":
                   GetThanas(value);
                    break;
            }
            return Json(employee);
        }

        private void GetThanas(int value)
        {
            employee.Thanas = _EmployeeDetailsManager.GetThanas(value)
                .Select(p => new SelectListItem() {Value = p.Id.ToString(), Text = p.ThanaName}
                ).ToList();
        }

        private void GetCities(int value)
        {
            employee.Cities = _EmployeeDetailsManager.GetCities(value)
                .Select(p => new SelectListItem() {Value = p.Id.ToString(), Text = p.CityName}
                ).ToList();
        }

        [HttpPost]
        public JsonResult AgeCalculation(DateTime dob)
        {
            var ageInYears = AgeInYears(dob);

            return Json(ageInYears);
        }

        private static int AgeInYears(DateTime dob)
        {
            DateTime currentDate = DateTime.Now;
            TimeSpan difference = currentDate.Subtract(dob);
            DateTime age = DateTime.MinValue + difference;
            int ageInYears = age.Year - 1;
            return ageInYears;
        }


        [HttpPost]
        public JsonResult EmployeeDetailsShow(string id)
        {
            Employee emp = _EmployeeDetailsManager.GetById(id);
            EmployeeView employeeView = new EmployeeView()
            {
                Name = emp.Name,
                Age = emp.Age,
                DOB = emp.DOB,
                DivisionName = _EmployeeDetailsManager.GetDivision(emp.DivisionId).DivisionName,
                CityName = _EmployeeDetailsManager.GetCity(emp.CityId).CityName,
                ThanaName = _EmployeeDetailsManager.GetThana(emp.ThanaId).ThanaName,
                ImagePath = emp.ImagePath?.Remove(0, emp.ImagePath.LastIndexOf("\\", StringComparison.Ordinal)+1)
            };



            return Json(employeeView);
        }

        [HttpPost]
        public JsonResult GetIp(dynamic ip)
        {
            return Json("");
        }
    }
}