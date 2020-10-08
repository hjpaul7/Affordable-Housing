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
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public double MonthlyIncome { get; set; }

        [Required]
        public int UnitsRequested { get; set; }


    }
}
