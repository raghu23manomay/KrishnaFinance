using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KrishnaFinance.Models;
using System.Data.SqlClient;


namespace KrishnaFinance.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login L, string ReturnUrl)
        {
            FinanceDbContext _db = new FinanceDbContext();
            var result = _db.LoginDetail.SqlQuery(@"exec usplogin 
                @UserName,@Password",
                new SqlParameter("@UserName", L.UserName == null ? (object)DBNull.Value : L.UserName),
                new SqlParameter("@Password", L.Password == null ? (object)DBNull.Value : L.Password)).ToList<Login>();
            // LoginDetail data = new LoginDetail();
            L = result.FirstOrDefault();
            if (L == null)
            {
                ViewBag.error = "Please enter valid user Name password";
            }
            else
            {
                Session["UserName"] = L.UserName;
                Session["UserID"] = L.UserID;
                Session["RoleID"] = L.RoleID;
                Session["RoleName"] = L.RoleName;
                return RedirectToAction("ApplicationList", "Master");
            }

            return View();
        }

    }
}
