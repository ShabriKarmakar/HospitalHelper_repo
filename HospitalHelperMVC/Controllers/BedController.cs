using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalHelperMVC.Models;
using System.Data.Entity;

namespace HospitalHelperMVC.Controllers
{
    public class BedController : Controller
    {
        // GET: Bed
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (HospHelperEntities db = new HospHelperEntities())
            {
                List<BedTable> bedList = db.BedTables.ToList<BedTable>();
                return Json(new { data = bedList }, JsonRequestBehavior.AllowGet);
            }
        }


        //Add and Update-------(id==0 Add else Update)


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)

        {
            if (id == 0)
            {
                return View(new BedTable());

            }
            else
            {
                using (HospHelperEntities db = new HospHelperEntities())
                {
                    return View(db.BedTables.Where(x => x.id == id).FirstOrDefault<BedTable>());
                }
            }

        }


        //Add and Update-------(emp.EmployeeID==0 Add else Update)

        [HttpPost]
        public ActionResult AddOrEdit(BedTable bed)
        {
            using (HospHelperEntities db = new HospHelperEntities())
            {

                if (bed.id == 0)
                {


                    db.BedTables.Add(bed);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);   //Json Success message after saving
                }
                else
                {
                    db.Entry(bed).State = EntityState.Modified;
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
                BedTable bed = db.BedTables.Where(x => x.id == id).FirstOrDefault<BedTable>();
                db.BedTables.Remove(bed);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}