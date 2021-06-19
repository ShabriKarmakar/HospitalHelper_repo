using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalHelperMVC.Models;
using System.Data.Entity;

namespace HospitalHelperMVC.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReadDoctor()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (HospHelperEntities db = new HospHelperEntities())
            {
                List<DoctorTable> docList = db.DoctorTables.ToList<DoctorTable>();
                return Json(new { data = docList }, JsonRequestBehavior.AllowGet);
            }
        }


        //Add and Update-------(id==0 Add else Update)


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)

        {
            if (id == 0)
            {
                return View(new DoctorTable());

            }
            else
            {
                using (HospHelperEntities db = new HospHelperEntities())
                {
                    return View(db.DoctorTables.Where(x => x.DoctorID == id).FirstOrDefault<DoctorTable>());
                }
            }

        }


        //Add and Update-------(emp.EmployeeID==0 Add else Update)

        [HttpPost]
        public ActionResult AddOrEdit(DoctorTable doc)
        {
            using (HospHelperEntities db = new HospHelperEntities())
            {

                if (doc.DoctorID == 0)
                {


                    db.DoctorTables.Add(doc);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);   //Json Success message after saving
                }
                else
                {
                    db.Entry(doc).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);   //Json Success message after saving

                }
            }

        }


        //Delete Operation

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (HospHelperEntities db = new HospHelperEntities())
            {
                DoctorTable doc = db.DoctorTables.Where(x => x.DoctorID == id).FirstOrDefault<DoctorTable>();
                db.DoctorTables.Remove(doc);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}