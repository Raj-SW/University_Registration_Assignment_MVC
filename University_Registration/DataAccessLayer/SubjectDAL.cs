using EmployeeManagement.DataAccessLayer.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using University_Registration.Models;

namespace University_Registration.DataAccessLayer
{
    public class SubjectDAL
    {
        enum category { E = 6, D = 7, C = 8, B = 9, A = 10 };

        //public const string selectSubjectsStdIdWise = @"SELECT sub.* FROM Subjects sub, Students stud WHERE stud.StudentID";
        public const string insertSubjects = @"INSERT INTO [dbo].[Subjects] ([StdId],[Subject_1],[Grade_1],[Subject_2],[Grade_2],[Subject_3],[Grade_3],[Total])
                                               SELECT   @StdId,@Subject1,@Grade1,@Subject2,@Grade2,@Subject3,@Grade3,@Total";
        public static void AddSubjects(SubjectModel subjects) 
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@StdId", subjects.StdId));
            parameters.Add(new SqlParameter("@Subject1", subjects.Subject_1));
            parameters.Add(new SqlParameter("@Grade1", subjects.Grade_1));
            parameters.Add(new SqlParameter("@Subject2", subjects.Subject_2));
            parameters.Add(new SqlParameter("@Grade2", subjects.Grade_2));
            parameters.Add(new SqlParameter("@Subject3", subjects.Subject_3));
            parameters.Add(new SqlParameter("@Grade3", subjects.Grade_3));
            parameters.Add(new SqlParameter("@Total", subjects.Total));

            DBCommand.InsertUpdateData(insertSubjects, parameters);

        }
        public static void GetSubjects() { }
        public static int GetGradesTotal(List<char> myGrades)
        {
            var total = 0;
            foreach (char grade in myGrades)
            {
                switch (Char.ToUpper(grade))
                {
                    case 'A':
                        total += 4;
                        break;
                    case 'B':
                        total += 3;
                        break;
                    case 'C':
                        total += 2;
                        break;
                    case 'D':
                        total += 1;
                        break;
                    case 'E':
                        total += 0;
                        break;
                }
            }
            return total;
        }

    }
}