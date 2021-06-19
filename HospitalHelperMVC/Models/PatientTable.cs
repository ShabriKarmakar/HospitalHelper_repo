//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HospitalHelperMVC.Models
{
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class PatientTable
    {
        public int PatientID { get; set; }

        [Required(ErrorMessage = "Patient Name is Required")]
        [Display(Name = "Patient Name")]
        public string Patient_name { get; set; }

        [Range(0, 100)]
        public Nullable<int> Age { get; set; }
        public string Symptoms { get; set; }
        public string Department { get; set; }

        [Required(ErrorMessage = "Emergency Contact is Required")]
        [Display(Name = "Emergency Contact")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Emergency_contact { get; set; }
        public Nullable<int> Due_pay { get; set; }
        public string BedID { get; set; }

        public static explicit operator JProperty(PatientTable v)
        {
            throw new NotImplementedException();
        }
    }
}
