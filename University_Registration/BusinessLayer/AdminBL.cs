using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using University_Registration.DataAccessLayer;
using University_Registration.Models;

namespace University_Registration.BusinessLayer
{
    public class AdminBL
    {
        public static bool AuthenticateUser(LoginModel model)
        {
            return AdminDAL.AuthenticateUser(model);
        }

    }
}