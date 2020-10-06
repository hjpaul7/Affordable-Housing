using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Housing_RedBadgeMVC.Data.Housing;

namespace Housing_RedBadgeMVC.Models.HousingModels
{
    public class HousingCreate
    {
        public int HousingId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int UnitsAvailable { get; set; }

        [Required]
        public Voucher AcceptVoucher { get; set; }

        [Required]
        public Section SectionType { get; set; }
    }
}
