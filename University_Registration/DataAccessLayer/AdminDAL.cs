using EmployeeManagement.DataAccessLayer.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using University_Registration.Models;

namespace University_Registration.DataAccessLayer
{
    public class AdminDAL
    {
        public const string AuthenticateUserQuery = @"SELECT * FROM Admin WHERE Name = @AdminName and Password = @Password ";

        public static bool AuthenticateUser(LoginModel model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@AdminName", model.AdminName));
            parameters.Add(new SqlParameter("@Password", model.Password));

            var dt = DBCommand.GetDataWithConditions(AuthenticateUserQuery, parameters);

            return dt.Rows.Count > 0;
        }
    }
}