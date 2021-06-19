using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalHelperMVC.Models;
using System.Data.Entity;


namespace HospitalHelperMVC.Controllers
{


    //FireBase Connection---------------------------------------------------------------------------------------------------------------------------
    
    public class HomeController : Controller
    {

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "zQtT5mFuofdGf16ykPBdYwyYdBaXElZNjCklYgMZ",
            BasePath = "https://hospitalhelper-c9cea-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;


      

        // GET: Home
        public ActionResult Index()
        {
            var appointments = GetAppointments();
            var fdoctors = GetFDoctors();
            var patients = GetPat();
            var doctors = GetDoc();

            AppDoc model = new AppDoc();
            model.FDoctors = fdoctors;
            model.Appointments = appointments;
            model.Patients = patients;
            model.Doctors = doctors;

            return View(model);

            

        }


        private List<Appointment> GetAppointments()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Appointments");

            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);

            var list = new List<Appointment>();

            foreach (var item in data)
            {

                list.Add(JsonConvert.DeserializeObject<Appointment>(((JProperty)item).Value.ToString()));
            }
            return list;

        }


        private List<FDoctor> GetFDoctors()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Doctors");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<FDoctor>();

            foreach (var item in data)
            {
                list.Add(JsonConvert.DeserializeObject<FDoctor>(((JProperty)item).Value.ToString()));
            }
            return list;

        }







        public ActionResult ReadDoctor()
        {
            return View();
        }


       

      private List<PatientTable> GetPat()
      {
         
          using (HospHelperEntities db = new HospHelperEntities())
          {
                var patlist = db.PatientTables.ToList<PatientTable>();
                foreach (var item in patlist)
                {
                    patlist = db.PatientTables.ToList<PatientTable>();

                }

                return patlist;

            }

         
      }

        private List<DoctorTable> GetDoc()
        {

            using (HospHelperEntities db = new HospHelperEntities())
            {
                var doclist = db.DoctorTables.ToList<DoctorTable>();
                foreach (var item in doclist)
                {
                    doclist = db.DoctorTables.ToList<DoctorTable>();

                }

                return doclist;

            }


        }


        public ActionResult GetData()
       {
           using (HospHelperEntities db = new HospHelperEntities())
           {
               List<PatientTable> patList = db.PatientTables.ToList<PatientTable>();
               return Json(new { data = patList }, JsonRequestBehavior.AllowGet);
           }
       }

        public ActionResult GetList()
        {
            using (HospHelperEntities db = new HospHelperEntities())
            {
                var docList = db.DoctorTables.ToList<DoctorTable>();

                return Json(new { data = docList }, JsonRequestBehavior.AllowGet);
            }

        }



    }
}