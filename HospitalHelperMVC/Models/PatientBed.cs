using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalHelperMVC.Models
{
    public class PatientBed
    {

        public PatientTable patientdetails { get; set; }
        public BedTable beddetails { get; set; }


    }
}