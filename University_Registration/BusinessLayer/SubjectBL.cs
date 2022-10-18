using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Schema;
using University_Registration.DataAccessLayer;
using University_Registration.Models;

namespace University_Registration.BusinessLayer
{
    public class SubjectBL
    {

        public static void AddSubjects(SubjectModel subjectModel)
        {
            subjectModel.Total = GetGrades(new List<char>() { subjectModel.Grade_1, subjectModel.Grade_2, subjectModel.Grade_3 });
            SubjectDAL.AddSubjects(subjectModel);
        }
        public static int GetGrades(List<char> myGrades) {
     
            return SubjectDAL.GetGradesTotal(myGrades);
        }


        public static int GetGradesTotal(SubjectModel subjectModel)
        {

            List<char> gradeList = new List<char>() { subjectModel.Grade_1, subjectModel.Grade_2, subjectModel.Grade_3 };
            return SubjectDAL.GetGradesTotal(gradeList);
        }
    }
}