using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing_RedBadgeMVC.Models.ApplicationModels
{
    public class ApplicationListItem
    {
        [Display(Name = "Application ID")]
        public int Id { get; set; }

        [Display(Name = "Housing ID")]
        public int HousingId { get; set; }

        [Display(Name = "Applicant ID")]
        public string ApplicantId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Monthly Income")]
        public double MonthlyIncome { get; set; }

        [Display(Name = "Is available")]
        public bool IsAvailable { get; set; }
    }
}
