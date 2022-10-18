using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using University_Registration.BusinessLayer;
using University_Registration.Models;

namespace University_Registration.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Landing()
        {
            return View();
        }
        public JsonResult Authenticate(LoginModel loginModel)
        {
            var IsUserValid = AdminBL.AuthenticateUser(loginModel);
            if (IsUserValid)
            {
                this.Session["CurrentAdminName"] = loginModel.AdminName;
            }
            return Json(new { result = IsUserValid, url = Url.Action("Index", "Admin") });
        }
    }
}