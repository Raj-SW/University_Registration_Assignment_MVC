using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University_Registration.Models
{
    public class SubjectModel
    {
        public int RecordID { get; set; }
        public int StdId { get; set; }
        public string Subject_1 { get; set; }
        public char Grade_1 { get; set; }
        public string Subject_2 { get; set; }
        public char Grade_2 { get; set; }
        public string Subject_3 { get; set; }
        public char Grade_3 { get; set; }
        public int Total { get; set; }

    }
}