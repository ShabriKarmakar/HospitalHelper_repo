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
    public class AdminHomeController : Controller
    {
        // GET: AdminHome
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
    }
}