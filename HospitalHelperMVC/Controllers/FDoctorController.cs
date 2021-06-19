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

namespace HospitalHelperMVC.Controllers
{
    public class FDoctorController : Controller
    {

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "zQtT5mFuofdGf16ykPBdYwyYdBaXElZNjCklYgMZ",
            BasePath = "https://hospitalhelper-c9cea-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        // GET: FDoctor
        public ActionResult Index()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Doctors");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<FDoctor>();
            foreach (var item in data)
            {
                list.Add(JsonConvert.DeserializeObject<FDoctor>(((JProperty)item).Value.ToString()));
            }
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FDoctor doctor)
        {


            try
            {
                AddFDoctorToFirebase(doctor);                  //Add doctor to firebase database
                ModelState.AddModelError(string.Empty, "Added Successfully!");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View();
        }

        private void AddFDoctorToFirebase(FDoctor doctor)
        {
            client = new FireSharp.FirebaseClient(config);
            var data = doctor;
            PushResponse response = client.Push("Doctors/", data);
            data.doctor_id = response.Result.name;
            SetResponse setResponse = client.Set("Doctors/" + data.doctor_id, data);
        }

       

        //Edit--------------------------------------------------------------------------------------------------------

        [HttpGet]
        public ActionResult Edit(string id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Doctors/" + id);
            FDoctor data = JsonConvert.DeserializeObject<FDoctor>(response.Body); //Getting Data and putting it back in place of "create"

            return View(data);
        }


        [HttpPost]
        public ActionResult Edit(FDoctor fdoctor)
        {
            client = new FireSharp.FirebaseClient(config);
            SetResponse response = client.Set("Doctors/" + fdoctor.doctor_id, fdoctor);


            return RedirectToAction("Index");
        }


        //------------------------------------------------------------------------


        //Delete----------------------------------------------------------------------------------------
        [HttpGet]
        public ActionResult Delete(string id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Delete("Doctors/" + id);


            return RedirectToAction("Index");
        }


    }
}