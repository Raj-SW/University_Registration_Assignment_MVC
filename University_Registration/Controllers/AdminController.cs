using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_Registration.BusinessLayer;
using University_Registration.Models;

namespace University_Registration.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var waitingList = StudentBL.GetStudentWithConditions("Pending");
            var approvedList = StudentBL.GetStudentWithConditions("Approved");
            var rejectedList = StudentBL.GetStudentWithConditions("Rejected");
            ViewBag.WaitingList = waitingList;
            ViewBag.RejectedList = rejectedList;    
            ViewBag.ApprovedList = approvedList;
            return View();
        }
        public ActionResult Approve(int  id)
        {
            var result = StudentBL.ApproveStudent(id);
            if (result.Equals("Success"))
                return RedirectToAction("Index");

            return View();

        }
        public ActionResult Reject(int id)
        {
            var result = StudentBL.RejectStudent(id);
            if (result.Equals("Success"))
                return RedirectToAction("Index");

            return View();
        }
        public ActionResult MoveWait(int id)
        {
            var result = StudentBL.MoveToWaitingList(id);
            if (result.Equals("Success"))
                return RedirectToAction("Index");

            return View();
        }
        public void ExportCSV(string status)
        {
            StringWriter sw = new StringWriter();
            var studentsList = StudentBL.GetStudentWithConditions(status);

            sw.WriteLine("\"First Name\",\"Last Name\",\"DOB\",\"Email\",\"Total Points\"");

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=Exported_Users.csv");
            Response.ContentType = "text/csv";

            foreach (var student in studentsList)
            {
                sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"",
                                           student.FirstName,
                                           student.Surname,
                                           student.DOB,
                                           student.Email,
                                           student.TotalPoints));
            }

            Response.Write(sw.ToString());
            Response.End();
        }
    }
}