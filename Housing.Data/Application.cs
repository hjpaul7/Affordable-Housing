using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing_RedBadgeMVC.Data
{
    public class Application
    {
        // Housing ID
        [ForeignKey(nameof(HousingAppId))]
        public string HousingId { get; set; }
        public virtual Housing HousingAppId { get; set; }

        // Application User ID
        [ForeignKey(nameof(ApplicantUser))]
        public string ApplicantId { get; set; }
        public virtual ApplicationUser ApplicantUser { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public double MonthlyIncome { get; set; }
    }
}
