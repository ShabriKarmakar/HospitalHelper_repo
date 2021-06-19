using HospitalHelperMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HospitalHelperMVC.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLoginDefault
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminAuthourize(HospitalHelperMVC.Models.AdminLogin userModel)
        {
            using (HospHelperEntities1 db =new HospHelperEntities1())
            {
                var userDetails = db.AdminLogins.Where(x => x.UserName == userModel.UserName && x.Password == userModel.Password).FirstOrDefault();
                if(userDetails==null)
                {
                    userModel.LoginErrorMessage = "Wrong Username or Password! ";
                    return View("Index", userModel);
                }

                else
                {
                    Session["userID"] = userDetails.UserID;
                    Session["userName"] = userDetails.UserName;
                    return RedirectToAction("Index", "AdminHome");
                }

            }

                
        }


        public ActionResult LogOut()
        {
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "AdminLogin");
        }

    }
}