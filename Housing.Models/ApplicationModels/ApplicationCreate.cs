using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing_RedBadgeMVC.Models.ApplicationModels

{
    public class ApplicationCreate
    {
        [Required]
        public int HousingId { get; set; }

        //public string ApplicantId { get; set; }
        //public string ApplicantUser { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Monthly Income")]
        public double MonthlyIncome { get; set; }

        [Required]
        [Display(Name = "Units Requested")]
        public int UnitsRequested { get; set; }


    }
}
