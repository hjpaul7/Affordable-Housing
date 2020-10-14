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
        [Key]
        public int HousingId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Units Available?")]
        public int UnitsAvailable { get; set; }

        [Display(Name = "Safe")]
        public bool IsSafe { get; set; }

        [Required]
        [Display(Name = "Accepts Vouchers")]
        public Voucher AcceptVoucher { get; set; }

        [Required]
        [Display(Name = "Section Type")]
        public Section SectionType { get; set; }

        public byte[] Image { get; set; }

      
    }
}
