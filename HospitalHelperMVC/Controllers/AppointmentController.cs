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
    public class AppointmentController : Controller
    {
        //FireBase Connection---------------------------------------------------------------------------------------------------------------------------
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "zQtT5mFuofdGf16ykPBdYwyYdBaXElZNjCklYgMZ",
            BasePath = "https://hospitalhelper-c9cea-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;


        // GET: Appointment
        public ActionResult Index()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Appointments");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<Appointment>();
           
            foreach (var item in data)
            {
                list.Add(JsonConvert.DeserializeObject<Appointment>(((JProperty)item).Value.ToString()));
            }
            return View(list);
        }

        //Edit--------------------------------------------------------------------------------------------------------

        [HttpGet]
        public ActionResult Edit(string id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Appointments/" + id);
            Appointment data = JsonConvert.DeserializeObject<Appointment>(response.Body); //Getting Data and putting it back in place of "create"

            return View(data);
        }


        [HttpPost]
        public ActionResult Edit(Appointment appointment)
        {
            client = new FireSharp.FirebaseClient(config);
            SetResponse response = client.Set("Appointments/" + appointment.appointment_id, appointment);


            return RedirectToAction("Index");
        }
    }
}