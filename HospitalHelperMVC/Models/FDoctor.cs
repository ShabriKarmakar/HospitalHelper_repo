using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HospitalHelperMVC.Models
{
    public class FDoctor
    {
        [Display(Name = "ID")]
        public string doctor_id { get; set; }

        [Display(Name = "Doctor Name")]
        public string d_name { get; set; }

        [Display(Name = "Department")]
        public string department { get; set; }

        [Display(Name = "Speciality")]
        public string speciality { get; set; }

        [Display(Name = "Status")]
        public bool status { get; set; }

    }
}