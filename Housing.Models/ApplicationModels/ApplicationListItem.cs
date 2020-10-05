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

        [Display(Name = "Housing ID")]
        public string HousingId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Monthly Income")]
        public double MonthlyIncome { get; set; }
    }
}
