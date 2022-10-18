using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using University_Registration.DataAccessLayer;
using University_Registration.Models;

namespace University_Registration.BusinessLayer
{
    public class StudentBL
    {
        public static bool CheckUniqueStudent(StudentModel studentModel)
        {
            return StudentDAL.CheckUniqueStudent(studentModel);
        }
        public static void AddStudent(StudentModel studentModel)
        {
            studentModel.TotalPoints = SubjectBL.GetGradesTotal(studentModel.Subjects);
            //studentModel.Status = CheckStudentStatus(studentModel);

            //put student status as pending temporarily
            studentModel.Status = "Pending";

            StudentDAL.AddStudent(studentModel);

            //set top 15 students status to approved
            StudentBL.ReorderStatus();
        }

        public static int getStudentId(StudentModel studentModel)
        {
            return StudentDAL.GetStudentID(studentModel);
        }

        public static List<StudentModel> GetStudentWithConditions(string status)
        {
            return StudentDAL.GetStudentWithConditions(status);
        }

        public static String ApproveStudent(int id)
        {
            return StudentDAL.ApproveStudent(id); ;
        }

        public static String RejectStudent(int id)
        {

            return StudentDAL.RejectStudent(id);
        }
        public static String MoveToWaitingList(int id)
        {

            return StudentDAL.MoveToWaitingList(id);
        }

        public static String CheckStudentStatus(StudentModel studentModel)
        {
            var count = StudentDAL.GetApprovedStudentCount();

            if (studentModel.TotalPoints < 10)
            {
                return "Rejected";
            }
            if (studentModel.TotalPoints >= 10 && count < 15)
            {
                return "Approved";
            }
            else
                return "Pending";
        }

        public static void ReorderStatus()
        {
            StudentDAL.ReorderStatus();
        }
    }
}