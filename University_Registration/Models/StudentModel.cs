using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University_Registration.Models
{
    public class StudentModel
    {
        public int StudentId { get; set; } 
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DOB { get; set; }
        public string GuardianName { get; set; }
        public string Email { get; set; }
        public string NID { get; set; }
        public string Status { get; set; }  
        public int TotalPoints { get; set; }
        public SubjectModel Subjects { get; set; }   


    }
}