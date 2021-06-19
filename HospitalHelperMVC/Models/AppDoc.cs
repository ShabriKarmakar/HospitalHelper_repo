using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalHelperMVC.Models
{
    public class AppDoc
    {
        
            public List<Appointment> Appointments { get; set; }
            public List<FDoctor> FDoctors { get; set; }
        public List<PatientTable> Patients { get; set; }
        public List<DoctorTable> Doctors { get; set; }

    }
}