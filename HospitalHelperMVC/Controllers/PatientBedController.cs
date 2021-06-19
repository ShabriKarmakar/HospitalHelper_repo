using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalHelperMVC.Models;

namespace HospitalHelperMVC.Controllers
{
    public class PatientBedController : Controller
    {
        // GET: PatientBed
        public ActionResult Index()
        {
            HospHelperEntities db = new HospHelperEntities();
            List<PatientTable> patNames = db.PatientTables.ToList();
            List<BedTable> bedDetails = db.BedTables.ToList();

            var patbedtable = from p in patNames
                              join b in bedDetails on p.BedID equals b.BedID into table1
                              from b in table1.DefaultIfEmpty()
                              select new PatientBed { patientdetails = p, beddetails = b };
            return View(patbedtable);
        }
    }
}