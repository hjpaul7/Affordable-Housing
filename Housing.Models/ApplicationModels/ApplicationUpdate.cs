using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing_RedBadgeMVC.Models.ApplicationModels
{
    public class ApplicationUpdate
    {
        public string HousingId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double MonthlyIncome { get; set; }
    }
}
