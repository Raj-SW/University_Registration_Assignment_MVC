using EmployeeManagement.DataAccessLayer.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using University_Registration.BusinessLayer;
using University_Registration.DataAccessLayer;
using University_Registration.Models;

namespace University_Registration.DataAccessLayer
{
    public class StudentDAL
    {
        //change student status to approved
        public const string APPROVE_STUDENT = @"UPDATE Students SET Status = 'Approved' WHERE StudentId=@id";
        //change student status to rejected
        public const string REJECT_STUDENT = @"UPDATE Students SET Status = 'Rejected' WHERE StudentId=@id";
        //change student status to pending
        public const string WAIT_STUDENT = @"UPDATE Students SET Status = 'Pending' WHERE StudentId=@id";
        //approved student for count
        public const string GET_APPROVED_STUDENT = @"SELECT * FROM Students WHERE Status = 'Approved'";
        //set all students points<10 to rejected status
        public const string SET_REJECTED= @"UPDATE Students SET Status = 'Rejected' WHERE TotalPoints<10";
        //set pending to all students with Totalpoints>=10
        public const string SET_PENDING = @"UPDATE Students SET Status = 'Pending' WHERE TotalPoints>=10";
        //set approved to top15 students
        public const string SET_APPROVED = @"UPDATE Students SET Status='Approved' FROM ( SELECT TOP (15) * FROM Students s2 WHERE s2.TotalPoints >= 10 ORDER BY s2.TotalPoints) AS table2 WHERE Students.TotalPoints>=10";
        //get studentID
        public const string GET_STUDENTID = @"SELECT StudentID FROM Students WHERE NID=@NID";
        //get all records from Students table
        public const string SELECT_ALL_STUDENT = @"SELECT * FROM Students";
        //check if student is unique
        public const string CHECK_UNIQUE = @"SELECT * FROM Students WHERE NID = @NID OR Email=@Email OR PhoneNumber=@PhoneNumber";
        //insert a new student
        public const string INSERT_STUDENT = @"INSERT INTO [dbo].[Students] ([FirstName],[Surname],[Address],[PhoneNumber],[DOB],[GuardianName],[Email],[NID],[Status],[TotalPoints])
            select @FirstName,@Surname,@Address,@PhoneNumber,@DOB,@GuardianName,@Email,@NID,@Status,@TotalPoints";
        //get records of Students status-wise
        public const string SELECT_STUDENT_BY_STATUS = @"SELECT * FROM Students WHERE Status=@Status ORDER BY TotalPoints DESC";

        public static void AddStudent(StudentModel student)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@FirstName", student.FirstName));
            parameters.Add(new SqlParameter("@Surname", student.Surname));
            parameters.Add(new SqlParameter("@Address", student.Address));
            parameters.Add(new SqlParameter("@PhoneNumber", student.PhoneNumber));
            parameters.Add(new SqlParameter("@DOB", student.DOB));
            parameters.Add(new SqlParameter("@GuardianName", student.GuardianName));
            parameters.Add(new SqlParameter("@Email", student.Email));
            parameters.Add(new SqlParameter("@NID", student.NID));
            parameters.Add(new SqlParameter("@Status", student.Status));
            parameters.Add(new SqlParameter("@TotalPoints", student.TotalPoints));

            DBCommand.InsertUpdateData(INSERT_STUDENT, parameters);

        }
        public static bool CheckUniqueStudent(StudentModel student)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@FirstName", student.FirstName));
            parameters.Add(new SqlParameter("@Surname", student.Surname));
            parameters.Add(new SqlParameter("@Address", student.Address));
            parameters.Add(new SqlParameter("@PhoneNumber", student.PhoneNumber));
            parameters.Add(new SqlParameter("@DOB", student.DOB));
            parameters.Add(new SqlParameter("@GuardianName", student.GuardianName));
            parameters.Add(new SqlParameter("@Email", student.Email));
            parameters.Add(new SqlParameter("@NID", student.NID));
            parameters.Add(new SqlParameter("@TotalPoints", student.TotalPoints));

            var dt = DBCommand.GetDataWithConditions(CHECK_UNIQUE, parameters);

            if(dt.Rows.Count > 0)
            {
            return false;
            }
            else
            {
                return true;
            }
        }

        public static int GetStudentID(StudentModel student)
        {
            List<SqlParameter> parameters= new List<SqlParameter>();
            parameters.Add(new SqlParameter("@NID", student.NID));
            var dt= DBCommand.GetDataWithConditions(GET_STUDENTID, parameters);

            return int.Parse(dt.Rows[0]["StudentId"].ToString());
        }

        public static List<StudentModel> GetStudentWithConditions(string status)
        {
            List<StudentModel> studentList= new List<StudentModel>();

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add((SqlParameter)new SqlParameter("@Status", status));
            
            var dt= DBCommand.GetDataWithConditions(SELECT_STUDENT_BY_STATUS, parameters);

            StudentModel student;

            foreach (DataRow row in dt.Rows)
            {
                student = new StudentModel();
                student.StudentId= int.Parse(row["StudentId"].ToString());
                student.FirstName = row["FirstName"].ToString();
                student.Surname = row["Surname"].ToString();
                student.Address = row["Address"].ToString();
                student.PhoneNumber = row["PhoneNumber"].ToString();
                student.DOB =DateTime.Parse(row["DOB"].ToString());
                student.GuardianName = row["GuardianName"].ToString();
                student.Email = row["Email"].ToString();
                student.NID = row["NID"].ToString();
                student.Status = row["Status"].ToString();
                student.TotalPoints = int.Parse(row["TotalPoints"].ToString());
                studentList.Add(student);
            }

            return studentList;

        }
        public static String ApproveStudent(int id) {

            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add((SqlParameter)new SqlParameter("@id", id));

                DBCommand.InsertUpdateData(APPROVE_STUDENT, parameters);

                return "Success";
            }
            catch (Exception e) {

                return e.ToString();
            }
        }
        public static String RejectStudent(int id)
        {

            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add((SqlParameter)new SqlParameter("@id", id));

                DBCommand.InsertUpdateData(REJECT_STUDENT, parameters);

                return "Success";
            }
            catch (Exception e)
            {
                return e.ToString() ;
            }
        }
        public static String MoveToWaitingList(int id)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add((SqlParameter)new SqlParameter("@id", id));

                DBCommand.InsertUpdateData(WAIT_STUDENT, parameters);

                return "Success";
            }
            catch (Exception e)
            {

                return e.ToString();
            }
        }
        public static int GetApprovedStudentCount()
        {

            var dt = DBCommand.GetData(GET_APPROVED_STUDENT);

            return dt.Rows.Count;
        }

        public static void ReorderStatus()
        {
            //set status to rejected for points<10
            DBCommand.UpdateDataNoConditions(SET_REJECTED);
            //set status to pending for all points>=10
            DBCommand.UpdateDataNoConditions(SET_PENDING);
            //set status to approved for top 15
            DBCommand.UpdateDataNoConditions(SET_APPROVED);
        }
    }
}