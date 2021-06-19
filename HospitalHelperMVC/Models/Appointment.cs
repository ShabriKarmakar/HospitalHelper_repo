using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace HospitalHelperMVC.Models
{
    public class Appointment
    {
        [Display(Name ="Age")]
        public string age { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Document")]
        public string pdf { get; set; }

        [Display(Name = "Status")]
        public string status { get; set; }

        [Display(Name = "Appointment Type")]
        public string type { get; set; }
        [Display(Name = "Appointment ID")]
        public string appointment_id { get; set; }

        [Display(Name ="Date and Time")]
        public string timestamp { get; set; }

        [Display(Name = "Hospital Name")]
        public string hospName { get; set; }

        [Display(Name = "Emergency Number")]

        public string emergencyNo { get; set; }


    }
}