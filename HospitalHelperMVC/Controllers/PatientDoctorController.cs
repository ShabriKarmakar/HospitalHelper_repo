using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalHelperMVC.Models;

namespace HospitalHelperMVC.Controllers
{
    public class PatientDoctorController : Controller
    {
        

        // GET: PatientDoctor
        public ActionResult Index()
        {
            HospHelperEntities db = new HospHelperEntities();
            List<PatientTable> patNames = db.PatientTables.ToList();
            List<DoctorTable> docNames = db.DoctorTables.ToList();

            var patdoctable = from p in patNames
                              join d in docNames on p.Department equals d.Department into table1
                              from d in table1.DefaultIfEmpty()
                              select new MultipleClass {patientdetails=p, doctordetails=d };
            return View(patdoctable);
        }
    }
}