using Housing_RedBadgeMVC.Models.ApplicationModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Housing_RedBadgeMVC.Data.Housing;

namespace Housing_RedBadgeMVC.Models.HousingModels
{
    public class HousingDetail
    {
        [Display(Name = "Housing ID")]
        public int HousingId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Units Available")]
        public int UnitsAvailable { get; set; }

        [Display(Name = "Accepts Voucher")]
        public Voucher AcceptVoucher { get; set; }

        [Display(Name = "Safe")]
        public bool IsSafe { get; set; }

        [Display(Name = "Section Type")]
        public Section SectionType { get; set; }

        public List<ApplicationListItem> ApplicationListItems { get; set; } = new List<ApplicationListItem>();
    }
}
