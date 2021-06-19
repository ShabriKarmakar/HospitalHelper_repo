using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalHelperMVC.Models;

namespace HospitalHelperMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        //Authourization(USer existing with the same user name and password)-------------------------------------
        [HttpPost]
        public ActionResult Authourize(HospitalHelperMVC.Models.Reception_Log userModel)
        {
            using (HospHelperEntities db = new HospHelperEntities())
            {
                var userDetails = db.Reception_Log.Where(x => x.UserName == userModel.UserName && x.Password == userModel.Password).FirstOrDefault(); 
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong Username or Password";
                    return View("Index", userModel);

                }
                else
                {
                    Session["userID"] = userDetails.UserID;
                    Session["userName"] = userDetails.UserName;
                    return RedirectToAction("Index", "Home");
                }



            }


        }

        public ActionResult LogOut()
        {
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }

    }
}



    
