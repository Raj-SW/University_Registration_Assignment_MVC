using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_Registration.BusinessLayer;
using University_Registration.DataAccessLayer;
using University_Registration.Models;

namespace University_Registration.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult RegisterStudent()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddStudent(StudentModel student)
        {
            

            var IsUserValid = StudentBL.CheckUniqueStudent(student);
            if (IsUserValid)
            {
                //LoginModel employeeInfo = AppUserBL.GetEmployeeDetailsWithRoles(model);
                StudentBL.AddStudent(student);
                //get student ID
               student.Subjects.StdId = StudentBL.getStudentId(student);
                //input into Subject table with the student Id
                SubjectBL.AddSubjects(student.Subjects);

                //this.Session["CurrentUser"] = stdModel;
                this.Session["CurrentUser"] = student.FirstName;
            }
            return Json(new { result = IsUserValid, url = Url.Action("Index", "Home") });
        }

    }
}